using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BantuHub.Demo.Async
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TextBlock.Text = string.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LongRunningOperation();

            MessageBox.Show("Execution terminée");
        }

        private void LongRunningOperation()
        {
            Thread.Sleep(10000);
        }

        private Task LongRunningOperationAsync()
        {
            return Task.Run(() => LongRunningOperation());
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProgressBar.IsIndeterminate = true;
            TextBlock.Text = "Execution asynchrone en cours ...";

            await LongRunningOperationAsync();

            ProgressBar.IsIndeterminate = false;
            TextBlock.Text = string.Empty;

            MessageBox.Show("Execution terminée");
        }
    }
}
