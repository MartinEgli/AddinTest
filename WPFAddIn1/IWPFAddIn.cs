using AddInViews;
using System.AddIn;
using System.Windows;

namespace WPFAddIn1
{
    /// <summary>
    /// Add-In implementation
    /// </summary>
    /// <seealso cref="AddInViews.IWPFAddInView" />
    [AddIn("WPF Add-In 1")]
    public class IWPFAddIn : IWPFAddInView
    {
        /// <summary>
        /// Gets the add in UI.
        /// </summary>
        /// <returns></returns>
        public FrameworkElement GetAddInUi()
        {
            // Return add-in UI
            return new AddInUi();
        }
    }
}