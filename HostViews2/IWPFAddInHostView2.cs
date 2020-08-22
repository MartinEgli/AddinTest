using System.Windows;

namespace HostViews2
{
    public interface IWPFAddInHostView2
    {
        // The view returns as a class that directly or indirectly derives from
        // FrameworkElement and can subsequently be displayed by the host
        // application by embedding it as content or sub-content of a UI that is
        // implemented by the host application.
        FrameworkElement GetAddInUi();
    }
}