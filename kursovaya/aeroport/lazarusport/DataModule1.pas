unit DataModule1;

interface

uses
  System.SysUtils, System.Classes;

type
  TDataModule1 = class(TDataModule)
  private
    { Private declarations }
  protected
    { Protected declarations }
  public
    { Public declarations }
  published
    { Published declarations }
  end;

procedure Register;

implementation

procedure Register;
begin
  RegisterComponents('Samples', [TDataModule1]);
end;

end.
