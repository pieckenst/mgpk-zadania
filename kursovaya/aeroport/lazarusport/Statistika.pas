unit Statistika;

{$IFDEF FPC}
  {$MODE Delphi}
{$ENDIF}

interface

uses ComCtrls, odbcconn,Interfaces,Lresources,Messages, SysUtils, Variants, Classes, Graphics,
  Controls, Forms, Dialogs, Menus, StdCtrls, DB,
  DBCtrls, ExtCtrls, DBGrids,LCLType, LCLIntf;

{$IFnDEF FPC}
uses
  Vcl.Imaging.pngimage, Data.Win.ADODB, Vcl.StdCtrls, Vcl.ExtCtrls, Vcl.DBGrids, Vcl.Grids, Data.DB, Vcl.Dialogs, Vcl.Forms, Vcl.Controls, Vcl.Graphics, System.Classes, System.Variants, System.SysUtils, Winapi.Messages, Winapi.Windows;
{$ELSE}
{$ENDIF}


type
  TForm6 = class(TForm)
    Panel1: TPanel;
    DBGrid1: TDBGrid;
    DataSource1: TDataSource;

    Label1: TLabel;
    Image1: TImage;
    Image2: TImage;
    {procedure FormCreate(Sender: TObject);
    procedure Image1Click(Sender: TObject);}
    {procedure Panel1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);}
    {procedure Image2Click(Sender: TObject);}
    {procedure Label1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);}
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form6: TForm6;

implementation

{$IFnDEF FPC}
  {$R *.dfm}
{$ELSE}
  {$R *.lfm}
{$ENDIF}

{procedure TForm6.FormCreate(Sender: TObject);
begin
ADOTable1.Open;
end;

procedure TForm6.Image1Click(Sender: TObject);
begin
DBGrid1.DataSource.DataSet.Refresh;
Form6.Close;
end;}

{procedure TForm6.Image2Click(Sender: TObject);
begin
Form6.Refresh;
Form6.Repaint;
ADOTable1.Open;
ADOTable1.Refresh;
DBGrid1.DataSource.DataSet.Refresh;
DBGrid1.Refresh;
DBGrid1.Repaint;
end;}

{procedure TForm6.Label1MouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
ReleaseCapture;
Perform(WM_SysCommand,$F012,0);
end;

procedure TForm6.Panel1MouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
ReleaseCapture;
Perform(WM_SysCommand,$F012,0);
end;}

end.
