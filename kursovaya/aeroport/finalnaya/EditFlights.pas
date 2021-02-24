unit EditFlights;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.Imaging.pngimage,
  Vcl.ExtCtrls, Data.DB, Data.Win.ADODB;

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
    ADOConnection1: TADOConnection;
    ADOTable1: TADOTable;
    ADOTable1Num: TAutoIncField;
    ADOTable1Datin: TDateTimeField;
    ADOTable1Board_Number: TWideStringField;
    ADOTable1Depart_Time: TDateTimeField;
    ADOTable1First_Class: TIntegerField;
    ADOTable1Second_Class: TIntegerField;
    procedure Label1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure Panel1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure Image1Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form8: TForm8;

implementation

{$R *.dfm}

procedure TForm8.Button1Click(Sender: TObject);
begin
ADOTable1.Open;
ADOTable1.Insert;
ADOTable1.FieldByName('Board_Number').AsString:= Edit1.Text;
ADOTable1.FieldByName('Depart_Time').AsString:=  Edit2.Text;
ADOTable1.FieldByName('First_Class').AsString:=  Edit3.Text;
ADOTable1.FieldByName('Second_Class').AsString:= Edit4.Text;
ADOTable1.FieldByName('Datin').AsString:= Edit5.Text;
ADOTable1.Post;
end;

procedure TForm8.Image1Click(Sender: TObject);
begin
Form8.Close;
end;

procedure TForm8.Label1MouseDown(Sender: TObject; Button: TMouseButton;
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
end;

end.
