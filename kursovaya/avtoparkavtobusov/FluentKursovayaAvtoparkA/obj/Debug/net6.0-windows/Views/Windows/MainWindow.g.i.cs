﻿#pragma checksum "..\..\..\..\..\Views\Windows\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "60C575483FB64480EC6F9D7A3F872940FAE6E49D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FluentKursovayaAvtoparkA.Views.Windows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Wpf.Ui;
using Wpf.Ui.Controls;
using Wpf.Ui.Converters;
using Wpf.Ui.Markup;


namespace FluentKursovayaAvtoparkA.Views.Windows {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : Wpf.Ui.Controls.FluentWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\..\..\Views\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.NavigationView NavigationView;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\..\Views\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.BreadcrumbBar BreadcrumbBar;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\..\Views\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.AutoSuggestBox AutoSuggestBox;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\..\Views\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentPresenter RootContentDialog;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\..\Views\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.TitleBar TitleBar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FluentKursovayaAvtoparkA;component/views/windows/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Windows\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 22 "..\..\..\..\..\Views\Windows\MainWindow.xaml"
            ((FluentKursovayaAvtoparkA.Views.Windows.MainWindow)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.MainWindow_OnSizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NavigationView = ((Wpf.Ui.Controls.NavigationView)(target));
            
            #line 47 "..\..\..\..\..\Views\Windows\MainWindow.xaml"
            this.NavigationView.PaneClosed += new Wpf.Ui.Controls.TypedEventHandler<Wpf.Ui.Controls.NavigationView, System.Windows.RoutedEventArgs>(this.NavigationView_OnPaneClosed);
            
            #line default
            #line hidden
            
            #line 49 "..\..\..\..\..\Views\Windows\MainWindow.xaml"
            this.NavigationView.PaneOpened += new Wpf.Ui.Controls.TypedEventHandler<Wpf.Ui.Controls.NavigationView, System.Windows.RoutedEventArgs>(this.NavigationView_OnPaneOpened);
            
            #line default
            #line hidden
            
            #line 50 "..\..\..\..\..\Views\Windows\MainWindow.xaml"
            this.NavigationView.SelectionChanged += new Wpf.Ui.Controls.TypedEventHandler<Wpf.Ui.Controls.NavigationView, System.Windows.RoutedEventArgs>(this.OnNavigationSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BreadcrumbBar = ((Wpf.Ui.Controls.BreadcrumbBar)(target));
            return;
            case 4:
            this.AutoSuggestBox = ((Wpf.Ui.Controls.AutoSuggestBox)(target));
            return;
            case 5:
            this.RootContentDialog = ((System.Windows.Controls.ContentPresenter)(target));
            return;
            case 6:
            this.TitleBar = ((Wpf.Ui.Controls.TitleBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

