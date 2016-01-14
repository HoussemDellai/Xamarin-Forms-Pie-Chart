using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CrossPieCharts.UWP.PieCharts;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CrossPieCharts.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            //var pieChart = new PieChart
            //{
            //    Percentage = 70,
            //    Radius = 200,
            //    BackgroundColor = new SolidColorBrush(Colors.AliceBlue),
            //    Segment360Color = new SolidColorBrush(Colors.DeepSkyBlue),
            //    SegmentColor = new SolidColorBrush(Colors.Teal),
            //    StrokeThickness = 30
            //};
        }
    }
}
