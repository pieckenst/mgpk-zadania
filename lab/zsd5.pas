program zsd5;

var num,limit,sum:real;

begin
  sum:=0;
  writeln('Enter limit');
  readln(limit);
  num:= (limit + 1) /2;
  sum := num* num;
  writeln('Summa nechetnix chisel ot 0 do ', limit, ' ravna ', sum);
  sleep(2500);
end.