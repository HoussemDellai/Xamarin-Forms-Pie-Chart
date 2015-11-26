using System.ComponentModel;
using com.refractored.monodroidtoolkit;
using CrossPieCharts.FormsPlugin.Abstractions;
using CrossPieCharts.FormsPlugin.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CrossPieChartView), typeof(CrossPieChartRenderer))]

namespace CrossPieCharts.FormsPlugin.Android
{
    /// <summary>
    /// CrossPieChart Renderer
    /// </summary>
    public class CrossPieChartRenderer : ViewRenderer<CrossPieChartView, HoloCircularProgressBar>
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CrossPieChartView> e)
        {

            base.OnElementChanged(e);

            var progressBar = Element as CrossPieChartView;

            if (e.OldElement != null || progressBar == null)
            {
                return;
            }

            var progress = new HoloCircularProgressBar(Forms.Context)
            {

                Progress = progressBar.Progress,
                ProgressColor = progressBar.ProgressColor.ToAndroid(),
                ProgressBackgroundColor = progressBar.ProgressBackgroundColor.ToAndroid(),
                CircleStrokeWidth = progressBar.StrokeThickness,
            };

            //var display = Resources.DisplayMetrics;

            progressBar.HeightRequest = progressBar.Radius * 2;
            progressBar.WidthRequest = progressBar.Radius * 2;

            SetNativeControl(progress);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            base.OnElementPropertyChanged(sender, e);

            if (Control == null || Element == null)
                return;

            if (e.PropertyName == CrossPieChartView.ProgressProperty.PropertyName)
            {
                Control.Progress = Element.Progress;
            }
            else if (e.PropertyName == CrossPieChartView.ProgressBackgroundColorProperty.PropertyName)
            {
                Control.ProgressBackgroundColor = Element.ProgressBackgroundColor.ToAndroid();
            }
            else if (e.PropertyName == CrossPieChartView.ProgressColorProperty.PropertyName)
            {
                Control.ProgressColor = Element.ProgressColor.ToAndroid();
            }
            else if (e.PropertyName == CrossPieChartView.StrokeThicknessProperty.PropertyName)
            {
                Control.IndeterminateInterval = Element.StrokeThickness;
            }
            else if (e.PropertyName == CrossPieChartView.RadiusProperty.PropertyName)
            {
                Control.IndeterminateInterval = Element.Radius;
            }
        }
    }
}