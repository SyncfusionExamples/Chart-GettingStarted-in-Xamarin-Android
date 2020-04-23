using Android.App;
using Android.OS;
using Com.Syncfusion.Charts;
using System.Collections.ObjectModel;
using Android.Graphics;

namespace Chart_GettingStarted
{
    [Activity( MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SfChart chart = new SfChart(this);
            chart.Title.Text = "Chart";
            chart.SetBackgroundColor(Color.White);

            //Initializing primary axis
            CategoryAxis primaryAxis = new CategoryAxis();
            primaryAxis.Title.Text = "Name";
            chart.PrimaryAxis = primaryAxis;

            //Initializing secondary Axis
            NumericalAxis secondaryAxis = new NumericalAxis();
            secondaryAxis.Title.Text = "Height (in cm)";
            chart.SecondaryAxis = secondaryAxis;

            ObservableCollection<ChartData> data = new ObservableCollection<ChartData>()
            {
                new ChartData { Name = "David", Height = 180 },
                new ChartData { Name = "Michael", Height = 170 },
                new ChartData { Name = "Steve", Height = 160 },
                new ChartData { Name = "Joel", Height = 182 }
            };

            //Initializing column series
            ColumnSeries series = new ColumnSeries();
            series.ItemsSource = data;
            series.XBindingPath = "Name";
            series.YBindingPath = "Height";

            series.DataMarker.ShowLabel = true;
            series.Label = "Heights";
            series.TooltipEnabled = true;

            chart.Series.Add(series);
            chart.Legend.Visibility = Visibility.Visible;
            SetContentView(chart); 
        }
    }

    public class ChartData
    {
        public string Name { get; set; }

        public double Height { get; set; }
    }
}

