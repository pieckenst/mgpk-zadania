program chisla;

var a: array[1 .. 20] of real;
var i:integer;
var max:real;

begin
writeln('Vvedi chisla');
for i:=1 to 20 do read(a[i]);
max:=a[i];
for i:=2 to 20 do
 if max<a[i] then max:=a[i];
writeln;write('Naibolshee',max);
end.

