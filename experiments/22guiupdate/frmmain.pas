unit frmmain;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.Menus,
  Vcl.TitleBarCtrls, Vcl.Imaging.pngimage, Vcl.ExtCtrls;

type
  TMainfrm = class(TForm)
    Label1: TLabel;
    Panel1: TPanel;
    Image1: TImage;
    Button4: TImage;
    Panel2: TPanel;
    Image2: TImage;
    procedure Button1Click(Sender: TObject);
    procedure Image1Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Image2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Mainfrm: TMainfrm;

implementation

{$R *.dfm}

uses Unit2;

procedure TMainfrm.Button1Click(Sender: TObject);
begin
 Close();
end;



procedure TMainfrm.Button4Click(Sender: TObject);
var A: array [0..99] of integer;
    i,n: integer;
    sum,s: byte;
begin
  AllocConsole;
  try
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

  finally
   sleep(10000);
   FreeConsole;

  end;
end;



procedure TMainfrm.Image1Click(Sender: TObject);
begin
   Close();
end;

procedure TMainfrm.Image2Click(Sender: TObject);
begin
  Unit2.Form2.Show;
end;



end.
