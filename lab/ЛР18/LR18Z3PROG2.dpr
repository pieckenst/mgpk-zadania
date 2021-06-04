program LR18Z3PROG2;

uses
  Vcl.Forms,
  vkamenunit in 'vkamenunit.pas' {Form7};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm7, Form7);
  Application.Run;
end.
