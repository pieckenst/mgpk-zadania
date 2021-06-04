program LR18ZD2;

uses
  Vcl.Forms,
  LR2UNITA in 'LR2UNITA.pas' {Form7};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm7, Form7);
  Application.Run;
end.
