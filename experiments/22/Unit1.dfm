object Form1: TForm1
  Left = 0
  Top = 0
  BorderIcons = [biMinimize, biMaximize]
  BorderStyle = bsToolWindow
  Caption = 'Test form App'
  ClientHeight = 156
  ClientWidth = 481
  Color = 3487029
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 24
    Top = 32
    Width = 417
    Height = 26
    Caption = 'Welcome to delphi forms how may we help ya'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWhite
    Font.Height = -20
    Font.Name = 'Trebuchet MS'
    Font.Style = []
    ParentFont = False
  end
  object Button1: TButton
    Left = 24
    Top = 72
    Width = 177
    Height = 49
    BiDiMode = bdRightToLeft
    Caption = 'Tell to fuck off'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWhite
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentBiDiMode = False
    ParentFont = False
    TabOrder = 0
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 336
    Top = 128
    Width = 137
    Height = 20
    Caption = 'Calculate math for me'
    TabOrder = 1
    OnClick = Button2Click
  end
end
