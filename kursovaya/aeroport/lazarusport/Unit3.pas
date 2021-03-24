unit Unit3;

{$IFDEF FPC}
  {$MODE Delphi}
{$ENDIF}

interface
uses StdCtrls, ComCtrls, ExtCtrls, odbcconn,Interfaces,
  Forms,Lresources;

{$IFnDEF FPC}
uses
  System.Classes, System.SysUtils;
{$ELSE}
{$ENDIF}


type
  TDataModule3 = class(TDataModule)
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  DataModule3: TDataModule3;

implementation

{%CLASSGROUP 'Vcl.Controls.TControl'}

{$IFnDEF FPC}
  {$R *.dfm}
{$ELSE}
  {$R *.lfm}
{$ENDIF}

end.
