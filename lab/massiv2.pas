program massivi21;

var i,j,n:integer;
var a:array[1..100,1..100] of integer;
begin
n:=5;
for i:=1 to n do
begin
for j:=1 to n do
begin
a[i,j]:=7*i-3*j;
write(a[i,j]:5);
end;
writeln;
end;
end.
