<?php      //module for reading a mesh in binary LLSD format and calculating a perceptual hash from it
//require("../secret/secret.php");
$fsassets= "/home/opensim/mvra/fsassets/data/";
if (!isset($HEXhash))
    require("hexhash.php");        //module for building hex hashes
require("LLSD.php");        //routines for reading LLSD files
require("STATS.php");       //routines for calculating statistics, bounding box, stdeviation

$VOX=4;    //size of the voxel cube 4x4x4 producing 4x4x3x3 complexity gradiant bits
$UVM=11;    //size of the UV map table, producing 11*11 UVmap bits

function uvpic($arr,$UVM)    //for debugging: Draws a picture of the UV bitmap
{
    for ($j=0;$j<$UVM;$j++)
    {
        for ($i=0;$i<$UVM;$i++)
            print '.'.(string)$arr[$i+$UVM*$j];
        print "\n";
    }
    print "-----------\n";
}  //uvpic

function histopic($hist)        //diagnostic try to print the histogram
{
    global $VOX;
    for($s=0;$s<$VOX;$s+=1)
    {
        for ($t=0;$t<$VOX;$t+=1)
        {
            for ($u=0;$u<$VOX;$u+=1)
                printf("%3u.",$hist[$s+$t*$VOX+$u*$VOX*$VOX]);
            print "\n";
        }
        print "---------------------\n";
        }
} //histopic


function isdupe($x,$y,$z,$list)	//chdck to see if this veretex is in in the list yet
{
    $dnum=count($list);
    for ($di=0;$di<$dnum;$di+=3)
    {
        if ($x==$list[$di]&& $y==$list[$di+1] && $z==$list[$di+2])	//if it is in the list
            return(true);			//return true
    }
    return(false);
}
     //****************************************************************
    //meshhash calculates a hash of a mesh asset this hash can be compared
    //by Hamming distance to find similar DAE files or mesh
    //This is done by:
    //Quantizing the vectors into 4x4x4 voxels (counts of vertexes in each voxel)
    //Scanning the voxel space for increasing (1) and decreasing (0) complexity (vertex count)
    //Building a small (11x11) bitmap from the UV map(s) 
    //Input:    mesh asset in memory, in LLSD format
    //Output:   perceptual hash as a 64 character HEX string (256 bit hash value)
function meshhash($meshdata)
{
    global $VOX;    //size of the voxel cube 4x4x4 producing 4x4x3x3 complexity gradiant bits
    global $UVM;    //size of the UV map table, producing 11*11 UVmap bits
            //I only use 112 of the UVmap bits, so the hash comes out 256 bits in size
    startLLSD($meshdata);    //set up to read it
    $lodpos=-10;
    $lodsis=-10;
    $lod0=0;    //1 if we found the LOD 0 data
    $lastname="";
                //a mesh asset starts with an LLSD named array for all the LODs
                //inside each named element is an offset and size to the data
                //I want to extract the offset and size of just the high_lod
    while(($next=nextLLSD())!=false)    //get next item from LLSD
    {
        $type=$next['type'];
        $depth=$next['depth'];
//        $name="";
//        if (isset($next['name']))
//            $name=$next['name'];
//        $size="";
//        if (isset($next['size']))
//            $size=$next['size'];
//        print "type=$type depth=$depth name=$name size=$size\n";
        if ($next['type']=='k')
        {
            if ($next['depth']==1)  //the lod tables are at level 1 in the tree structure
            {
                if ($next['name']=='high_lod')
                    $lod0=1;    //allow fetching data from high_lod only
                else
                    $lod0=0;
            }
            if ($lod0==1 && $next['depth']==2)
            {
                if ($next['name']=='offset')
                {
                    $value=nextLLSD();
                    $lodpos=$value['value'];    //had better be an integer
                }
                if ($next['name']=='size')
                {
                    $value=nextLLSD();
                    $lodsiz=$value['value'];
                }
            }
        } //end type k (name)
        else if ($type=='b')    //binary blob
        {
            setLLSDpos($next['size']);      //skip blobs in the header
        }
    } //while there is something to read
    if ($lodpos < 0)
    {
        print 'I did not find a high_lod mesh in this data\n';
        return(false);
     }
//    print "pos=$lodpos size=$lodsiz\n";
//    $lodpos += getLLSDpos();    //offsets are relative to the end of the header!
//    $loddata = gzuncompress(getLLSDblob($lodpos,$lodsiz));
    setLLSDpos($lodpos);	//works 'cause lodpos is relative to END of LLSD header
    $loddata = gzuncompress(getLLSDblob($lodsiz)); 

    if ($loddata==false)
    {
        print "cannot uncompress high lod data\n";
        return(false);
    }
    startLLSD($loddata);    //the LOD data is another LLSD object
           //I'm going to combine all mesh parts into one voxel histogram
    $voxel = array_fill(0,$VOX*$VOX*$VOX,0);
            //and all uvmaps into one 11x11 bitmap
    $uvmap = array_fill(0,$UVM*$UVM,0);   //for storing a combined bitmap
    startSTAT();    //initialize the statistics for the standard deviation
    $vname = "";    //name of last map
    $nodupe=array();		//array to find duplicate co-ordinates
    $non=0;
    while(($next=nextLLSD())!=false)
    {
	    //                print_r($next);
	    $type = $next['type'];
        if ($next['type']=='k')        //if it is a map item name
        {
            $vname = $next['name'];
        }
        else if ($next['type'] == 'b')
	    {
		    $size=$next['size'];	//all blobs have size
//		print "binary blob named $vname of size $size\n";
            if ($vname=='Position')    //There can be multiple Position tables (one for each face)
	        {                           //collect them all into the statistics
                for ($b=0;$b<$next['size'];$b+=6)    //for all the samples
		        {
                    $x=(float)getLLSDulint2()/65535.0-0.5;
                    $y=(float)getLLSDulint2()/65535.0-0.5;
		            $z=(float)getLLSDulint2()/65535.0-0.5;
//		    print "Vertex $x $y $z\n";
		            $non +=1;
		            if (isdupe($x,$y,$z,$nodupe)==false)	//Not in list yet
                    {
                        sumSTAT($x,$y,$z);	//count it in stats
			            $nodupe[]=$x;		//but add to the list
			            $nodupe[]=$y;
			            $nodupe[]=$z;
		            }
                } //end all the positions
            } //end this is a Position blob containing vectors
            else if (substr($vname,0,8)=='TexCoord')    //merge all the UV maps together
            {
                for($uv=0;$uv<$next['size'];$uv=$uv+4)    //read all the uv map co-ords
                {
                                //get the uv map points
                    $u = (integer)((float)($UVM)*(float)getLLSDulint2()/65535.0);
                    $v = (integer)((float)($UVM)*(float)getLLSDulint2()/65535.0);
//                    print "($u,$v)";
                    $uvmap[$u+$UVM*$v] = 1;       //this location is used
                } //end all the uv map co-ords
            } //end this is a TexCoord blob containging UV co-ordinates
            else    //a binary blob I don't need, skip it
            {
                $bins=$next['size'];
//                        print "skipping $bins bytes for $vname\n";
                setLLSDpos( $bins);
            }
        } //end this is a binary blob
        else if ($next['type'] == 'r')
        {
            $rf = $next['value'];    //get a real number
	    }
	    else if ($type=='s')
	    {
		    $string=$next['name'];	//just ignore strings
	    }
        else if ($type=='1')
            continue;   //ignore true values
        else
        {
            print "I don't know type $type yet for table $vname\n";
            return(false);
        }
    } //end loop for all data in the LLSD
//    uvpic($uvmap,$UVM);

                //after seeing every submesn (face), calculate the statistics
//    list($meanx,$stdvx,$meany,$stdvy,$meanz,$stdvz)=stdSTAT();
    list($offx,$scalex,$offy,$scaley,$offz,$scalez)=scaleSTAT(); //get scale factors
//   global $N,$minx,$maxx,$miny,$maxy,$minz,$maxz;
//   print "Total number of unique samples is $N non unique $non\n";
//   print "$minx<x<$maxx mean=$meanx std=$stdvx\n";
//   print "$miny<y<$maxy mean=$meany std=$stdvy\n";
//   print "$minz<z<$maxz mean=$meanz std=$stdvz\n";
	//now do a second pass to build a 3D histogram of vertexes
    $num = count($nodupe);
    for ($i=0;$i<$num;$i+=3)
    {
        $x=$nodupe[$i];
        $y=$nodupe[$i+1];
        $z=$nodupe[$i+2];
        $s = (integer)(4.0*($x-$offx)/$scalex+0.5);
        $t = (integer)(4.0*($y-$offy)/$scaley+0.5);
        $u = (integer)(4.0*($z-$offz)/$scalez+0.5);
        $s = max(0,min(3,$s));     //keep values between 0 and 3
        $t = max(0,min(3,$t));
        $u = max(0,min(3,$u));
//              print "$s $t $u,";
        $v = $s+$t*$VOX+$u*$VOX*$VOX;    //co-ordinate in voxels
        $voxel[$v] += 1;    //count how many vertexes in each
    }
 //   histopic($voxel);
                         //************************************************************
                        //scan the voxels and convvert change in count to bits
    starthash();
    for ($u=0; $u<$VOX; $u++)
    {
        for ($t=0;$t<$VOX;$t++)
        {
            for ($s=0;$s<($VOX-1);$s++)        //short on one axis to calc difference
            {
                $v = $s+$t*$VOX+$u*$VOX*$VOX;    //differences in x
                nexthash($voxel[$v]<$voxel[$v+1]);
                $v = $s*$VOX+$t+$u*$VOX*$VOX;    //differences in y
                nexthash($voxel[$v]<$voxel[$v+$VOX]);
                $v = $s*$VOX*$VOX+$t*$VOX+$u;    //differences in z, interleaved in any consistant order
                nexthash($voxel[$v]<$voxel[$v+$VOX*$VOX]);
            }
        }
    }
    for ($i=0;$i<112;$i++)      //only use 112 bits from this so total is 256
        NextHash($uvmap[$i]);   //fetch them out in any consistent order!
//    print "0x$hash\n";
    return(gethash());       //get the hash
} //end function meshhash

function meshhashID($db,$asset)     //read a mesh by asset UUID and return the perceptual hash
{
    global $fsassets;
//    print "SELECT hash FROM fsassets WHERE id='$asset' AND type=49;\n";
    $res = mysqli_query($db,"SELECT hash FROM fsassets WHERE id='$asset' AND type=49;");
    if (mysqli_num_rows($res)<>1)
        return(false);      //no such asset
    list($hash)=mysqli_fetch_row($res);
    $file = $fsassets.substr($hash,0,2).'/'.substr($hash,2,2).'/'.substr($hash,4,2).'/'.substr($hash,6,4).'/'.$hash.".gz";
    if (($asset=file_get_contents($file))==false)
        return(false);  //cannot read asset
    $meshdata = gzdecode($asset);    //decode it
    if ($meshdata== false)
        return(false);   //exit("cannot decompress asset\n");
    return(meshhash($meshdata));
} //meshhashID
?>

