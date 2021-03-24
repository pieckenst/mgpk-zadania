unit InfoReisy;

{$IFDEF FPC}
  {$MODE Delphi}
{$ENDIF}

interface

uses
{$IFnDEF FPC}
  Vcl.Mask, Vcl.ExtCtrls, System.Win.TaskbarCore, Vcl.Taskbar, Vcl.Imaging.pngimage, Vcl.Grids, Vcl.DBGrids, ADODB, Windows,
{$ELSE}
  sqldb, odbcconn, LMessages,
{$ENDIF}
  Messages, SysUtils, Variants, Classes, Graphics,
  Controls, Forms, Dialogs, Menus, StdCtrls, DB,
  DBCtrls, ExtCtrls, DBGrids,LCLType, LCLIntf,
  OknoProdazhi;

type

  { TForm5 }

  TForm5 = class(TForm)
    Label2: TLabel;
    edDate: TEdit;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    Label6: TLabel;
    {ADOTable1: TSQLQuery;
    ADOQuery1: TSQLQuery;
    ADOTable1Num: TAutoIncField;
    ADOTable1Datin: TDateTimeField;
    ADOTable1Board_Number: TWideStringField;
    ADOTable1Depart_Time: TDateTimeField;
    ADOTable1First_Class: TIntegerField;
    ADOTable1Second_Class: TIntegerField;}
    dbeTime: TDBEdit;
    dbeClass1: TDBEdit;
    dbeClass2: TDBEdit;
    ODBCConnection1: TODBCConnection;
    Panel1: TPanel;
    Image1: TImage;
    DataSource1: TDataSource;
    DBGrid1: TDBGrid;
    cmbNumber: TDBComboBox;
    ADOConnection1: TSQLConnector;
    bttProdaga: TImage;
    Label1: TLabel;
    Label7: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure cmbNumberDropDown(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure ODBCConnection1AfterConnect(Sender: TObject);
    {procedure Panel1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);}
    procedure Image1Click(Sender: TObject);
    procedure bttProdagaClick(Sender: TObject);
    {procedure Label7MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure Label1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);}




  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form5: TForm5;

implementation

{$IFnDEF FPC}
  {$R *.dfm}
{$ELSE}
  {$R *.lfm}
{$ENDIF}




procedure TForm5.FormCreate(Sender: TObject);

var d: tdatetime;
begin
   d:=date;
   edDate.Text:=datetostr(d);
   {ADOTable1.Open;}

end;

procedure TForm5.cmbNumberDropDown(Sender: TObject);
begin

end;






procedure TForm5.Image1Click(Sender: TObject);
begin
Form5.Hide;
end;

{procedure TForm5.Label1MouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
ReleaseCapture;
Perform(WM_SysCommand,$F012,0);
end;}

{procedure TForm5.Label7MouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
ReleaseCapture;
Perform(WM_SysCommand,$F012,0);
end;

procedure TForm5.Panel1MouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
ReleaseCapture;
Perform(WM_SysCommand,$F012,0);
end;}

procedure TForm5.bttProdagaClick(Sender: TObject);
begin
Form4.Show;
end;

procedure TForm5.Button1Click(Sender: TObject);
begin
Close;
end;

procedure TForm5.ODBCConnection1AfterConnect(Sender: TObject);
begin

end;

{procedure TForm5.cmbNumberDropDown(Sender: TObject);
begin
ADOTable1.Open;
ADOTable1.First;
while not ADOTable1.Eof do
  begin
   cmbNumber.Items.Add(AdoTable1.FieldByName('Board_Number').AsString);
   ADOTable1.Next;
  end;
end;}








end.
