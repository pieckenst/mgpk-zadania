program lab9v1;

type mas=array[1..20] of integer;
procedure massiv(var a:mas;var n,sm:integer;s:string);
var i:integer;
begin
repeat
write('vvedite razmer massiva ot 2 do 20 n=');
readln(n);
until n in [2..20];
writeln(s);
sm:=0;
for i:=1 to n do
 begin
  a[i]:=random(20);
  write(a[i]:3);
  inc(sm,a[i]);
 end;
writeln;
writeln('?????=',sm)
end;

var a,b,c:mas;
    na,nb,nc,sa,sb,sc,mx:integer;
    ch:char;
begin
massiv(a,na,sa,'?????? ?');
massiv(b,nb,sb,'?????? ?');
massiv(c,nc,sc,'?????? ?');
if sa>sb then
 begin
  mx:=sa;
  ch:='A';
 end
else
 begin
  mx:=sb;
  ch:='B';
 end;
if sc>mx then
 begin
  mx:=sc;
  ch:='C';
 end;
writeln('?????????? ?????=',mx,' ? ??????? ',ch);
end.