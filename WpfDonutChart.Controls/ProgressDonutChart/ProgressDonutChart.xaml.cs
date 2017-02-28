using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfDonutChart.Controls
{
    /// <summary>
    /// Interaction logic for ProgressDonutChart.xaml
    /// </summary>
    public partial class ProgressDonutChart : UserControl
    {
        #region Constructor

        public ProgressDonutChart()
        {
            InitializeComponent();
            DrawControl();
        }

        #endregion

        #region Properties

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ProgressDonutChart), new PropertyMetadata(string.Empty, OnPropertyChanged));

        public int Minimum
        {
            get { return (int) GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(int), typeof(ProgressDonutChart), new PropertyMetadata(0, OnPropertyChanged));

        public int Maximum
        {
            get { return (int) GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(int), typeof(ProgressDonutChart), new PropertyMetadata(100, OnPropertyChanged));

        public int Step
        {
            get { return (int) GetValue(StepProperty); }
            set { SetValue(StepProperty, value); }
        }

        public static readonly DependencyProperty StepProperty =
            DependencyProperty.Register("Step", typeof(int), typeof(ProgressDonutChart), new PropertyMetadata(1, OnPropertyChanged));

        public int Value
        {
            get { return (int) GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(ProgressDonutChart), new PropertyMetadata(0, OnPropertyChanged));

        public double Radius
        {
            get { return (double) GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register("Radius", typeof(double), typeof(ProgressDonutChart), new PropertyMetadata(100.0, OnPropertyChanged));

        public double InnerRadius
        {
            get { return (double) GetValue(InnerRadiusProperty); }
            set { SetValue(InnerRadiusProperty, value); }
        }

        public static readonly DependencyProperty InnerRadiusProperty =
            DependencyProperty.Register("InnerRadius", typeof(double), typeof(ProgressDonutChart), new PropertyMetadata(80.0, OnPropertyChanged));

        public Brush ProgressFill
        {
            get { return (Brush) GetValue(ProgressFillProperty); }
            set { SetValue(ProgressFillProperty, value); }
        }

        public static readonly DependencyProperty ProgressFillProperty =
            DependencyProperty.Register("ElapsedFill", typeof(Brush), typeof(ProgressDonutChart), new PropertyMetadata(new SolidColorBrush(Colors.GreenYellow), OnPropertyChanged));

        public Brush LeftFill
        {
            get { return (Brush) GetValue(LeftFillProperty); }
            set { SetValue(LeftFillProperty, value); }
        }

        public static readonly DependencyProperty LeftFillProperty =
            DependencyProperty.Register("LeftFill", typeof(Brush), typeof(ProgressDonutChart), new PropertyMetadata(new SolidColorBrush(Colors.Red), OnPropertyChanged));

        #endregion

        #region Events

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var parent = (ProgressDonutChart) d;

            parent.DrawControl();
        }

        #endregion

        #region Methods

        private void DrawControl()
        {
            var diameter = Radius * 2;

            this.Width = this.Height = diameter;

            var elapsedWedgeAngle = 360.0 * this.Value / (this.Maximum - this.Minimum);
            var leftWedgeAngle = 360.0 - elapsedWedgeAngle;
            var leftRotationAngle = elapsedWedgeAngle;

            canvas.Children.Clear();

            // Don't draw Elapsed pie when Value equals Minimum
            if (this.Value != this.Minimum)
            {
                // Fix to close shape
                if (elapsedWedgeAngle >= 360.0)
                    elapsedWedgeAngle = 359.999;

                PiePiece elapsedPiece = new PiePiece()
                {
                    Radius = this.Radius,
                    InnerRadius = this.InnerRadius,
                    CentreX = this.Radius,
                    CentreY = this.Radius,
                    PushOut = 0.0,
                    PieceValue = 0.0,
                    WedgeAngle = elapsedWedgeAngle,
                    RotationAngle = 0.0,
                    Fill = this.ProgressFill
                };

                canvas.Children.Insert(0, elapsedPiece);
            }

            // Don't draw Left pie when Value >= Maximum
            if (this.Value < this.Maximum)
            {
                // Fix to close shape
                if (leftWedgeAngle >= 360.0)
                {
                    leftRotationAngle = 0.0;
                    leftWedgeAngle = 359.999;
                }

                PiePiece leftPiece = new PiePiece()
                {
                    Radius = this.Radius,
                    InnerRadius = this.InnerRadius,
                    CentreX = this.Radius,
                    CentreY = this.Radius,
                    PushOut = 0.0,
                    PieceValue = 0.0,
                    WedgeAngle = leftWedgeAngle,
                    RotationAngle = leftRotationAngle,
                    Fill = this.LeftFill
                };

                canvas.Children.Insert(0, leftPiece);
            }

            viewBox.Width = viewBox.Height = 2.0 * this.InnerRadius / Math.Sqrt(2);
        }

        #endregion
    }
}
