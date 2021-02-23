program massive;

var a: array[1.. 100] of integer;
var i:integer;

begin
randomize;
for i:=1 to 100 do
 a[i] := random(11);
write('Massive: ');
for i:=1 to 100 do
 write(a[i]:4);
writeln;
end.