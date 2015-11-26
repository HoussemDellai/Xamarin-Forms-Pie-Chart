using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrossPieCharts.FormsPlugin.Abstractions
{
    /// <summary>
    /// Shows how to use the PieCharts controls.
    /// </summary>
    public class CrossPieChartSample
    {
        /// <summary>
        /// Makes a ContentPage with samples of PieCharts.
        /// </summary>
        /// <returns></returns>
        public ContentPage GetPageWithPieChart()
        {
            // The root page of your application
            var contentPage = new ContentPage
            {
                Content = new Grid
                {
                    Children =
                    {
                        new Grid // a trick to set the BackgroundColor of the ContentPage to white
                        {
                            BackgroundColor  = Color.White,
                        },
                        new StackLayout
                        {
                            Children =
                            {
                                new Label
                                {
                                    XAlign = TextAlignment.Center,
                                    Text = "Welcome to Xamarin Forms!",
                                    TextColor = Color.Black
                                },
                                new Grid
                                {
                                    Children =
                                    {
                                        new CrossPieChartView
                                        {
                                            Progress = 60,
                                            ProgressColor = Color.Green,
                                            ProgressBackgroundColor = Color.FromHex("#EEEEEEEE"),
                                            StrokeThickness = Device.OnPlatform(10, 20, 80),
                                            Radius = Device.OnPlatform(100, 180, 160),
                                            BackgroundColor = Color.White
                                        },
                                        new Label
                                        {
                                            Text = "60%",
                                            Font = Font.BoldSystemFontOfSize(NamedSize.Large),
                                            FontSize = 70,
                                            VerticalOptions = LayoutOptions.Center,
                                            HorizontalOptions = LayoutOptions.Center,
                                            TextColor = Color.Black
                                        }
                                    }
                                },
                                new StackLayout
                                {
                                    Orientation = StackOrientation.Horizontal,
                                    HorizontalOptions = LayoutOptions.Center,
                                    Children =
                                    {
                                        new CrossPieChartView
                                        {
                                            Progress = 80,
                                            ProgressColor = Color.Blue,
                                            ProgressBackgroundColor = Color.Gray,
                                            StrokeThickness = Device.OnPlatform(10, 10, 20),
                                            Radius = Device.OnPlatform(100, 50, 36),
                                            BackgroundColor = Color.White
                                        },
                                        new CrossPieChartView
                                        {
                                            Progress = 55,
                                            ProgressColor = Color.Olive,
                                            ProgressBackgroundColor = Color.Gray,
                                            StrokeThickness = Device.OnPlatform(10, 10, 20),
                                            Radius = Device.OnPlatform(100, 50, 36),
                                            BackgroundColor = Color.White
                                        },
                                        new CrossPieChartView
                                        {
                                            Progress = 33,
                                            ProgressColor = Color.Red,
                                            ProgressBackgroundColor = Color.Gray,
                                            StrokeThickness = Device.OnPlatform(10, 10, 20),
                                            Radius = Device.OnPlatform(100, 50, 36),
                                            BackgroundColor = Color.White
                                        },
                                        new CrossPieChartView
                                        {
                                            Progress = 70,
                                            ProgressColor = Color.Teal,
                                            ProgressBackgroundColor = Color.Gray,
                                            StrokeThickness = Device.OnPlatform(10, 10, 20),
                                            Radius = Device.OnPlatform(100, 50, 36),
                                            BackgroundColor = Color.White
                                        },
                                    }
                                },
                                new Label
                                {
                                    Text = "Xamarin Forms Pie Charts",
                                    TextColor = Color.Black,
                                    HorizontalOptions = LayoutOptions.Center,
                                    Font = Font.BoldSystemFontOfSize(NamedSize.Large)
                                }
                            }
                        }
                    }
                }
            };

            return contentPage;
        }
    }
}
