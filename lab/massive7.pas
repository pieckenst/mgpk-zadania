program massive7;

const x=10;

var i,j,count,column:integer;
var a:array[1..x,1..x] of integer;
var b:array[1..x,1..x] of integer;
var mid:real;


begin
randomize;
for i:=1 to x do
 begin
  for j:=1 to x do
   begin
    a[j,i]:=random(100);
    write(a[i,j]:3,' ');
   end;
 writeln;
 end;
for i:=1 to x do
 begin
  for j:=1 to x do
   begin
    b[i,j]:=a[i,j];
   end;
 end;
writeln('Транспонируем');
writeln;
for i:=1 to x do
 begin
  for j:=1 to x do
   begin
    write(b[i,j]:3 , ' ');
   end;
 writeln;
 end;
mid:=0;
mid:= (x*x);
writeln('MID: ', mid);
column:=2;
for i:=1 to x do
 begin
  for j:=1 to x do
   begin
   if(j>=column) and (b[i,j]>mid) then
    inc(count);
   end;
 end;
end.