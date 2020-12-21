unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    CheckBox1: TCheckBox;
    CheckBox2: TCheckBox;
    CheckBox3: TCheckBox;
    CheckBox4: TCheckBox;
    ComboBox1: TComboBox;
    ComboBox2: TComboBox;
    ComboBox3: TComboBox;
    ComboBox4: TComboBox;
    Label1: TLabel;
    Button1: TButton;
    procedure Button1Click(Sender: TObject);
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
    str:string;
begin
  str:='';
  if CheckBox1.Checked then
    str:=ComboBox1.Items[ComboBox1.ItemIndex]+'; ';
  if CheckBox2.Checked then
    str:=str+ComboBox2.Items[ComboBox2.ItemIndex]+'; ';
  if CheckBox3.Checked then
    str:=str+ComboBox3.Items[ComboBox3.ItemIndex]+'; ';
  if CheckBox4.Checked then
    str:=str+ComboBox4.Items[ComboBox4.ItemIndex];
  Label1.Caption:='Ваш заказ: '+str;
end;

end.
