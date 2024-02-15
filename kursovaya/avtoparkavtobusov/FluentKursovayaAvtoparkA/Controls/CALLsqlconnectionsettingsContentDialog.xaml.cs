// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System;
using System.Windows;
using System.Windows.Controls;
using FluentKursovayaAvtoparkA.ViewModels.Windows;
using FluentKursovayaAvtoparkA.Views.Pages;
using SQLServerLoginTemplate;
using Wpf.Ui.Controls;

namespace FluentKursovayaAvtoparkA.Controls;

public partial class CallSQLConnectionSettingsContentDialog : ContentDialog
{
    public CallSQLConnectionSettingsContentDialog(ContentPresenter contentPresenter, MainWindowViewModel viewModel) : base(contentPresenter)   
        
    {
        InitializeComponent();
    }

    protected override void OnButtonClick(ContentDialogButton button)
    {
        if (CheckBox.IsChecked == true)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            
            
            var form1 = new FormConnectToSQLServer();
            form1.ShowDialog();
            var a = form1.ConnectionString;
            SettingsPage.formations = a + ";Initial Catalog=KursovayaAvtoparkAvtobusov";
            form1.Close();
            base.OnButtonClick(button);
            Console.WriteLine(SettingsPage.formations);
            return;
        }
        else
        {
            base.OnButtonClick(button);
            return;
        }

        TextBlock.Visibility = Visibility.Visible;
        CheckBox.Focus();
    }
}
