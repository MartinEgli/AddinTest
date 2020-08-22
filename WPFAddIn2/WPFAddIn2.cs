using System.AddIn;
using System.AddIn.Pipeline;
using System.Windows;
using AddInViews2;

namespace WPFAddIn2
{
    /// <summary>
    /// Add-In implementation
    /// </summary>
    /// <seealso cref="IWPFAddInView2" />
    [AddIn("WPF Add-In 2")]
    [QualificationData("Isolation", "NewAppDomain")]
    public class WPFAddIn2 : IWPFAddInView2
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