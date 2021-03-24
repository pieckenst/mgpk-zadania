unit Mainmenu;

{$IFDEF FPC}
  {$MODE Delphi}
{$ENDIF}

interface


uses
{$IFnDEF FPC}
  Vcl.Imaging.pngimage, Vcl.ExtCtrls, System.SysUtils, Winapi.Windows, Winapi.Messages, System.Variants, System.Classes, Vcl.Graphics, Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.WinXPickers,
{$ELSE}
{$ENDIF}
  StdCtrls, ComCtrls, ExtCtrls, odbcconn,Interfaces,
  Forms,Lresources,LCLType, LCLIntf,AboutProgram,Statistika,EditFlights,Calendar;

type
  TForm1 = class(TForm)
    Panel1: TPanel;
    Label1: TLabel;
    Panel3: TPanel;
    Panel4: TPanel;
    Panel5: TPanel;
    Panel7: TPanel;
    Image1: TImage;
    Panel6: TPanel;
    Panel8: TPanel;
    Image2: TImage;
    procedure Panel3Click(Sender: TObject);
    procedure Panel6Click(Sender: TObject);
    procedure Panel7Click(Sender: TObject);
    procedure Panel5Click(Sender: TObject);
    procedure Panel4Click(Sender: TObject);
    procedure Image1Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Label1DblClick(Sender: TObject);
    procedure Image2Click(Sender: TObject);
    {procedure Label1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure Panel1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);}



  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$IFnDEF FPC}
  {$R *.dfm}
{$ELSE}
  {$R *.lfm}
{$ENDIF}

uses InfoReisy;











procedure TForm1.Button1Click(Sender: TObject);
begin
Form2.Show;
Form8.Show;
Form6.Show;
{Form9.Show;}
Form5.Show;
end;

procedure TForm1.Image1Click(Sender: TObject);
begin
Application.Terminate;
end;

procedure TForm1.Image2Click(Sender: TObject);
begin
Application.Minimize;
end;

procedure TForm1.Label1DblClick(Sender: TObject);
begin
Panel8.Visible:=True;

end;

{procedure TForm1.Label1MouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
ReleaseCapture;
Perform(WM_SysCommand,$F012,0);
end;

procedure TForm1.Panel1MouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
ReleaseCapture;
Perform(WM_SysCommand,$F012,0);
end;}

procedure TForm1.Panel3Click(Sender: TObject);
begin
form2.show;
end;

procedure TForm1.Panel4Click(Sender: TObject);
begin
Form8.Show;
end;

procedure TForm1.Panel5Click(Sender: TObject);
begin
Form6.Repaint;
Form6.Show;
Form6.Refresh;

end;

procedure TForm1.Panel6Click(Sender: TObject);
begin
{Form9.Show;}
end;

procedure TForm1.Panel7Click(Sender: TObject);
begin
Form5.Show;
end;

end.
