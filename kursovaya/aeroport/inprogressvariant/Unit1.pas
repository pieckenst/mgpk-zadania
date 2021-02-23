unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.ExtCtrls, Vcl.Imaging.pngimage,
  Vcl.StdCtrls,Unit2,Unit6;

type
  TForm1 = class(TForm)
    Panel1: TPanel;
    Panel2: TPanel;
    Label1: TLabel;
    Panel3: TPanel;
    Panel4: TPanel;
    Panel5: TPanel;
    Panel7: TPanel;
    Image1: TImage;
    procedure Panel3Click(Sender: TObject);
    procedure Panel6Click(Sender: TObject);
    procedure Panel7Click(Sender: TObject);
    procedure Panel5Click(Sender: TObject);



  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

uses Unit5;









procedure TForm1.Panel3Click(Sender: TObject);
begin
form2.show;
end;

procedure TForm1.Panel5Click(Sender: TObject);
begin
Form6.Repaint;
Form6.Show;
Form6.Refresh;

end;

procedure TForm1.Panel6Click(Sender: TObject);
begin
Application.Terminate;
end;

procedure TForm1.Panel7Click(Sender: TObject);
begin
Form5.Show;
end;

end.
