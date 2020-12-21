Program Two;
uses crt;
const
x1=[1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20];
x2=[10,20,30];
x3=[1,3,5,7,9,11,13,15,17,19,21];
var
y,y1:set of byte;
i,j:integer;
!\
begin
clrscr;
y:=(x1*x2)*(x1-x3)*(x2-x3);
for i:=1 to 255 do
if i in y then
writeln(i);
writeln;
j:=0;
for i:=1 to 255 do
if (i in y) and (i mod 4=0) then
begin
j:=j+1;
end;
writeln('KOL-VO DELIASCHIHSIA NA 4 = ',j);
end. \\