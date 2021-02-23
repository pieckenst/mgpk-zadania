program dvachisla;

var a,b,c,d:integer;
x1,x2: set of byte;
begin
writeln('Vvedite dva chelix chisla');
readln(a,b);
x1:=[];
while a>0 do begin
 x1:=x1+ [a mod 10];
 a:- a div 10;
end;
x2:=[];
while b>0 do begin
 x2:= x2+ [n mod 10];
 b:= b div 10;
end;
if x1<x2=[] then write('V chelix net oboix chisel');
else begin
writeln('Chivri odinakovi');
for d:=0  to 9 do
if d in x1*x2 then write(d: 2);
end;
end.
 