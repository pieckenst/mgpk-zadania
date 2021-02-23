program zsd3;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils,
  math;

var stepen:integer;
var a:integer;



begin  a:=2;
  writeln('Vvedi stepen');
  readln(stepen);
  if stepen mod 4=1 then writeln('2 v stepeni ', stepen ,' okantshivaetsa numerom 2 ')
  else if stepen mod 4=2 then writeln('2 v stepeni ', stepen ,' okantshivaetsa numerom 4 ')
  else if stepen mod 4=3 then writeln('2 v stepeni ', stepen ,' okantshivaetsa numerom 8 ')
  else if stepen mod 4=0 then writeln('2 v stepeni ', stepen ,' okantshivaetsa numerom 6 ')
  else if stepen=0 then writeln('2 v stepeni ', stepen ,' okantshivaetsa numerom 1 ');


end.
