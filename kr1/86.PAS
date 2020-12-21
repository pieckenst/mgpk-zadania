Program Z86;
var a,b,c,D:real;
Procedure yrav1(a1,b1,D1:real);
var x1,x2:real;
begin
     x1:=(-b1+sqrt(D1))/(2*a1);
     x2:=(-b1-sqrt(D1))/(2*a1);
     Writeln('Корни квадратного уравнения равны:');
     Writeln('x1=',x1:10:7,' x2=',x2:10:7);
end;
Procedure yrav2(a2,b2:real);
var x1:real;
begin
x1:=(-b2)/(2*a2);
Writeln('В данном случае корни уравнения совпадают, то есть:');
writeln('x1=x2=',x1:10:7);
end;
BEGIN
Writeln('Программа вычисляет корни квадратного уравнения вида ');
writeln('ax*x+b*x+c=0');
write('Введите коэффициент а=');readln(a);
write('Введите коэффициент b=');readln(b);
write('Введите коэффициент c=');readln(c);
D:=sqr(b)-4*a*c;
if (D<0) then writeln('Уравнение не имеет действительных корней');
if (D>0) then yrav1(a,b,D);
if (D=0) then yrav2(a,b);
END.


