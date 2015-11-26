using Xamarin.Forms;

namespace CrossPieCharts.FormsPlugin.Abstractions
{
    /// <summary>
    /// A view that shows a Pie chart with a given percentage and colors.
    /// </summary>
    public class CrossPieChartView : View
    {

        public static readonly BindableProperty ProgressProperty =
            BindableProperty.Create<CrossPieChartView, float>(
                p => p.Progress, 0);

        public static readonly BindableProperty RadiusProperty =
           BindableProperty.Create<CrossPieChartView, int>(
               p => p.Radius, 50);

        public static readonly BindableProperty StrokeThicknessProperty =
            BindableProperty.Create<CrossPieChartView, int>(
                p => p.StrokeThickness, 10);

        public static readonly BindableProperty ProgressBackgroundColorProperty =
            BindableProperty.Create<CrossPieChartView, Color>(
                p => p.ProgressBackgroundColor, Color.White);

        public static readonly BindableProperty ProgressColorProperty =
            BindableProperty.Create<CrossPieChartView, Color>(
                p => p.ProgressColor, Color.Red);

        /// <summary>
        /// Gets or sets the progress color
        /// </summary>
        /// <value>The color of the progress.</value>
        public Color ProgressColor
        {
            get
            {
                return (Color)GetValue(ProgressColorProperty);
            }
            set
            {
                SetValue(ProgressColorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the ProgressBackgroundColorProperty
        /// </summary>
        /// <value>The color of the ProgressBackgroundColorProperty.</value>
        public Color ProgressBackgroundColor
        {
            get
            {
                return (Color)GetValue(ProgressBackgroundColorProperty);
            }
            set
            {
                SetValue(ProgressBackgroundColorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the current progress
        /// </summary>
        /// <value>The progress.</value>
        public float Progress
        {
            get
            {
                return (float)GetValue(ProgressProperty);
            }
            set
            {
                SetValue(ProgressProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the thikness of the stroke
        /// </summary>
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
    }
}
