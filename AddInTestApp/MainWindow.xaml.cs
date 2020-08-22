using System;
using System.AddIn.Hosting;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using HostViews1;
using HostViews2;

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
        private readonly IWpfAddInHostView1 _hostView1;
        private readonly IWPFAddInHostView2 _hostView2;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            // Get add-in pipeline folder (the folder in which this application was launched from)
            var appPath = Environment.CurrentDirectory;
            Debug.WriteLine($"AppPath: {appPath}");

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

            AddInGrid.Children.Add(new Button(){Content = "Test"});


            // Activate add-in with Internet zone security isolation
            var addInTokens = AddInStore.FindAddIns(typeof(IWpfAddInHostView1), appPath);
            var addInToken = addInTokens.FirstOrDefault();
            if (addInToken == null)
            {
                return;
            }

            this._hostView1 = addInToken.Activate<IWpfAddInHostView1>(AddInSecurityLevel.FullTrust);

            // Get and display add-in UI
            var addInUi = _hostView1.GetAddInUi();
            if (addInUi == null)
            {
                return;
            }
            AddInGrid.Children.Add(addInUi);



            var addIn2Tokens = AddInStore.FindAddIns(typeof(IWPFAddInHostView2), appPath);
            var addIn2Token = addIn2Tokens.FirstOrDefault();
            if (addIn2Token == null)
            {
                return;
            }
            this._hostView2 = addIn2Token.Activate<IWPFAddInHostView2>(AddInSecurityLevel.FullTrust);

            // Get and display add-in UI
            var addIn2Ui = _hostView2.GetAddInUi();
            if (addIn2Ui == null)
            {
                return;
            }
            AddInGrid.Children.Add(addIn2Ui);
        }
    }
}