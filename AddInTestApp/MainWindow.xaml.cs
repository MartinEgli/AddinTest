using HostViews;
using System;
using System.AddIn.Hosting;
using System.Linq;
using System.Windows;

namespace AddInTestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        /// <summary>
        /// The WPF add in host view
        /// </summary>
        private readonly IWPFAddInHostView hostView;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
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
                foreach (var warning in warnings)
                {
                    msg += "\n" + warning;
                }
                MessageBox.Show(msg);
                return;
            }

            // Activate add-in with Internet zone security isolation
            var addInTokens = AddInStore.FindAddIns(typeof(IWPFAddInHostView), appPath);
            var addInToken = addInTokens.FirstOrDefault();
            if (addInToken == null)
            {
                return;
            }

            this.hostView = addInToken.Activate<IWPFAddInHostView>(AddInSecurityLevel.Internet);

            // Get and display add-in UI
            var addInUi = hostView.GetAddInUi();
            if (addInUi == null)
            {
                return;
            }
            AddInGrid.Children.Add(addInUi);
        }
    }
}