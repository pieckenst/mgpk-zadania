unit LR2UNITA;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls;

type
  TForm7 = class(TForm)
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Button5: TButton;
    Label1: TLabel;
    Button1: TButton;
    Button6: TButton;
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
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
Application.Terminate;
end;

procedure TForm7.Button2Click(Sender: TObject);
begin
Label1.Font.Size := Label1.Font.Size +2;
end;

procedure TForm7.Button3Click(Sender: TObject);
begin
Label1.Font.Size := Label1.Font.Size -2;
end;

procedure TForm7.Button4Click(Sender: TObject);
begin
Label1.Left := Label1.Left + 10; Label1.Top := Label1.Top + 10;
end;

procedure TForm7.Button5Click(Sender: TObject);
begin
Label1.visible := false;
end;

procedure TForm7.Button6Click(Sender: TObject);
begin
Label1.visible := true;
end;

end.
