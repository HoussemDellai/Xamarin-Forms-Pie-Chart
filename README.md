# Xamarin-Forms-Pie-Chart

 Enrich your mobile application with Pie Charts.
  
Supported platforms:

      1) Xamarin for Android
      2) Windows Phone Silverlight
      3) Windows Phone RT
      4) Windows Store
      iOS is not supported yet!
      
<img src="https://github.com/HoussemDellai/Xamarin-Forms-Pie-Chart/blob/master/Screenshots/CrossPieCharts_screenshot.png?raw=true"/>

To add a Pie Chart control from your Xamarin Forms project:

var crossPieChartView = new CrossPieChartView<br/>
{<br/>
&nbsp;			Progress = 60,<br/>
&nbsp;  		ProgressColor = Color.Green,<br/>
&nbsp;  		ProgressBackgroundColor = Color.Gray,<br/>
&nbsp;  		StrokeThickness = Device.OnPlatform(10, 20, 80),<br/>
&nbsp;  		Radius = Device.OnPlatform(100, 180, 160),<br/>
&nbsp;  		BackgroundColor = Color.White<br/>
};<br/>
                       

The nuget package is available at : https://www.nuget.org/packages/Xam.FormsPlugin.CrossPieChart/

This plugin was built developed using existing work from:

Pascal Welsch : https://github.com/passsy/android-HoloCircularProgressBar/
Timo Korinth : http://timokorinth.de/creating-circular-progress-bar-wpf-silverlight/
