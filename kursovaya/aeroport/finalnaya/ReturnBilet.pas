unit ReturnBilet;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.ExtCtrls, Vcl.Imaging.pngimage,
  Vcl.StdCtrls, Data.DB, Data.Win.ADODB, Vcl.Grids, Vcl.DBGrids;

type
  TForm7 = class(TForm)
    Panel1: TPanel;
    Label1: TLabel;
    Image1: TImage;
    DBGrid1: TDBGrid;
    ADOConnection1: TADOConnection;
    ADOTable1: TADOTable;
    DataSource1: TDataSource;
    Label2: TLabel;
    Button1: TButton;
    ADOTable1Num: TAutoIncField;
    ADOTable1Sale_Date: TDateTimeField;
    ADOTable1Board_Number: TWideStringField;
    ADOTable1Class: TWideStringField;
    procedure Image1Click(Sender: TObject);
    procedure Panel1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure Label1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure Button1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form7: TForm7;

implementation

{$R *.dfm}

procedure TForm7.Button1Click(Sender: TObject);
begin
ADOTable1.Open;
ADOTable1.Delete;
end;

procedure TForm7.FormCreate(Sender: TObject);
begin
ADOTable1.Open;
end;

procedure TForm7.Image1Click(Sender: TObject);
begin
Form7.Close;
end;

procedure TForm7.Label1MouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
 ReleaseCapture;
Perform(WM_SysCommand,$F012,0);
end;

procedure TForm7.Panel1MouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
ReleaseCapture;
Perform(WM_SysCommand,$F012,0);
end;

end.
