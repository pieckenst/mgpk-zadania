program n22;
uses crt;
var A: array [0..99] of integer;
    i,n: integer;
    sum,s: byte;
begin
 writeln('Vvedite n');
 readln(n);
 writeln('Vvedite chisla');
 for i:=0 to n-1 do
  readln(A[i]);
 sum:=0;
 s:=0;
 for i:=0 to n-1 do begin
  if A[i]>0 then
   begin
    s:=s+1;
    if s>sum then sum:=s;
   end
  else s:=0;
 end;
 writeln('sum=',sum);
repeat until keypressed;
end.