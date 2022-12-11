<?php	//	A module (or a class) for reading LLSD files

$LLSDdata ="";
$LLSDpos = 0;

function startLLSD($blob)
{
        global $LLSDdata;
        global $LLSDpos;
	$LLSDdata = $blob;		//record the LLSD data blob
	$LLSDpos=0;
}

function getLLSDchar()
{
    global $LLSDdata;
    global $LLSDpos;
	return(substr($LLSDdata,$LLSDpos++,1));	//get one character
}

function getLLSDsbint2()     //get a signed 16bit integer from an LLSD stream
{
        global $LLSDdata;
        global $LLSDpos;
        $arr=unpack("n",substr($LLSDdata,$LLSDpos,2));
        $LLSDpos += 2;
        $val = $arr[1];
        if (($val&0x8000)!=0)       //if it was supposed to be negatife
                $val |=0xFFFFFFFFFFFF0000;      //sign extend it
        return($val);
} //getflt8


function getflt8()
{
        global $LLSDdata;
        global $LLSDpos;
        $arr=unpack("E",substr($LLSDdata,$LLSDpos,8));
        $LLSDpos += 8;
        return($arr[1]);
} //getflt8

function getint4()
{
        global $LLSDdata;
        global $LLSDpos;
        $arr=unpack("N",substr($LLSDdata,$LLSDpos,4));
        $LLSDpos += 4;
        return($arr[1]);
} //getint4

function getLLSDint8()
{
        global $LLSDdata;
        global $LLSDpos;
        $arr=unpack("J",substr($LLSDdata,$LLSDpos,8));
        $LLSDpos += 8;
        return($arr[1]);
} //getint4

function getLLSDuint2() //get an unsigned 16bit integer
{
        global $LLSDdata;
        global $LLSDpos;
        $arr=unpack("n",substr($LLSDdata,$LLSDpos,2));
        $LLSDpos += 2;
        return($arr[1]);
} //getint2

function getLLSDulint2() //get an unsigned 16bit little endian integer
{
        global $LLSDdata;
        global $LLSDpos;
        $arr=unpack("v",substr($LLSDdata,$LLSDpos,2));
        $LLSDpos += 2;
        return($arr[1]);
} //getint2

function getLLSDpos()
{
    global $LLSDpos;
	return($LLSDpos);
}

function setLLSDpos($del)
{
    global $LLSDpos;
	$LLSDpos += $del;
}

        //return a section of the LLSD from memory
function getLLSDblob($size)
{
	global $LLSDdata;
	global $LLSDpos;
	$blob = substr($LLSDdata,$LLSDpos,$size);
	$LLSDpos += $size;
	return($blob);
}

$LLSDstack=0;

function nextLLSD()        //get next token from llsd blob
{
    global $LLSDdata;
    global $LLSDpos;
    global $LLSDstack;
    $ret=array();   //returns an array
    $type='undef';
    while($LLSDpos<strlen($LLSDdata))
    {
        $type = getLLSDchar();      //next byte should be a character
        if (!isset($type))
            $type='undef';
       if ($type=='{' || $type=='[')     //start named list or unnamed list
        {
            $size = getint4();   //has a count of objects (ignored, wait for '}' or ']')
	    $LLSDstack+=1;
	    continue;
        } 
        else if ($type==']' || $type=='}')     //end of list
        {
            $LLSDstack -=1;
            if ($LLSDstack==0)          //return false at end of blob
                return(false);
            continue;
        }
        else if ($type=='k' || $type=='s')		//if it is an item name
    	{
            $len=getint4();      //has a length field
            $ret['name']=substr($LLSDdata,$LLSDpos,$len);
            $LLSDpos += $len;
            break;
        }
        else if ($type == 'b')
        {
            $ret['size'] = getint4();	//how many bytes of binary
            break;
        }
        else if ($type == 'i')
        {
            $ret['value']= getint4();
            break;
        }
        else if ($type == 'r')
        {
            $ret['value']= getflt8();	//get a real number
            break;
        }
        else if ($type == 'u')		//UUID
        {
            $ret['value']=getLLSDblob(16);	//always 16bytes big
            break;
        }
        else if ($type == 'd')
        {
            $ret['value']=getLLSDint8();
            break;
        }
        else if ($type == '1')
        {
            $ret['value']='true';
            break;
        }
        else        //unknown type
        {
            print "Unknown LLSD type $type at loctation $LLSDpos\n";
            return(false);
        }
    } //while loop for climbing up and down the tree structure
    $ret['type']=$type;
    $ret['depth']=$LLSDstack;   //depth into the tree structure of the data
    return($ret);
} //nextLLSD();
?>

