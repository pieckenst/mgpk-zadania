

using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace TrainsMauiHybrid.Helpers
{


    public class EventHandleHelper
    {
        // Define a global event using .NET event syntax
        public event Action<bool> DarkModeChanged;

        // Method to raise (trigger) the event
        public void RaiseDarkModeChanged(bool isDarkMode)
        {
            DarkModeChanged?.Invoke(isDarkMode);
        }
    }


}
