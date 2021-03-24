unit ReturnBilet;

{$IFDEF FPC}
  {$MODE Delphi}
{$ENDIF}

interface

uses ComCtrls, odbcconn,Interfaces,Lresources,Messages, SysUtils, Variants, Classes, Graphics,
  Controls, Forms, Dialogs, Menus, StdCtrls, DB,
  DBCtrls, ExtCtrls,LCLType, LCLIntf, DBGrids;

{$IFnDEF FPC}
uses
  Vcl.DBGrids, Vcl.Grids, Data.Win.ADODB, Data.DB, Vcl.StdCtrls, Vcl.Imaging.pngimage, Vcl.ExtCtrls, Vcl.Dialogs, Vcl.Forms, Vcl.Controls, Vcl.Graphics, System.Classes, System.Variants, System.SysUtils, Winapi.Messages, Winapi.Windows;
{$ELSE}
{$ENDIF}


type
  TForm7 = class(TForm)
    Panel1: TPanel;
    Label1: TLabel;
    Image1: TImage;
    DBGrid1: TDBGrid;
    {ADOConnection1: TADOConnection;
    ADOTable1: TADOTable;
    DataSource1: TDataSource;}
    Label2: TLabel;
    Button1: TButton;
    {ADOTable1Num: TAutoIncField;
    ADOTable1Sale_Date: TDateTimeField;
    ADOTable1Board_Number: TWideStringField;
    ADOTable1Class: TWideStringField;}
    procedure Image1Click(Sender: TObject);
    {procedure Panel1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure Label1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);}
    {procedure Button1Click(Sender: TObject);}
    {procedure FormCreate(Sender: TObject);}
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form7: TForm7;

implementation

{$IFnDEF FPC}
  {$R *.dfm}
{$ELSE}
  {$R *.lfm}
{$ENDIF}

{procedure TForm7.Button1Click(Sender: TObject);
begin
ADOTable1.Open;
ADOTable1.Delete;
end;

procedure TForm7.FormCreate(Sender: TObject);
begin
ADOTable1.Open;
end;}

procedure TForm7.Image1Click(Sender: TObject);
begin
Form7.Close;
end;

{procedure TForm7.Label1MouseDown(Sender: TObject; Button: TMouseButton;
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
end;}

end.
