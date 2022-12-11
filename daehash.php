<?php            //a module for calculating the perceptual hash of a 
                //mesh object in a DAE file
               //a perceptual has is based on the contents and can be compared
              //by "Hamming distance" to other 3D objects.
require("hexhash.php");        //module for building hex hashes
require("STATS.php");       //module for doing statistics

$farr = array();       //each geometry (prim) in a DAE has a pool of vertexes
$voxel = array();       //a place to store a histogram of vertex distribution
$offx=0.0;          //the offset and scale factor to scale all vertexes
$scalex=1.0;        //into a 4x4x4 cube. Calculated by scaleSTAT
$offy=0.0;
$scalez=1.0;
$offz=0.0;
$scaley=1.0;
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

function histopic($hist)	//for debugging: print the histogram of an object
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


//function statvert($vlist)   //common function to sum statistics for triangles or polygons
//{
//    global $farr;
//    $pstr = $vlist->p;
//    global $N;
//    print "$pstr $N\n";
//    $p = preg_split("/[\s,]+/", $pstr);
//	$num=count($p);
//	for ($i=0;$i<$num;$i+=3)	//loop for all the vertexes
//	{
//        $pos=(integer)($p[$i]);
//        $x = (float)$farr[$pos*3];
//        $y = (float)$farr[$pos*3+1];
//        $z = (float)$farr[$pos*3+2];
//        sumSTAT($x,$y,$z);
////            print "($x $y $z),";
//    } //end for all the vertexes in one material
//    return;
//} //statvert

//function histvert($vlist)   //common function to scale vertexes and sum in a histogram
//{
//    global $voxel;
//    global $offx;          //the offset and scale factor to scale all vertexes
//    global $scalex;        //into a 4x4x4 cube. Calculated by scaleSTAT
//    global $offy;
//    global $scalez;
//    global $offz;
//    global $scaley;
//    global $VOX;
//    global $farr;
//    
//    $pstr = $vlist->p;
//    $p = preg_split("/[\s,]+/", $pstr);
//    $num=count($p);
//    for ($i=0;$i<$num;$i+=3)	//loop for all the vertexes
//    {
//        $pos=(integer)($p[$i]);     //fetch the vertex number
//        $x = (float)$farr[$pos*3];    //fetch the x y and z component
//        $y = (float)$farr[$pos*3+1];
//        $z = (float)$farr[$pos*3+2];
//        $s = (integer)((float)$VOX*($x-$offx)/$scalex);   //scale and truncate them
//        $t = (integer)((float)$VOX*($y-$offy)/$scaley);
//        $u = (integer)((float)$VOX*($z-$offz)/$scalez);
//        $s = max(0,min($VOX-1,$s));     //keep values between 0 and 3
//        $t = max(0,min($VOX-1,$t));
//        $u = max(0,min($VOX-1,$u));
////                print "$s $t $u,";
//        $v = $s+$t*$VOX+$u*$VOX*$VOX;    //co-ordinate in voxels
//        $voxel[$v] += 1;    //count how many vertexes in each
//    } //end of all the vertexes
//    return;
//} //histvert

     //****************************************************************
    //daehash calculates a hash of a DAE file that can be compared
    //by Hamming distance to find similar DAE files or mesh
    //This is done by:
    //Quantizing the vectors into 4x4x4 voxels (counts of vertexes in each voxel)
    //Scanning the voxel space for increasing (1) and decreasing (0) complexity (vertex count)
    //Building a small (11x11) bitmap from the UV map(s) 
    //Input:    simplexml handle of one geometry (prim) in the DOM of a DAE file
    //Output:    daehash as a 64 character HEX string (256 bit hash value)
function daehash($geometry)    //calculate the perceptual hash of one prim in a DAE file
{
    global $VOX;    //size of the voxel cube 4x4x4 producing 4x4x3x3 complexity gradiant bits
    global $UVM;    //size of the UV map table, producing 11*11 UVmap bits
            //I only use 112 of the UVmap bits, so the hash comes out 256 bits in size
    global $voxel;
    global $offx;          //the offset and scale factor to scale all vertexes
    global $scalex;        //into a 4x4x4 cube. Calculated by scaleSTAT
    global $offy;
    global $scalez;
    global $offz;
    global $scaley;
    global $farr;
    
         //*****************************
    startSTAT();    //initialize the statistics
    $name = $geometry['name'];
//    print "prim name=$name\n";
    $voxel = array_fill(0,$VOX*$VOX*$VOX,0);     //for storing a 3d histogram of vertex counts
    $uvmap = array_fill(0,$UVM*$UVM,0);   //for storing a UV bitmap
    foreach($geometry->mesh->source as $source)     //find all the data sources for this prim
    {
        $id = $source['id'];
        if (substr($id,-14)=='mesh-positions')      //found the vertices positions
        {
            $float_array = $source->float_array;
//          $count = $float_array['count'];
//                $farr = explode(' ',(string)$float_array);
            $farr = preg_split("/[\s,]+/", $float_array);   //Array of strings
            $num = count($farr);
//            print "vector count $num\n";
	    	//DAE files only have one of these arrays per geometry and multiple materials
	    	//so I only need to do the statisics once
	    for($i=0;$i<$num;$i+=3)
	    {
                $x = (float)$farr[$i];    //fetch the x y and z component
                $y = (float)$farr[$i+1];
                $z = (float)$farr[$i+2];
		sumSTAT($x,$y,$z);
	    }
  //          list($meanx,$stdvx,$meany,$stdvy,$meanz,$stdvz)=stdSTAT();
 //           global $N,$minx,$maxx,$miny,$maxy,$minz,$maxz;
//            print "number of samples $N\n";
//            print "$minx<x<$maxx mean=$meanx std=$stdvx\n";
//            print "$miny<y<$maxy mean=$meany std=$stdvy\n";
//            print "$minz<z<$maxz mean=$meanz std=$stdvz\n";
            list($offx,$scalex,$offy,$scaley,$offz,$scalez)=scaleSTAT(); //get scale factors
	    for ($i=0;$i<$num;$i+=3)    //loop for all the vertexes
            {
                $x = (float)$farr[$i];    //fetch the x y and z component
                $y = (float)$farr[$i+1];
                $z = (float)$farr[$i+2];
                $s = (integer)((float)$VOX*($x-$offx)/$scalex+0.5);   //scale and truncate them
                $t = (integer)((float)$VOX*($y-$offy)/$scaley+0.5);
                $u = (integer)((float)$VOX*($z-$offz)/$scalez+0.5);
                $s = max(0,min($VOX-1,$s));     //keep values between 0 and 3
                $t = max(0,min($VOX-1,$t));
                $u = max(0,min($VOX-1,$u));
//                        print "$s $t $u,";
                $v = $s+$t*$VOX+$u*$VOX*$VOX;    //co-ordinate in voxels
                $voxel[$v] += 1;    //count how many vertexes in each
            } //end of all the vertexes
//	    histopic($voxel);

        }  //end this is the vector position array
        else if (strpos($id,'mesh-map'))   //if this is a UV map
        {
            $float_array = $source->float_array;
//           $count = $float_array['count'];
//              $farr = explode(' ',(string)$float_array);
            $marr = preg_split("/[\s,]+/", $float_array);
            $num=count($marr);
            for ($i=0;$i<$num;$i+=2)      //UV maps are 2D
            {
                $x = (integer)((float)($UVM)*(float)($marr[$i]));
                $y = (integer)((float)($UVM)*(float)($marr[$i+1]));
                $x = max(0,min($x,$UVM-1));    //keep between 0 and 10
                $y = max(0,min($y,$UVM-1));
                $uvmap[$x+$UVM*$y] = 1;       //this location is used
            }  //end of triangles in this material
        } //end of this UV map
    } //end of all the sources
//    uvpic($uvmap,$UVM);
            //instead of looking at the pool of vertexes themselves
           //I look at all the vertexes referenced by the triangle lists
          //of all the materials (faces). This counts some of the vertexes
         //more than once if they are shared by two faces. This is the way
        //Linden Labs LLSD mesh are stored, so this should result in the same statistics
//    foreach($geometry->mesh->triangles as $triangles)     //find all the triangle sets for each material
//    {                                                   //to add vertexes to the statistics
//        statvert($triangles);
//    } //end of all the triangle lists, one per material
//    foreach($geometry->mesh->polylist as $polys)     //do the same thing for polygon lists
//        statvert($polys);                           // add vertexes to the statistics
        

                        //we've seen all the polygons, now calculate the statistics
//    list($meanx,$stdvx,$meany,$stdvy,$meanz,$stdvz)=stdSTAT();
//    global $N,$minx,$maxx,$miny,$maxy,$minz,$maxz;
//    print "number of samples $N\n";
//    print "$minx<x<$maxx mean=$meanx std=$stdvx\n";
//    print "$miny<y<$maxy mean=$meany std=$stdvy\n";
//    print "$minz<z<$maxz mean=$meanz std=$stdvz\n";
//    list($offx,$scalex,$offy,$scaley,$offz,$scalez)=scaleSTAT(); //get scale factors
//    foreach($geometry->mesh->triangles as $triangles)     //find all the triangle sets again
//        histvert($triangles);                            //fetch, scale and histogram them
//    foreach($geometry->mesh->polylist as $polys)     //do the same thing for polygons
//        histvert($polys);

         //************************************************************
        //scan the voxels and convvert change in count to bits
    starthash();
    for ($u=0; $u<$VOX; $u++)
    {
        for ($t=0;$t<$VOX;$t++)
        {
            for ($s=0;$s<$VOX-1;$s++)        //short on one axis to calc difference
            {
                $v = $s+$t*$VOX+$u*$VOX*$VOX;    //differences in x
                nexthash($voxel[$v]<$voxel[$v+1]);
                $v = $s*$VOX+$t+$u*$VOX*$VOX;    //differences in y
                nexthash($voxel[$v]<$voxel[$v+$VOX]);
                $v = $s*$VOX*$VOX+$t*$VOX+$u;    //differences in z
                nexthash($voxel[$v]<$voxel[$v+$VOX*$VOX]);
            }
        }
    }
             //**********************************************
            // convert the UV Map bitmap into a hash
    for ($i=0;$i<112;$i++)      //only use 112 bits from this so total is 256
        NextHash($uvmap[$i]);   //fetch them out in any consistent order!
    return(gethash());            //return the HEX string
} //daehash

        //A DAE file can have multiple geometries (prims)
        //ReadDAE finds all of them, calculates a hash for each of them, and returns them in an array
function ReadDAE($file)        //reads DAE file into XML DOM, calculates hash of each object inside
{
//    print "reading $file\n";
    $ret = array();         //returns a list of hashes
    $data = file_get_contents ( $file);
    if ($data == false)
    {
        print "ERROR, unable to read $file\n";
        return false;
    }
         //****************************************
        //convert DAE in memory string to DOM
    $model = simplexml_load_string($data);      //use simplexml to read DAE XML file
    if ($model==false)
    {
        print "file $file is not a DAE file?\n";
        return(false);
    }
         //*************************************************************
        // convert each prim in the mesh separately and calculate each hash
    foreach($model->library_geometries->geometry as $geometry)
    {
        $name = $geometry['name'];
        $dhash = daehash($geometry);        //calc the hash of this prim (geometry)
        if ($dhash==false)
        {
            print "ERROR, can't calculate hash of prim $name\n";
            return false;
        }
//        print "$name=$dhash\n";
        $ret["$name"]=$dhash;
    }
    return($ret);
} //ReadDAE


?>

