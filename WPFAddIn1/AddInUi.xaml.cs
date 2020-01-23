using System.Windows;
using System.Windows.Controls;

namespace WPFAddIn1
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class AddInUi : UserControl
    {
        public AddInUi()
        {
            InitializeComponent();
        }

        private void clickMeButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello from WPFAddIn1");
        }
    }
}