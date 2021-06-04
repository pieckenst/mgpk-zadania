program z1v2;
var
i,j,n,maxa,max1,maxb,max2:integer;
a,b:array [1..100,1..100] of byte;
begin
readln(n);
randomize;
writeln('Массив А: ');
for i:=1 to n do
begin
for j:=1 to n do
begin
a[i,j]:=random(100);
if (i=1) and (j=1) then max1:=a[i,j];
if a[i,j]>max1 then max1:=a[i,j];
write(a[i,j]:3);
end;
writeln;
end;
writeln('Массив В: ');
for i:=1 to n do
begin
for j:=1 to n do
begin
b[i,j]:=random(100);
if (i=1) and (j=1) then max2:=b[i,j];
if b[i,j]>max2 then max2:=b[i,j];
write(b[i,j]:3);
end;
writeln;
end;
writeln;
maxa:=a[1,n];
for i:=1 to n do
if a[i,n+1-i]>maxa then maxa:=a[i,n+1-i];
maxb:=b[1,n];
for i:=1 to n do
if b[i,n+1-i]>maxb then maxb:=b[i,n+1-i];
 writeln('Максимальное на побочной диагонали ', maxa, ' и ',maxb);
 writeln('Максимальное в массиве ',max1,' и ',max2);
 if maxa>maxb then writeln('Максимальный элемент в побочной диагонали массива А: ',maxa)
 else writeln('Максимальный элемент в побочной диагонали массива В: ',maxb);
 writeln(' ':(3*2*n+10));
  for i:=1 to n do
  begin
    j:=i;
 begin

 a[i,j]:=max1;
 b[i,j]:=max2;
 end;
 end;
 for i:=1 to n do
 begin
  for j:=1 to n do
  begin
 write (a[i,j]:3);
 end;
 writeln;
 end;
writeln;
  for i:=1 to n do
 begin
 for j:=1 to n do
 begin
   write (b[i,j]:3);
   end;
 writeln;
 end;
 writeln;
 end.



