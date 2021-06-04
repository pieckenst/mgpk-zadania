program dolbanavtika;

var a:array[1..10, 1..10] of integer;
procedure huita;
var i,j:integer;
begin
for i:=1 to 10 do
for j:=1 to 10 do
a[i,j]:=random(10);
write('random zdelan');
for i:=1 to 10 do begin
for j:=1 to 10 do writeln(a[i,j]);
writeln
end;
end;
begin
huita;
end.