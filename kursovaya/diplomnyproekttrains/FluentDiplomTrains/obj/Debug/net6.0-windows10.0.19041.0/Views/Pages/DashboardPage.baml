   M S B A M L   `   `   `  ����S  OFluentKursovayaAvtoparkA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:FluentKursovayaAvtoparkA.Views.Pages$FluentKursovayaAvtoparkA.Views.Pages  5      8    2FluentKursovayaAvtoparkA.Views.Pages.DashboardPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:FluentKursovayaAvtoparkA.Views.Pages     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      A =Wpf.Ui, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5        N� Title$  DashboardPage��5         TextFillColorPrimaryBrush N� 
Foreground# �   5      .��5      � $
��56,0q�6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	dataGrid1��5   �     ApplicationBackgroundBrush#���  6O   $��10,14,10,562q�6�   $	��175��6�   ��6   *  $Wpf.Ui.Markup.ThemeResourceExtension  *TextFillColorSecondaryBrush+5        Wpf.Ui.Controls.Button  5   
   -   5          Name$ XdbSend��5      $-��'Отправить данные в БД��6%   $��574,254,0,0q�6E   $	��Top=�6Z   $��40��5      $	��253��6   6)     5   
   -   5        $ 
UpdateGrid��5      $��Обновить DataGrid��6(   $��574,359,0,0q�6D   $	��Top=�6Y   $	��253��6q   $��40��5   *   �� 5   
   -   5         ��Name$ Labos1��5      $��Ключ(Num)��6$   $
��Left=�65   $��
14,265,0,0q�6P   $	��Top=�6d   �� 5   
   -   5        $ Labos2��5      $��Фамилия(Surname)��6$   $
��Left=�6<   $��214,307,0,0q�6W   $	��Top=�6l   �� 5   
   -   5        $ Labos3��5      $��Имя(Name)��6$   $
��Left=�65   $��
14,307,0,0q�6P   $	��Top=�6d    J� RenderTransformOrigin$ 0.461,1.182&�6|   �� 5   
   -   5        $ Labos4��5      $ ��Отчество(Patronym)��6$   $
��Left=�6>   $��
16,377,0,0q�6Y   $	��Top=�5      �� 5    
   -   5        $ Labos5��5       $4��.Работает С Числа(Employed_Since)��6$   $
��Left=�6L   $��
14,456,0,0q�6g   $	��Top=�5!      �� 5"   
   -	   5        $ Labos6��5"      $,��&Номер Должности(Job_Num)��6$   $
��Left=�6D   $��228,270,0,0q�6_   $	��Top=�6t   �� 5#   
   -
   5        $ Labos7��5#      $&�� Стажировка(Internship)��6$   $
��Left=�6B   $��306,455,0,0q�6]   $	��Top=�5$      $ -5.684,0.629&�6(   �� 5%   
   -   5        $ Labos8��5%      $6��0Наименование должности(Job)��6$   $
��Left=�6G   $��306,381,0,0q�6b   $	��Top=�5&      $ -5.684,0.629&�6,   �� 5'   
   -   5         ��Name$ Exed1��5'      $
��Left=�6"   $��120,258,0,0q�6=    �� TextWrapping$
 Wrap=�6R   $��TextBox��6f   $	��Top=�5(      $	��120��6*   66   �� 5)   
   -   5        $ Exed2��5)      $
��Left=�6!   $��
16,331,0,0q�6<   $
 Wrap=�6P   $��TextBox��6d   $	��Top=�5*      $	��120��6*   66   �� 5+   
   -   5        $ Exed3��5+      $
��Left=�6!   $��214,331,0,0q�6<   $
 Wrap=�6Q   $��TextBox��6e   $	��Top=�5,      $	��120��6*   $ 1.298,-1.415&�6Y   �� 5-   
   -   5        $ Exed4��5-      $
��Left=�6!   $��
16,404,0,0q�6<   $
 Wrap=�6P   $��TextBox��6d   $	��Top=�5.      $	��120��6*   66   �� 5/   
   -   5        $ Exed5��5/      $
��Left=�6!   $��
16,480,0,0q�6<   $
 Wrap=�6P   $��TextBox��6d   $	��Top=�50      $	��120��6.   6:   �� 52   
   -   5        $ Exed6��52      $
��Left=�6!   $��436,262,0,0q�6<   $
 Wrap=�6Q   $��TextBox��6e   $	��Top=�53      $	��120��6*   66   �� 54   
   -   5        $ Exed7��54      $
��Left=�6!   $��306,480,0,0q�6<   $
 Wrap=�6Q   $��TextBox��6e   $	��Top=�55      $	��120��6*    � Cursor$ IBeam��6Y   �� 56   
   -   5        $ Exed8��56      $
��Left=�6!   $��300,405,0,0q�6<   $
 Wrap=�6Q   $��TextBox��6e   $	��Top=�57      $	��120��6*   66     5;   
   -   5        $ EmpUpdat��5;      $#��Обновить данные��6&   $��574,307,0,0q�6@   $	��253��6U   $��40��5<      $	��Top=�64     5=   
   -   5        $ 	dataGrid2��5=   �   #���  6O   $��13,556,10,10q�6�   ��6     *TextFillColorSecondaryBrush+6�   5@      5A      