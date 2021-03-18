unit OknoProdazhi;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.ExtCtrls, Vcl.StdCtrls, Data.DB,
  Data.Win.ADODB, Vcl.Imaging.pngimage,ReturnBilet;

type
  TForm4 = class(TForm)
    Panel1: TPanel;
    RadioButton1: TRadioButton;
    RadioButton2: TRadioButton;
    Button1: TButton;
    Button2: TButton;
    ADOConnection1: TADOConnection;
    ADOTable1: TADOTable;
    ADOTable1Êîä: TAutoIncField;
    ADOTable1Äàòà_Ïðîäàæè: TDateTimeField;
    ADOTable1Íîìåð_Ðåéñà: TWideStringField;
    ADOTable1Êëàññ: TWideStringField;
    Label1: TLabel;
    Edit1: TEdit;
    Label2: TLabel;
    Edit2: TEdit;
    Image1: TImage;
    ADOTable1Num: TAutoIncField;
    ADOTable1Sale_Date: TDateTimeField;
    ADOTable1Board_Number: TWideStringField;
    ADOTable1Class: TWideStringField;
    Label3: TLabel;
    procedure Panel1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure Button1Click(Sender: TObject);
    procedure Image1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Label3MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form4: TForm4;

implementation

{$R *.dfm}

procedure TForm4.Button1Click(Sender: TObject);
begin
if RadioButton1.Checked=true then
  ADOTable1.Open;
  ADOTable1.Insert;
  ADOTable1.FieldByName('Class').AsString:= 'Первый Класс';
  ADOTable1.FieldByName('Board_Number').AsString:=Edit1.Text;
  ADOTable1.FieldByName('Sale_Date').AsString:=Edit2.Text;
  ADOTable1.Post;


if RadioButton2.Checked=true then
  ADOTable1.Open;
  ADOTable1.Insert;
  ADOTable1.FieldByName('Class').AsString:= 'Второй Класс';
  ADOTable1.FieldByName('BBoard_Number').AsString:=Edit1.Text;
  ADOTable1.FieldByName('Sale_Date').AsString:=Edit2.Text;
  ADOTable1.Post;


end;

procedure TForm4.Button2Click(Sender: TObject);
begin
Form7.Show;
end;

procedure TForm4.Image1Click(Sender: TObject);
begin
Form4.Close;
end;

procedure TForm4.Label3MouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
ReleaseCapture;
Perform(WM_SysCommand,$F012,0);
end;

procedure TForm4.Panel1MouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
ReleaseCapture;
Perform(WM_SysCommand,$F012,0);
end;

end.
