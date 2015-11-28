using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Point = System.Windows.Point;
using Size = Windows.Foundation.Size;
using Thickness = System.Windows.Thickness;

namespace CrossPieCharts.FormsPlugin.WindowsPhone
{
    /// <summary>
    /// Pie Chart control for Windows Phone Silverlight.
    /// </summary>
    public class PieChart : Grid
    {

        public int Radius
        {
            get
            {
                return (int)GetValue(RadiusProperty);
            }
            set
            {
                SetValue(RadiusProperty, value);
            }
        }

        public Brush SegmentColor
        {
            get
            {
                return (Brush)GetValue(SegmentColorProperty);
            }
            set
            {
                SetValue(SegmentColorProperty, value);
            }
        }

        public Brush Segment360Color
        {
            get
            {
                return (Brush)GetValue(Segment360ColorProperty);
            }
            set
            {
                SetValue(Segment360ColorProperty, value);
            }
        }

        public Brush BackgroundColor
        {
            get
            {
                return (Brush)GetValue(BackgroundColorProperty);
            }
            set
            {
                SetValue(BackgroundColorProperty, value);
            }
        }

        public int StrokeThickness
        {
            get
            {
                return (int)GetValue(StrokeThicknessProperty);
            }
            set
            {
                SetValue(StrokeThicknessProperty, value);
            }
        }

        public double Percentage
        {
            get
            {
                return (double)GetValue(PercentageProperty);
            }
            set
            {
                SetValue(PercentageProperty, value);
            }
        }

        public double Angle
        {
            get
            {
                return (double)GetValue(AngleProperty);
            }
            set
            {
                SetValue(AngleProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for Percentage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PercentageProperty =
            DependencyProperty.Register("Percentage", typeof(double), typeof(PieChart), new PropertyMetadata(65d, OnPercentageChanged));

        // Using a DependencyProperty as the backing store for StrokeThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof(int), typeof(PieChart), new PropertyMetadata(5));

        // Using a DependencyProperty as the backing store for SegmentColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SegmentColorProperty =
            DependencyProperty.Register("SegmentColor", typeof(Brush), typeof(PieChart), new PropertyMetadata(new SolidColorBrush(Colors.Green),
                (o, args) =>
                {
                    var circle = o as PieChart;

                    if (circle != null)
                    {
                        circle.SegmentColor = (Brush)args.NewValue;
                    }
                }));


        public static readonly DependencyProperty BackgroundColorProperty =
            DependencyProperty.Register("BackgroundColor", typeof(Brush), typeof(PieChart), new PropertyMetadata(new SolidColorBrush(Colors.Transparent), OnPropertyChanged));

        // Using a DependencyProperty as the backing store for SegmentColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Segment360ColorProperty =
            DependencyProperty.Register("Segment360Color", typeof(Brush), typeof(PieChart), new PropertyMetadata(new SolidColorBrush(Colors.LightGray), OnPropertyChanged));

        // Using a DependencyProperty as the backing store for Radius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register("Radius", typeof(int), typeof(PieChart), new PropertyMetadata(25, OnPropertyChanged));

        // Using a DependencyProperty as the backing store for Angle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", typeof(double), typeof(PieChart), new PropertyMetadata(120d, OnPropertyChanged));



        ArcSegment _arcSegment = new ArcSegment();
        ArcSegment _arcSegment360 = new ArcSegment();

        PathFigure _pathFigure = new PathFigure();
        PathFigure _pathFigure360 = new PathFigure();

        private Path _pathRoot = new Path();
        private Path _pathRoot360 = new Path();

        public PieChart()
        {

            InitializePieChart();

            Angle = Percentage * 360 / 100;
        }

        private static void OnPercentageChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            var circle = sender as PieChart;

            circle.Angle = (circle.Percentage * 360) / 100;
        }

        private static void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            var circle = sender as PieChart;

            circle.InitializePieChart();

            circle.RenderArc();
        }

        public void RenderArc()
        {
            var startPoint = new Point(Radius, 0);
            var endPoint = ComputeCartesianCoordinate(Angle, Radius);
            endPoint.X += Radius;
            endPoint.Y += Radius;

            _pathRoot.Width = Radius * 2 + StrokeThickness;
            _pathRoot.Height = Radius * 2 + StrokeThickness;
            _pathRoot.Margin = new Thickness(StrokeThickness, StrokeThickness, 0, 0);

            var largeArc = Angle > 180.0;

            var outerArcSize = new Size(Radius, Radius);

            _pathFigure.StartPoint = startPoint;

            if (startPoint.X == Math.Round(endPoint.X) && startPoint.Y == Math.Round(endPoint.Y))
            {
                endPoint.X -= 0.01;
            }

            _arcSegment.Point = endPoint;
            _arcSegment.Size = new System.Windows.Size(outerArcSize.Width, outerArcSize.Height);
            _arcSegment.IsLargeArc = largeArc;

            // Draw the 360 arc/circle

            var endPoint2 = ComputeCartesianCoordinate(360, Radius);
            endPoint2.X += Radius;
            endPoint2.Y += Radius;

            _pathRoot360.Width = Radius * 2 + StrokeThickness;
            _pathRoot360.Height = Radius * 2 + StrokeThickness;
            _pathRoot360.Margin = new Thickness(StrokeThickness, StrokeThickness, 0, 0);

            _pathFigure360.StartPoint = startPoint;

            if (startPoint.X == Math.Round(endPoint2.X) && startPoint.Y == Math.Round(endPoint2.Y))
            {
                endPoint2.X -= 0.01;
            }

            _arcSegment360.Point = endPoint2;
            _arcSegment360.Size = new System.Windows.Size(outerArcSize.Width, outerArcSize.Height);
            _arcSegment360.IsLargeArc = true;
        }

        private Point ComputeCartesianCoordinate(double angle, double radius)
        {
            // convert to radians
            var angleRad = (Math.PI / 180.0) * (angle - 90);

            var x = radius * Math.Cos(angleRad);
            var y = radius * Math.Sin(angleRad);

            return new Point(x, y);
        }

        private void InitializePieChart()
        {
            // draw the full circle/arc
            _arcSegment360 = new ArcSegment
            {
                SweepDirection = SweepDirection.Clockwise
            };

            _pathFigure360 = new PathFigure
            {
                Segments = new PathSegmentCollection
                {
                    _arcSegment360
                }
            };

            _pathRoot360 = new Path
            {
                Stroke = Segment360Color,
                StrokeThickness = StrokeThickness,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Data = new PathGeometry
                {
                    Figures = new PathFigureCollection
                    {
                        _pathFigure360
                    }
                }
            };

            //draw a circle with the given angle

            _arcSegment = new ArcSegment
            {
                SweepDirection = SweepDirection.Clockwise
            };

            _pathFigure = new PathFigure
            {
                Segments = new PathSegmentCollection
                {
                    _arcSegment
                }
            };

            _pathRoot = new Path
            {
                Stroke = SegmentColor,
                StrokeThickness = StrokeThickness,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Data = new PathGeometry
                {
                    Figures = new PathFigureCollection
                    {
                        _pathFigure
                    }
                }
            };

            Children.Clear(); // remove the chart created with default values
            Children.Add(_pathRoot360);
            Children.Add(_pathRoot);

            Background = BackgroundColor;
       
            Width = Radius * 2.5 + StrokeThickness;
            Height = Radius * 2.5 + StrokeThickness;
        }
    }
}
