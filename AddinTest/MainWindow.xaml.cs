using System;
using System.AddIn.Hosting;
using System.Windows;
using AddinTest;
using HostViews;

namespace AddinTest
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IWPFAddInHostView wpfAddInHostView;

        public MainWindow()
        {
            InitializeComponent();
            // Get add-in pipeline folder (the folder in which this application was launched from)
            var appPath = Environment.CurrentDirectory;

            // Rebuild visual add-in pipeline
            var warnings = AddInStore.Rebuild(appPath);
            if (warnings.Length > 0)
            {
                var msg = "Could not rebuild pipeline:";
                foreach (var warning in warnings) msg += "\n" + warning;
                MessageBox.Show(msg);
                return;
            }

            // Activate add-in with Internet zone security isolation
            var addInTokens = AddInStore.FindAddIns(typeof(IWPFAddInHostView), appPath);
            var wpfAddInToken = addInTokens[0];
            wpfAddInHostView = wpfAddInToken.Activate<IWPFAddInHostView>(AddInSecurityLevel.Internet);

            // Get and display add-in UI
            var addInUI = wpfAddInHostView.GetAddInUi();
            AddinGrid.Children.Add(addInUI);
        }
    }
}

namespace Contracts
{
}

namespace AddInViews
{
}

namespace AddInSideAdapters
{
}

namespace HostViews
{
}

namespace HostSideAdapters
{
}

namespace WPFAddIn1
{
}