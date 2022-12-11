<?php            //imghash.php
	//a class or module for calculating image perceptual hashes
if (!isset($HEXhash)) require("hexhash.php");
$safename="";	//name of the item
$img;			//only if it is an image
$shaw="";		//sha256 hash of the file
$db="";			//the handle to the database
$title="";		//name of a new item

	//globals for the dhash calculation
$dhash = "";			//hex hash string
$hbits=0;			//bits saved for next hex digit
$nbit=1;			//next bit to store
$xsiz=10;			//size of the reduced image
$ysiz=14;			//10x14 produces a 256 bit dhash

function gray($img,$x,$y)	//returns floating point gray scale value at x,y
{
//	$rgb = imagecolorat($img,$x,$y);
//	$r = ($rgb >> 16) & 0xFF;
//	$g = ($rgb >> 8) & 0xFF;
	//	$b = $rgb & 0xFF;
	$color=$img->getImagePixelColor($x,$y)->getColor();
	$r = $color['r'];
	$g = $color['g'];
	$b = $color['b'];
	return(0.299*$r + 0.587*$g + 0.114*$b);	//NTSC assmptions
} //gray

function hamming($str1,$str2)	//hamming distance between two hex strings
{
    static $hex=array(
            '0'=> 0,'1'=> 1,'2'=> 2,'3'=> 3,
			'4'=> 4,'5'=> 5,'6'=> 6,'7'=> 7,
			'8'=> 8,'9'=> 9,'A'=>10,'B'=>11,
			'C'=>12,'D'=>13,'E'=>14,'F'=>15
    );
	static $counts=array(0,1,1,2,1,2,2,3,1,2,2,3,2,3,3,4);
	$count=0;			//count the number of different bits in the two strings
	for ($i=0;$i<strlen($str1);$i++)
		$count += $counts[$hex[substr($str1,$i,1)]^$hex[substr($str2,$i,1)]];
	return($count);
} //hamming



	//there doesn't seem to be a standard for dhash, as long as I am consistent
    //I can compare my hashes with each other.
	//How to convert to black and white? I used the NTSC assumptions, which returns floats.
	//How to make larger hashes, especially larger than the integer word size?
	//To make a 256 bit version, I'm using a 10x14 image, calculating horizontal and vertical gradients
    // 10*(14-1)+14*(10-1) = 256 bits!
	//Input:	raw image in memory
	//Output:	dhash as a HEX string
function imghash($img)	//calculate the perceptual hash of an imagemagick image
{
    $xsiz=10;                       //size of the reduced image
    $ysiz=14;                       //10x14 produces a 256 bit dhash

    $img->scaleImage($xsiz,$ysiz);	//scale image down
		//convert to gray scale
	$grays = array();
	for ($x=0;$x<$xsiz;$x++)
		for ($y=0;$y<$ysiz;$y++)
			$grays[] = gray($img,$x,$y);
//	var_dump($grays);
	starthash();
	for ($y=0;$y<$ysiz*$xsiz;$y+=$xsiz)		//calculate the horizontal gradients
		for ($x=0;$x<$xsiz-1;$x++)
			nexthash($grays[$y+$x]>$grays[$y+$x+1]);
	for ($x=0;$x<$xsiz;$x+=1)			//calcuate the vertical gradients
		for ($y=0;$y<($ysiz-1)*$xsiz;$y+=$xsiz)
			nexthash($grays[$y+$x]>$grays[$y+$x+$xsiz]);
	return(gethash());			//return the HEX string
} //imghash

function imghashID($db,$asset)     //calculate the image hash given the asset UUID
{
    global $fsassets;
    global $imgdata;
    global $oshash;	
    $res = mysqli_query($db,"SELECT hash FROM fsassets WHERE id='$asset' AND type=0;");
    if (mysqli_num_rows($res)<>1)
    {
	print "No such texture! $asset\n";
	return(false);      //no such asset
    }
    list($hash)=mysqli_fetch_row($res);
    $oshash = $hash;
    $file = $fsassets.substr($hash,0,2).'/'.substr($hash,2,2).'/'.substr($hash,4,2).'/'.substr($hash,6,4).'/'.$hash.".gz";
    if (($asset=file_get_contents($file))==false)
    {
	print "Unble to read image file $file\n";
	return(false);  //cannot read asset
    }
    $imgdata = gzdecode($asset);    //decode it
    if ($imgdata== false)
    {
	print "Unable to decompress image file $file\n";
	return(false);   //exit("cannot decompress asset\n");
    }
    $img = new Imagick();
    try
    {
        $img->readImageBlob($imgdata);
    } catch (ImagickException $e)
    {
        print "unable to convert to image $file\n";
        $img = false;
    }
    if ($img == false)
        return(false);
    $phash=imghash($img);
    $img->destroy();
    return($phash);
} //imghashID

