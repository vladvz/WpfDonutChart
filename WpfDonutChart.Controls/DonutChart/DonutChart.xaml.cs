using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfDonutChart.Controls
{
    /// <summary>
    /// Interaction logic for DonutChart.xaml
    /// </summary>
    public partial class DonutChart : UserControl
    {
        #region Constructor

        public DonutChart()
        {
            InitializeComponent();
            DrawControl();
        }

        #endregion

        #region Properties

        public double Total
        {
            get { return (double) GetValue(TotalProperty); }
            set { SetValue(TotalProperty, value); }
        }

        public static readonly DependencyProperty TotalProperty =
            DependencyProperty.Register("Total", typeof(double), typeof(DonutChart), new PropertyMetadata(100.0, OnPropertyChanged));

        public double Elapsed
        {
            get { return (double)GetValue(ElapsedProperty); }
            set { SetValue(ElapsedProperty, value); }
        }

        public static readonly DependencyProperty ElapsedProperty =
            DependencyProperty.Register("Elapsed", typeof(double), typeof(DonutChart), new PropertyMetadata(25.0, OnPropertyChanged));

        public double Left
        {
            get { return (double) GetValue(LeftProperty); }
            set { SetValue(LeftProperty, value); }
        }

        public static readonly DependencyProperty LeftProperty =
            DependencyProperty.Register("Left", typeof(double), typeof(DonutChart), new PropertyMetadata(0.0, OnPropertyChanged));

        public double Radius
        {
            get { return (double) GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register("Radius", typeof(double), typeof(DonutChart), new PropertyMetadata(100.0, OnPropertyChanged));

        public double InnerRadius
        {
            get { return (double) GetValue(InnerRadiusProperty); }
            set { SetValue(InnerRadiusProperty, value); }
        }

        public static readonly DependencyProperty InnerRadiusProperty =
            DependencyProperty.Register("InnerRadius", typeof(double), typeof(DonutChart), new PropertyMetadata(60.0, OnPropertyChanged));

        public Brush ElapsedFill
        {
            get { return (Brush) GetValue(ElapsedFillProperty); }
            set { SetValue(ElapsedFillProperty, value); }
        }

        public static readonly DependencyProperty ElapsedFillProperty =
            DependencyProperty.Register("ElapsedFill", typeof(Brush), typeof(DonutChart), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(0, 255, 0)), OnPropertyChanged));

        public Brush LeftFill
        {
            get { return (Brush) GetValue(LeftFillProperty); }
            set { SetValue(LeftFillProperty, value); }
        }

        public static readonly DependencyProperty LeftFillProperty =
            DependencyProperty.Register("LeftFill", typeof(Brush), typeof(DonutChart), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(255, 0, 0)), OnPropertyChanged));

        #endregion

        #region Events

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var parent = (DonutChart) d;

            parent.DrawControl();
        }

        private static void OnRadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var parent = (DonutChart) d;

            parent.DrawControl();
        }

        private static void OnElapsedFillChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var parent = (DonutChart) d;

            parent.DrawControl();
        }

        private static void OnLeftFillChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var parent = (DonutChart) d;

            //parent.UpdateLeftFill(parent, (Brush) e.NewValue);
            parent.DrawControl();
        }

        #endregion

        #region Methods

        private void DrawControl()
        {
            var diameter = Radius * 2;

            this.Width = this.Height = diameter;

            var elapsedWedgeAngle = this.Elapsed / this.Total * 360.0;
            var leftWedgeAngle = 360.0 - elapsedWedgeAngle;
            var leftRotationAngle = elapsedWedgeAngle;

            canvas.Children.Clear();

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
                Fill = this.ElapsedFill
            };

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

            canvas.Children.Insert(0, elapsedPiece);
            canvas.Children.Insert(0, leftPiece);
        }

        #endregion
    }
}
