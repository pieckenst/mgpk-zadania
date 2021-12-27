using System;
using System.Diagnostics;
using System.Windows;

namespace KursovayaAvtoparkAvtobusov
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var textWriterTraceListener = new TextWriterTraceListener(Console.Out);
            Debug.Listeners.Add(textWriterTraceListener);
            Console.WriteLine("STARTING DEBUG SESSION !!!");
        }
    }
}