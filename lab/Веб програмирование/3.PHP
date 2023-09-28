<?php 
function geron($a, $b, $c){
    $p = ($a + $b + $c) / 2;
    return sqrt($p * ($p - $a) * ($p - $b) * ($p - $c));
}
function circle($l){
   
$s = $l * $l / (4 * M_PI);
return $s;
}
function square($a,$b){
    $s = $a * $b; // находим площадь
return $s; // выводим площадь
}
 
$a = 15;
$b = 4;
$c = 4;
$l = 10;
if (($a > 0) && ($b > 0) && ($c > 0) && (($a < ($b + $c) && ($b < ($a + $c) && ($c < ($a + $b)))))) {
    echo '<div style="color:brown">Площадь треугольника со сторонами ' . $a . ', '. $b . ' и ' . $c .
        ' равна ' . geron($a, $b, $c) . '</div>';
} elseif (($a <= 0) || ($b <= 0) || ($c <= 0)) {
    echo '
<div style="color:brown">Ошибка! <i>Введены недопустимые длины сторон треугольника.</i>
 
<i>Длины сторон должны быть положительными.</i></div>';
} elseif (($a >= ($b + $c) || ($b >= ($a + $c) || ($c >= ($a + $b))))) {
    echo '<div style="color:brown">Треугольник со сторонами ' . $a . ', '. $b . ' и ' . $c . ' не существует!</div>';
}
echo '<div style="color:brown">Площадь круга ' .circle($l). '</div>';
echo '<div style="color:brown">Площадь прямоуголнька ' .square($a,$b). '</div>';
?>