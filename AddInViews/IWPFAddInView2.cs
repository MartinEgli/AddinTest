using System.AddIn.Pipeline;
using System.Windows;

namespace AddInViews2
{
    [AddInBase]
    public interface IWPFAddInView2
    {
        // The add-in's implementation of this method will return
        // a UI type that directly or indirectly derives from
        // FrameworkElement.
        FrameworkElement GetAddInUi();
    }
}