program Airport;

uses
  Forms,System.Sysutils,
  InfoReisy in 'InfoReisy.pas' {Form5},
  Mainmenu in 'Mainmenu.pas' {Form1},
  AboutProgram in 'AboutProgram.pas' {Form2},
  Unit3 in 'Unit3.pas' {DataModule3: TDataModule},
  OknoProdazhi in 'OknoProdazhi.pas' {Form4},
  Statistika in 'Statistika.pas' {Form6},
  ReturnBilet in 'ReturnBilet.pas' {Form7},
  EditFlights in 'EditFlights.pas' {Form8},
  Calendar in 'Calendar.pas' {Form9},
  Splashscreen in 'Splashscreen.pas' {frmSplash};

{$R *.res}

begin
  Application.Initialize;
  Application.Title := 'Aiport Managment';
  frmSplash := TfrmSplash.Create(nil) ;
  frmSplash.Show;
  frmSplash.Update;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm5, Form5);
  while frmSplash.ProgressBar1.Position < 101 do
  begin
    frmSplash.ProgressBar1.Position := frmSplash.ProgressBar1.Position+5;
    Sleep(1500);
  end;
  frmSplash.Hide;
  frmSplash.Free;
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TForm2, Form2);
  Application.CreateForm(TDataModule3, DataModule3);
  Application.CreateForm(TForm4, Form4);
  Application.CreateForm(TForm6, Form6);
  Application.CreateForm(TForm7, Form7);
  Application.CreateForm(TForm8, Form8);
  Application.CreateForm(TForm9, Form9);
  Application.CreateForm(TfrmSplash, frmSplash);
  form1.show;
  Application.Run;
end.
