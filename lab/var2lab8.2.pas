program var2lab82;

var a,b:real;

function max(x,y:real):real;
begin
if(x>y) then max:=x
else max:=y;
end;
function min(x,y:real):real;
begin
if(x<y) then min:=x
else min:=y
end;
begin
readln(a);
readln(b);
writeln(max(a,b)/min(a,b)+min(a,b)/max(a,b):6:2);
readln;
end.