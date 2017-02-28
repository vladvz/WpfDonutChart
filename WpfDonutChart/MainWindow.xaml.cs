using System;
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

            donut1.Text = GetLeftValue(donut1.Value, donut1.Minimum, donut1.Maximum);
            donut2.Text = GetPercentage(donut2.Value, donut2.Minimum, donut2.Maximum);
        }

        private Func<int, int, int, string> GetLeftValue = (value, minimum, maximum) => { return $"Left: {maximum - minimum - value}"; };
        private Func<int, int, int, string> GetPercentage = (value, minimum, maximum) => { return $"{100 * value / (maximum - minimum)}%"; };

        private void OnIncrease1Click(object sender, RoutedEventArgs e)
        {
            if (donut1.Value < donut1.Maximum)
            {
                donut1.Value += donut1.Step;
                donut1.Text = GetLeftValue(donut1.Value, donut1.Minimum, donut1.Maximum);
            }
        }

        private void OnDecrease1Click(object sender, RoutedEventArgs e)
        {
            if (donut1.Value > donut1.Minimum)
            {
                donut1.Value -= donut1.Step;
                donut1.Text = GetLeftValue(donut1.Value, donut1.Minimum, donut1.Maximum);
            }
        }

        private void OnIncrease2Click(object sender, RoutedEventArgs e)
        {
            if (donut2.Value < donut2.Maximum)
            {
                donut2.Value += donut2.Step;
                donut2.Text = GetPercentage(donut2.Value, donut2.Minimum, donut2.Maximum);
            }
        }

        private void OnDecrease2Click(object sender, RoutedEventArgs e)
        {
            if (donut2.Value > donut2.Minimum)
            {
                donut2.Value -= donut2.Step;
                donut2.Text = GetPercentage(donut2.Value, donut2.Minimum, donut2.Maximum);
            }
        }
    }
}
