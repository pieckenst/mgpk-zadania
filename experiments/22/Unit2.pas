unit Unit2;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls;

type
  TForm2 = class(TForm)
    Label1: TLabel;
    Edit1: TEdit;
    Edit2: TEdit;
    Label2: TLabel;
    Button1: TButton;
    Edit3: TEdit;
    Edit4: TEdit;
    Edit5: TEdit;
    Edit6: TEdit;
    Edit7: TEdit;
    Edit8: TEdit;
    Edit9: TEdit;
    Edit10: TEdit;
    Edit11: TEdit;
    Edit12: TEdit;
    Edit13: TEdit;
    Edit14: TEdit;
    Edit15: TEdit;
    Edit16: TEdit;
    Edit17: TEdit;
    Edit18: TEdit;
    Edit19: TEdit;
    Edit20: TEdit;
    Edit21: TEdit;
    Edit22: TEdit;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form2: TForm2;

implementation

{$R *.dfm}

procedure TForm2.Button1Click(Sender: TObject);
var A: array [0..99] of integer;
    i,n: integer;
    sum,s: byte;
begin
  n:=StrToInt(Edit1.Text);
  for i:=0 to n-1 do
   A[i]:=StrToInt(Edit2.Text);
   A[i]:=StrToInt(Edit11.Text);
   A[i]:=StrToInt(Edit12.Text);
   A[i]:=StrToInt(Edit13.Text);
   A[i]:=StrToInt(Edit14.Text);
   A[i]:=StrToInt(Edit4.Text);
   A[i]:=StrToInt(Edit5.Text);
   A[i]:=StrToInt(Edit6.Text);
   A[i]:=StrToInt(Edit7.Text);
   A[i]:=StrToInt(Edit8.Text);
   A[i]:=StrToInt(Edit9.Text);
   A[i]:=StrToInt(Edit10.Text);
   A[i]:=StrToInt(Edit15.Text);
   A[i]:=StrToInt(Edit16.Text);
   A[i]:=StrToInt(Edit17.Text);
   A[i]:=StrToInt(Edit18.Text);
   A[i]:=StrToInt(Edit19.Text);
   A[i]:=StrToInt(Edit20.Text);
   A[i]:=StrToInt(Edit21.Text);
   A[i]:=StrToInt(Edit22.Text);
   
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
 Edit3.Text:=(IntToStr(sum)); {И какого хуя оно не робит с минусовыми числами? выводя блядский ноль- в консольной версии нормально с этим было}
end;

end.
