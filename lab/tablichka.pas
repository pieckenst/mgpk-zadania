program tablichkaumnozhenia;

var i,j:integer;

begin
for I:= 1 to 10 do begin
 for j:=1 to 5 do
  write(i:2 , ' x ', j:2 , ' = ', i*j:3 , '  ');
  writeln
 end;
writeln;
for I:= 1 to 10 do begin
 for J:=6 to 10 do
  write(i:2 , ' x ', j:2 , ' = ', i*j:3 , '  ');
  writeln;
 end;
end.