using System.AddIn;
using System.AddIn.Pipeline;
using System.Windows;
using AddInViews1;

namespace WPFAddIn1
{
    /// <summary>
    /// Add-In implementation
    /// </summary>
    /// <seealso cref="IWPFAddInView1" />
    [AddIn("WPF Add-In 1")]
    [QualificationData("Isolation", "NewAppDomain")]
    public class WPFAddIn1 : IWPFAddInView1
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