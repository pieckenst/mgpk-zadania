program slova;
uses crt;
var slovo1,slovo2,slovo3:string;
symbols:array[1..33] of string;
alfavit:string;
i:integer;


begin
clrscr;
alfavit:='abcdefghijklmnopqrstuvwxyz';
writeln('vvedi 1 slovo');
readln(slovo1);
writeln('vvedi 2 slovo');
readln(slovo2);
writeln('vvedi 3 slovo');
readln(slovo3);
clrscr;

for i:=1 to 33 do
symbols[i]:=alfavit[i];

for i:=1 to 33 do
    begin
    if symbols[i]=slovo1[1] then writeln(slovo1);{n1:=i;}
    if symbols[i]=slovo2[1] then writeln(slovo2);{n2:=i;}
    if symbols[i]=slovo3[1] then writeln(slovo3);{n3:=i;}
    end;
end.