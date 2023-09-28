<?php 
function test($x) 
{
   if($x <= 4 && $x<=6) {
      return $x;
   }
   if ($x>6){
      $bu = ( 3*$x)+(4*$x*$x);
      return $bu;
   }
   
}

$y= test(7);
echo $y;
?>