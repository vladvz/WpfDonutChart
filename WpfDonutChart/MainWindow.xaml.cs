using System.Windows;

namespace WpfDonutChart
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

        private void OnIncreaseClick(object sender, RoutedEventArgs e)
        {
            donut1.Elapsed += 10;
            donut2.Elapsed += 20;
        }

        private void OnDecreaseClick(object sender, RoutedEventArgs e)
        {
            donut1.Elapsed -= 10;
            donut2.Elapsed -= 20;
        }
    }
}
