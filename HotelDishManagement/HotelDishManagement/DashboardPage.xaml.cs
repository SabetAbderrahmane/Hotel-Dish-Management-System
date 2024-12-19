using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Controls;

namespace HotelDishManagement
{
    public partial class DashboardPage : Page
    {
        public DashboardPage()
        {
            InitializeComponent();

            // Sales Trend Data
            SalesTrendChart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Daily Sales",
                    Values = new ChartValues<double> { 500, 600, 700, 800, 900 }
                }
            };

            // Product Popularity Data
            ProductPopularityChart.Series = new SeriesCollection
            {
                new PieSeries { Title = "Burgers", Values = new ChartValues<double> { 20 }, DataLabels = true },
                new PieSeries { Title = "Pizzas", Values = new ChartValues<double> { 35 }, DataLabels = true },
                new PieSeries { Title = "Drinks", Values = new ChartValues<double> { 45 }, DataLabels = true }
            };

            // Occupancy Rate Data
            OccupancyRateChart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Tables",
                    Values = new ChartValues<int> { 10, 20, 15, 25 }
                }
            };
        }
    }
}
