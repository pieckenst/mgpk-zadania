unit vkamenunit;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls;

type
  TForm7 = class(TForm)
    Label1: TLabel;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    procedure Button4Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form7: TForm7;

implementation

{$R *.dfm}

procedure TForm7.Button1Click(Sender: TObject);
begin
Label1.Caption :=('���� ���������');
end;

procedure TForm7.Button2Click(Sender: TObject);
begin
Label1.Caption :=('������� �������');
end;

procedure TForm7.Button3Click(Sender: TObject);
begin
Label1.Caption :=('������ ���������');
end;

procedure TForm7.Button4Click(Sender: TObject);
begin
Application.Terminate;
end;

end.
