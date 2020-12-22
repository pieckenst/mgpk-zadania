program mgpk1;

uses
  Vcl.Forms,
  SysUtils,
  Unit2 in 'Unit2.pas' {Form2},
  Frmsplashscreen in 'Frmsplashscreen.pas' {frmSplash},
  frmmain in 'frmmain.pas' {Mainfrm};

{$R *.res}

begin
  Application.Initialize;
  frmSplash := TfrmSplash.Create(nil) ;
  frmSplash.Show;
  frmSplash.Update;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(Tmainfrm, mainfrm);
  Application.CreateForm(TForm2, Form2);
  // sleep for 3 sec. So that we can see the Splash screen. The same we can use for any process//
  while frmSplash.ProgressBar1.Position < 100 do
  begin
    frmSplash.ProgressBar1.Position := frmSplash.ProgressBar1.Position+20;
    Sleep(6000);
  end;
  frmSplash.Hide;
  frmSplash.Free;
  Application.Run;
end.
