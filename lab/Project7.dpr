program Project7;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils;

var a,a1:integer;

begin
 writeln('Vvodim a');
 readln(a);
 a1:=a*a*a*a*a*a;
 writeln('a v 6 stepeni =', a1);
 sleep(2500);
    end.
