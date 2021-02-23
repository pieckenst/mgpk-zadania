program zsd2;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

var a,b,c,d ,koren1,koren2:real;
var selector:string;

begin
 writeln('kvadratnoe uravnenie reshaem ) - formuli b^2-4ac , i korni -b + sqrt d / 2a');
 writeln('chitaem a,b,c');
 readln(a,b,c);
 d:=b*b-4*a*c;

 if d <0 then begin
    writeln('discriminant <0 - kornei net');
    sleep(2500);
 end;


 if d=0 then begin
   writeln('discriminant =  0, koren 1');
   koren1:=b+sqrt(d)/2*a;
   writeln(d,koren1);
   sleep(2500);
 end;
 if d>0 then begin
  koren1:=b+sqrt(d)/2*a;
  koren2:=b-sqrt(d)/2*a;
  writeln(d,koren1,koren2);
  sleep(2500);
 end;

end.
