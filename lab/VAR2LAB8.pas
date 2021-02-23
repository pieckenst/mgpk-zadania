program kusokgovnasiuma;

var a,b,c,sumab,sumac:integer;

begin
readln(a);
readln(b);
readln(c);
sumab:=a+b;
sumac:=a+c;
if sumab>sumac then
writeln('SUMAB BOLSHE: ',sumab)
else
write('SUMAC BOLSHE: ',sumac);
end.

