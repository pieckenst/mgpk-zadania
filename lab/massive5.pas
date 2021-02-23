program massive5;
const n=100;

var a:array[1..100] of integer;
var i,k,x:integer;

begin
randomize;
readln(k);
for i:=1 to 100 do
begin
a[i]:= random(100);
if a[i]=k then x:=i ;
end;
write('znachenia massiva');
write(a[i]:5);
writeln;

if x =0 then writeln('Net chisla')
else writeln('chislo est , numer = ',x);


end.
