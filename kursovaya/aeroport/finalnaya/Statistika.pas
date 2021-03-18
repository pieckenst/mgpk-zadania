unit Statistika;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.DB, Vcl.Grids, Vcl.DBGrids,
  Vcl.ExtCtrls, Vcl.StdCtrls, Data.Win.ADODB, Vcl.Imaging.pngimage;

type
  TForm6 = class(TForm)
    Panel1: TPanel;
    DBGrid1: TDBGrid;
    DataSource1: TDataSource;
    ADOConnection1: TADOConnection;
    ADOTable1: TADOTable;
    ADOTable1Код: TAutoIncField;
    ADOTable1Дата_Продажи: TDateTimeField;
    ADOTable1Номер_Рейса: TWideStringField;
    ADOTable1Класс: TWideStringField;
    Label1: TLabel;
    Image1: TImage;
    Image2: TImage;
    ADOTable1Num: TAutoIncField;
    ADOTable1Sale_Date: TDateTimeField;
    ADOTable1Board_Number: TWideStringField;
    ADOTable1Class: TWideStringField;
    procedure FormCreate(Sender: TObject);
    procedure Image1Click(Sender: TObject);
    procedure Panel1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure Image2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form6: TForm6;

implementation

{$R *.dfm}

procedure TForm6.FormCreate(Sender: TObject);
begin
ADOTable1.Open;
end;

procedure TForm6.Image1Click(Sender: TObject);
begin
Form6.Close;
end;

procedure TForm6.Image2Click(Sender: TObject);
begin
Form6.Refresh;
Form6.Repaint;
ADOTable1.Open;
ADOTable1.Refresh;
DBGrid1.Refresh;
DBGrid1.Repaint;
end;

procedure TForm6.Panel1MouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
ReleaseCapture;
Perform(WM_SysCommand,$F012,0);
end;

end.
