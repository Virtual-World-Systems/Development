<?php	//module to do statistics on 3d vectors

$N=0.0;    //statistics for the standard deviation
$meanx=0.0;
$sumx2=0.0;
$meany=0.0;
$sumy2=0.0;
$meanz=0.0;
$sumz2=0.0;
$maxx=-1e6;     //stats for the bounding box
$minx= 1e6;
$maxy=-1e6;
$miny= 1e6;
$maxz=-1e6;
$minz= 1e6;

function startSTAT()     //initialize the statistics
{
    global $N; 
    global $meanx;  //stats for the standard deviation
    global $sumx2;
    global $meany;
    global $sumy2;
    global $meanz;
    global $sumz2;
    global $maxx;     //stats for the bounding box
    global $minx;
    global $maxy;
    global $miny;
    global $maxz;
    global $minz;
    $N=0.0;    //initialize the statistics for the standard deviation
    $meanx=0.0;
    $sumx2=0.0;
    $meany=0.0;
    $sumy2=0.0;
    $meanz=0.0;
    $sumz2=0.0;
    $maxx=-1e6;     //stats for the bounding box
    $minx= 1e6;
    $maxy=-1e6;
    $miny= 1e6;
    $maxz=-1e6;
    $minz= 1e6;
    return;
}
function sumSTAT($x,$y,$z)   //sum one more vertex into the statistics
{
    global $N; 
    global $meanx;  //stats for the standard deviation
    global $sumx2;
    global $meany;
    global $sumy2;
    global $meanz;
    global $sumz2;
    global $maxx;     //stats for the bounding box
    global $minx;
    global $maxy;
    global $miny;
    global $maxz;
    global $minz;
                        //Welford's method to calculate variance in one pass
    $N += 1.0;      //sample numer
    $om = $meanx;    //calculate the varience
    $meanx += ($x-$meanx)/$N;
    $sumx2 += ($x-$meanx)*($x-$om);
    $om = $meany;
    $meany += ($y-$meany)/$N;
    $sumy2 += ($y-$meany)*($y-$om);
    $om = $meanz;
    $meanz += ($z-$meanz)/$N;
    $sumz2 += ($z-$meanz)*($z-$om);
    $maxx=max($maxx,$x);    //sum up the bounding box
    $minx=min($minx,$x);
    $maxy=max($maxy,$y);
    $miny=min($miny,$y);
    $maxz=max($maxz,$z);
    $minz=min($minz,$z);
    return;
} //sumSTAT

function boundSTAT()   //return bounding box from the statistics
{
    global $maxx;     //stats for the bounding box
    global $minx;
    global $maxy;
    global $miny;
    global $maxz;
    global $minz;
    return(array($minx,$maxx,$miny,$maxy,$minz,$maxz));
} //boundSTAT   

function scaleSTAT()   //return scaling factors from the statistics
{
    global $maxx;     //stats for the bounding box
    global $minx;
    global $maxy;
    global $miny;
    global $maxz;
    global $minz;
    $scalex = $maxx-$minx;    //convert max to the scalor
    if ($scalex<1.0e-6)      //if it is small
        $scalex=1.0;        //then change it now to avoid divide by zero
    $scaley = $maxy-$miny;    //ditto for y
    if ($scaley<1.0e-6)
        $scaley=1.0;
    $scalez = $maxz-$minz;        //ditto for z
    if ($scalez<1.0e-6)
        $scalez=1.0;
    return(array($minx,$scalex,$miny,$scaley,$minz,$scalez));
} //boundSTAT   

function stdSTAT()   //return mean and standard deviation from the statistics
{
    global $N; 
    global $meanx;  //stats for the standard deviation
    global $sumx2;
    global $meany;
    global $sumy2;
    global $meanz;
    global $sumz2;
    if ($N<=1.0)     //there is not enough data yet
        return(false);
    return(array(
        $meanx/$N,sqrt($sumx2/($N-1.0)),
        $meany/$N,sqrt($sumy2/($N-1.0)),
        $meanz/$N,sqrt($sumz2/($N-1.0))
    ));
} //stdSTAT


?>

