program Airport;

uses
  Forms,
  InfoReisy in 'InfoReisy.pas' {Form5},
  Mainmenu in 'Mainmenu.pas' {Form1},
  AboutProgram in 'AboutProgram.pas' {Form2},
  Unit3 in 'Unit3.pas' {DataModule3: TDataModule},
  OknoProdazhi in 'OknoProdazhi.pas' {Form4},
  Statistika in 'Statistika.pas' {Form6},
  ReturnBilet in 'ReturnBilet.pas' {Form7},
  EditFlights in 'EditFlights.pas' {Form8},
  Calendar in 'Calendar.pas' {Form9};

{$R *.res}

begin
  Application.Initialize;
  Application.Title := 'Aiport Managment';
  Application.CreateForm(TForm5, Form5);
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TForm2, Form2);
  Application.CreateForm(TDataModule3, DataModule3);
  Application.CreateForm(TForm4, Form4);
  Application.CreateForm(TForm6, Form6);
  Application.CreateForm(TForm7, Form7);
  Application.CreateForm(TForm8, Form8);
  Application.CreateForm(TForm9, Form9);
  form1.show;
  Application.Run;
end.
