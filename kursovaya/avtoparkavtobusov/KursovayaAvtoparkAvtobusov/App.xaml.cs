using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;

namespace KursovayaAvtoparkAvtobusov
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
   
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            
            TextWriterTraceListener textWriterTraceListener = new TextWriterTraceListener(Console.Out);
            Debug.Listeners.Add(textWriterTraceListener);
            Console.WriteLine("STARTING DEBUG SESSION !!!");

        }
    }
}
