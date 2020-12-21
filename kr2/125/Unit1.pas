unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Edit2: TEdit;
    Edit3: TEdit;
    Label2: TLabel;
    Label1: TLabel;
    Label3: TLabel;
    Button1: TButton;
    Label4: TLabel;
    Button2: TButton;
    Label5: TLabel;
    Label6: TLabel;
    Label7: TLabel;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
var
  d:real;
  a,b,c:integer;
begin
  a:=StrToInt(Edit1.Text);
  b:=StrToInt(Edit2.Text);
  c:=StrToInt(Edit3.Text);
  d:=b*b-4*a*c;
  if d<0 then
    Label4.Caption:='Решения нет'
  else if d=0 then
    Label4.Caption:='Один корень: x='+ FloatToStr(b/2/a)
  else
    Label4.Caption:='Два корня: x1='+ FloatToStr((b-sqrt(d))/2/a)+', x2='+ FloatToStr((b+sqrt(d))/2/a);
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
Close();
end;

end.
