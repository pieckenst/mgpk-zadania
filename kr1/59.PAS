program n59;
uses crt;
var X: array [0..6,0..6] of integer;
    i,j: integer;
begin
 for j:=0 to 6 do
  for i:=0 to 6 do
   if i=j then X[i,j]:=1
    else
     if i>j then X[i,j]:=i+j
     else X[i,j]:=i-j;
repeat until keypressed;
end.