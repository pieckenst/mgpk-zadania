unit EditFlights;

{$IFDEF FPC}
  {$MODE Delphi}
{$ENDIF}

interface

uses StdCtrls, ComCtrls, ExtCtrls, odbcconn,Interfaces,
  Forms,Lresources,LCLType, LCLIntf;

{$IFnDEF FPC}
uses
  Data.Win.ADODB, Data.DB, Vcl.ExtCtrls, Vcl.Imaging.pngimage, Vcl.StdCtrls, Vcl.Dialogs, Vcl.Forms, Vcl.Controls, Vcl.Graphics, System.Classes, System.Variants, System.SysUtils, Winapi.Messages, Winapi.Windows;
{$ELSE}
{$ENDIF}


type
  TForm8 = class(TForm)
    Panel1: TPanel;
    Image1: TImage;
    Label1: TLabel;
    Label2: TLabel;
    Edit1: TEdit;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    Edit2: TEdit;
    Edit3: TEdit;
    Edit4: TEdit;
    Edit5: TEdit;
    Label6: TLabel;
    Button1: TButton;
    {ADOConnection1: TADOConnection;
    ADOTable1: TADOTable;
    ADOTable1Num: TAutoIncField;
    ADOTable1Datin: TDateTimeField;
    ADOTable1Board_Number: TWideStringField;
    ADOTable1Depart_Time: TDateTimeField;
    ADOTable1First_Class: TIntegerField;
    ADOTable1Second_Class: TIntegerField;}
    {procedure Label1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure Panel1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);}
    procedure Image1Click(Sender: TObject);
    {procedure Button1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);}
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form8: TForm8;

implementation

{$IFnDEF FPC}
  {$R *.dfm}
{$ELSE}
  {$R *.lfm}
{$ENDIF}

{procedure TForm8.Button1Click(Sender: TObject);
begin
if (Trim(Edit1.Text) <> '') and (Trim(Edit2.Text) <> '') and (Trim(Edit3.Text) <> '')and (Trim(Edit5.Text) <> '') then begin
  ADOTable1.Open;
  ADOTable1.Insert;
  ADOTable1.FieldByName('Board_Number').AsString:= Edit1.Text;
  ADOTable1.FieldByName('Depart_Time').AsString:=  Edit2.Text;
  ADOTable1.FieldByName('First_Class').AsString:=  Edit3.Text;
  ADOTable1.FieldByName('Second_Class').AsString:= Edit4.Text;
  ADOTable1.FieldByName('Datin').AsString:= Edit5.Text;
  ADOTable1.Post;
end;

if (Edit1.Text = '') and (Edit2.Text = '') and (Edit3.Text = '') and (Edit4.Text = '') and (Edit5.Text = '') then begin
  showmessage('Отсутствует Ввод Данных!');
end;
if (Edit1.Text = '')then begin
  showmessage('Данные введены не полностью!');
end;
if (Edit1.Text = '') and (Edit2.Text = '') then begin
  showmessage('Данные введены не полностью!');
end;
if (Edit1.Text = '') and (Edit2.Text = '') and (Edit3.Text = '') then begin
  showmessage('Данные введены не полностью!');
end;
if (Edit1.Text = '') and (Edit2.Text = '') and (Edit3.Text = '') and (Edit4.Text = '') then begin
  showmessage('Данные введены не полностью!');
end;




end;}

{procedure TForm8.FormCreate(Sender: TObject);
begin
ADOTable1.Open;
end;}

procedure TForm8.Image1Click(Sender: TObject);
begin
Form8.Close;
end;

{procedure TForm8.Label1MouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
ReleaseCapture;
Perform(WM_SysCommand,$F012,0);
end;

procedure TForm8.Panel1MouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
ReleaseCapture;
Perform(WM_SysCommand,$F012,0);
end;}

end.
