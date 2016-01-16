Two steps to add a pie chart to your xaml page :

1) Add the following attribute to your Page node :

xmlns:pieChartWinRT="using:CrossPieCharts.WinRT"


2) Add the following XAML code to your MainPage.cs.xaml :

<pieChartWinRT:PieChart Percentage="70"
                        Radius="150"
                        BackgroundColor="AliceBlue"
                        Segment360Color="DarkGoldenrod"
                        SegmentColor="DarkCyan"
                        StrokeThickness="50" />

Optionally, you can add a TextBlock to display percentage :

<TextBlock Text="70%"
           VerticalAlignment="Center"
           HorizontalAlignment="Center"
           FontWeight="Bold"
           FontSize="90"
           Foreground="Gray" />


