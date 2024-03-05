

using System.Windows;

namespace FluentKursovayaAvtoparkA.Services.Contracts;

public interface IWindow
{
    event RoutedEventHandler Loaded;

    void Show();
}
