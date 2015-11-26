using CrossPieCharts.FormsPlugin.Abstractions;
using System;
using Xamarin.Forms;
using CrossPieCharts.FormsPlugin.iOSUnified;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CrossPieChartView), typeof(CrossPieChartRenderer))]
namespace CrossPieCharts.FormsPlugin.iOSUnified
{
    /// <summary>
    /// CrossPieCharts Renderer
    /// </summary>
    public class CrossPieChartRenderer //: TRender (replace with renderer type
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init()
        {
        }
    }
}
