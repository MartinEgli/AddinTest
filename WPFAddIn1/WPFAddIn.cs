using System.AddIn;
using System.Windows;
using AddInViews;

namespace WPFAddIn1
{
    /// <summary>
    ///     Add-In implementation
    /// </summary>
    [AddIn("WPF Add-In 1")]
    public class WPFAddIn : IWpfAddInView
    {
        public FrameworkElement GetAddInUi()
        {
            // Return add-in UI
            return new AddInUi();
        }
    }
}