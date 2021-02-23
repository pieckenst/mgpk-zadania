program proceduri;

var arr:array[1..100,1..100] of integer;

procedure dvushka(k:integer;);
 var i,j:byte;
  begin
   randomize;
    for i:=1 to k do
     arr[i]:=random(100);
    for j:= 1 to k do
      arr[j]:=random(100);
    writeln(arr[i,j]);
  end;
)
  
begin
