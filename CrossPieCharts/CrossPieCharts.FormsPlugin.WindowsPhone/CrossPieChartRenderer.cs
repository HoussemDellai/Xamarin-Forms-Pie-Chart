using CrossPieCharts.FormsPlugin.Abstractions;
using System.Windows.Media;
using Xamarin.Forms;
using CrossPieCharts.FormsPlugin.WindowsPhone;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(CrossPieChartView), typeof(CrossPieChartRenderer))]
namespace CrossPieCharts.FormsPlugin.WindowsPhone
{
    /// <summary>
    /// CrossPieChart Renderer
    /// </summary>
    public class CrossPieChartRenderer : ViewRenderer
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {

            base.OnElementChanged(e);

            var circularProgress = Element as CrossPieChartView;

            if ((circularProgress != null) && (e.OldElement == null))
            {

                var circularProgressBarRenderer = new PieChart
                {

                    StrokeThickness = circularProgress.StrokeThickness,
                    Percentage = circularProgress.Progress,
                    Radius = circularProgress.Radius,
                    SegmentColor = new SolidColorBrush(System.Windows.Media.Color.FromArgb(
                                                  (byte)(circularProgress.ProgressColor.A * 255),
                                                  (byte)(circularProgress.ProgressColor.R * 255),
                                                  (byte)(circularProgress.ProgressColor.G * 255),
                                                  (byte)(circularProgress.ProgressColor.B * 255))),
                    Segment360Color = new SolidColorBrush(System.Windows.Media.Color.FromArgb(
                                                  (byte)(circularProgress.ProgressBackgroundColor.A * 255),
                                                  (byte)(circularProgress.ProgressBackgroundColor.R * 255),
                                                  (byte)(circularProgress.ProgressBackgroundColor.G * 255),
                                                  (byte)(circularProgress.ProgressBackgroundColor.B * 255))),
                    BackgroundColor = new SolidColorBrush(System.Windows.Media.Color.FromArgb(
                                                  (byte)(circularProgress.BackgroundColor.A * 255),
                                                  (byte)(circularProgress.BackgroundColor.R * 255),
                                                  (byte)(circularProgress.BackgroundColor.G * 255),
                                                  (byte)(circularProgress.BackgroundColor.B * 255))),
                };

                Children.Add(circularProgressBarRenderer);
            }
        }
    }
}
