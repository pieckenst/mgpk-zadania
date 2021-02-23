program zsd1;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

var a,a1,resul:real;

begin
  writeln('Vvodim a i a1');
  readln(a, a1);
  if (a < a1) then begin
     resul:=a;
     a:=(a1+a)/2;
     a1:=a*a1;
  end;
  if (a>=a1) then begin
     resul:=a;
     a:=(a1+a)/2;
     a1:=a*a1;
  end;
  writeln('Rezultat = ', a, ' ', a1);
  sleep(3500);
end.
