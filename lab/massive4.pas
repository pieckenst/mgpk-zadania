program massive4;
var a:array[1..100] of integer;
var i:integer;


begin
randomize;

for i:=1 to 11 do
begin
a[i]:=random(10);

end;
writeln(a[i]);
end.