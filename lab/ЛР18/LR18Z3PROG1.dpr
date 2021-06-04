program LR18Z3PROG1;

uses
  Vcl.Forms,
  formcaptionunit in 'formcaptionunit.pas' {Form7};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm7, Form7);
  Application.Run;
end.
