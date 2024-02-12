using System;
using System.Diagnostics;
using System.Windows;

using Application = System.Windows.Application;

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
            Trace.Listeners.Add(textWriterTraceListener);
#if DEBUG
            Console.WriteLine("STARTING DEBUG SESSION !!!");
#else
            Console.WriteLine("Starting application!");
#endif

        }

    }
}