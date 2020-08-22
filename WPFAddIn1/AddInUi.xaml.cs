using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace WPFAddIn1
{
    /// <summary>
    ///     Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class AddInUi : UserControl
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AddInUi" /> class.
        /// </summary>
        public AddInUi()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Handles the Click event of the clickMeButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void clickMeButton_Click(object sender, RoutedEventArgs e)
        {
            Show(sender);
            //   Application.Current.Shutdown();
        }

        /// <summary>
        /// Shows the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        [SecurityCritical]
        private void Show(object sender)
        {
            var win = new Window();
            win.Show();
        }
    }
}