program massive6;


var a:array[1..15, 1..15] of integer;

var i,j,k,x,n,maxg,maxp:integer;

begin
randomize;
readln(n);
for i:=1 to n do
 begin
   for j:=1 to n do
   begin
    a[i,j]:=random(9);
    write(a[i,j]:5);
   end;
 writeln;
 end;
maxg:=a[1,1];
maxp:=a[1,n];
for i:=1 to n do
 begin
  if a[i,i]>maxg then maxg:=a[i,i];
  if a[i,n-i+1]>maxp then maxp:=a[i,n-i+1];
 end;
writeln(a[i,j]);
writeln('maximum glavnaya diagonal:= ', maxg);
writeln('maximum pobochnaya diagonal:= ',maxp );
readln;
end.