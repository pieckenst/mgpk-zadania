unit Splashscreen;

{$IFDEF FPC}
  {$MODE Delphi}
{$ENDIF}

interface

uses StdCtrls, ComCtrls, ExtCtrls, odbcconn,Interfaces,
  Forms,Lresources,LCLType, LCLIntf;

{$IFnDEF FPC}
uses
  Vcl.ExtCtrls, Vcl.StdCtrls, Vcl.Dialogs, Vcl.Forms, Vcl.Controls, Vcl.Graphics, System.Classes, System.Variants, System.SysUtils, Winapi.Messages, Winapi.Windows, Vcl.ComCtrls, Vcl.WinXCtrls, ShellAnimations;
{$ELSE}
{$ENDIF}


type
  TfrmSplash = class(TForm)
    Label1: TLabel;
    ProgressBar1: TProgressBar;
    Label2: TLabel;
    Panel1: TPanel;
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmSplash: TfrmSplash;

implementation

{$IFnDEF FPC}
  {$R *.dfm}
{$ELSE}
  {$R *.lfm}
{$ENDIF}

end.
