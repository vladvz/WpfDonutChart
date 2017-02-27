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

        private void OnIncrease1Click(object sender, RoutedEventArgs e)
        {
            if (donut1.Elapsed < donut1.Total)
                donut1.Elapsed += 10;
        }

        private void OnDecrease1Click(object sender, RoutedEventArgs e)
        {
            if (donut1.Elapsed > 0)
                donut1.Elapsed -= 10;
        }

        private void OnIncrease2Click(object sender, RoutedEventArgs e)
        {
            if (donut2.Elapsed < donut2.Total)
                donut2.Elapsed += 20;
        }

        private void OnDecrease2Click(object sender, RoutedEventArgs e)
        {
            if (donut2.Elapsed > 0)
                donut2.Elapsed -= 20;
        }
    }
}
