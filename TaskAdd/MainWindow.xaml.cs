using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace TaskAdd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ButtonButton_Click(object sender, RoutedEventArgs e)
        {
            var result = await Task.Run(() => Addition(100, 200))/*.ConfigureAwait(false)*/;
            TextBoxTextBox.Text = result.ToString();
        }

        private int Addition(int a, int b)
        {
            Thread.Sleep(3000);
            return a + b;
        }
    }
}
