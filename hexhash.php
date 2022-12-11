<?php	//a module (or class) for building hexidecimal hashes of any length


    //globals for the HEXhash calculation
$HEXhash = "";            //hex hash string
$HEXnibble=0;            //bits saved for next hex digit
$HEXbit=1;            //next bit to store

function starthash()
{
    global $HEXhash;
    global $HEXnibble;
    global $HEXbit;

    $HEXhash="";
    $HEXnibble=0;
    $HEXbit=1;
} //stathash

    //nexthash prepends another bit onto the HEXhash.
    //it actually waits until it has 4 bits to add another HEX digit
    //so if you call it with a non-divisible by 4 number of times,
    //send it a few more 0 bits to clean up.
function nexthash($bit)
{
    global $HEXhash;
    global $HEXnibble;
    global $HEXbit;
    if ($bit)                //if the next bit is on
        $HEXnibble |= $HEXbit;    //set it in the result
    $HEXbit <<= 1;            //advance to the next bit
    if ($HEXbit>8)            //if you filled up 4 bits
    {
        $HEXhash = sprintf("%01X", $HEXnibble) . $HEXhash;    //prepend it to the string
        $HEXbit=1;        //start over for next hex digit
        $HEXnibble=0;
    }
} //nexthash

function gethash()	//get the hex hash string
{
    global $HEXhash;
    global $HEXbit;
    while($HEXbit!=1)	//round it up to a nibble
	nexthash(0);	//by filling it with zeros
    return($HEXhash);
} //gethash

function hamhash($str1,$str2)    //hamming distance between two hex strings
{
    static $hex=array(
            '0'=> 0,'1'=> 1,'2'=> 2,'3'=> 3,
            '4'=> 4,'5'=> 5,'6'=> 6,'7'=> 7,
            '8'=> 8,'9'=> 9,'A'=>10,'B'=>11,
            'C'=>12,'D'=>13,'E'=>14,'F'=>15
    );
    static $counts=array(0,1,1,2,1,2,2,3,1,2,2,3,2,3,3,4);
    $count=0;            //count the number of different bits in the two strings
    for ($i=0;$i<strlen($str1);$i++)
        $count += $counts[$hex[substr($str1,$i,1)]^$hex[substr($str2,$i,1)]];
    return($count);
} //hamming


?>
