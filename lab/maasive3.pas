program massive3;
const n:=100;
var a,b,c:array[1..100] of integer;
var i:integer;
var s1,s2,s3:real;
begin
randomize;
s1:=0;
s2:=0;
for i:=1 to n do
begin
a[i]:=-10+random(20);
s1:=s1+a[i];
b[i]:=-10+random(20);
s2:=s2+b[i];
c[i]:=-10+random(20);
s3:=s1+c[i];
end;
writeln('massive a');
for i:=1 to 8 do
write(a[i]:5);
writeln;
writeln('summa elementov massiva a: ',s1);
writeln('massive b');
for i:=1 to 8 do
write(b[i]:5);
writeln;
writeln('summa elementov massiva b: ',s2);
for i:=1 to 8 do
writeln('massive c');
for i:=1 to 8 do
write(c[i]:5);
writeln;
writeln('summa elementov massiva b: ',s3);
end.