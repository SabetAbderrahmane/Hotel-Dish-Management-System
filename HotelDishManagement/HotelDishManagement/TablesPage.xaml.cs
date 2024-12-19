using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;

namespace HotelDishManagement
{
    public partial class TablesPage : Page
    {
        public ObservableCollection<Table> Tables { get; set; } = new ObservableCollection<Table>();
        public ChartValues<int> Available { get; set; } = new ChartValues<int>();
        public ChartValues<int> Reserved { get; set; } = new ChartValues<int>();
        public ChartValues<int> Occupied { get; set; } = new ChartValues<int>();

        public TablesPage()
        {
            InitializeComponent();

            // Sample data
            Tables.Add(new Table { TableNumber = 1, Status = "Available" });
            Tables.Add(new Table { TableNumber = 2, Status = "Reserved" });
            Tables.Add(new Table { TableNumber = 3, Status = "Occupied" });
            Tables.Add(new Table { TableNumber = 4, Status = "Available" });
            Tables.Add(new Table { TableNumber = 5, Status = "Reserved" });
            Tables.Add(new Table { TableNumber = 6, Status = "Occupied" });
            Tables.Add(new Table { TableNumber = 7, Status = "Available" });
            Tables.Add(new Table { TableNumber = 8, Status = "Occupied" });
            Tables.Add(new Table { TableNumber = 9, Status = "Reserved" });
            Tables.Add(new Table { TableNumber = 10, Status = "Available" });
            Tables.Add(new Table { TableNumber = 11, Status = "Available" });
            Tables.Add(new Table { TableNumber = 12, Status = "Reserved" });
            Tables.Add(new Table { TableNumber = 13, Status = "Occupied" });
            Tables.Add(new Table { TableNumber = 14, Status = "Reserved" });
            Tables.Add(new Table { TableNumber = 15, Status = "Available" });

            TableListView.ItemsSource = Tables;
            UpdateChart();
        }

        private void UpdateChart()
        {
            var availableCount = Tables.Count(t => t.Status == "Available");
            var reservedCount = Tables.Count(t => t.Status == "Reserved");
            var occupiedCount = Tables.Count(t => t.Status == "Occupied");

            TableStatusChart.Series = new SeriesCollection
            {
                new PieSeries { Title = "Available", Values = new ChartValues<int> { availableCount }, DataLabels = true },
                new PieSeries { Title = "Reserved", Values = new ChartValues<int> { reservedCount }, DataLabels = true },
                new PieSeries { Title = "Occupied", Values = new ChartValues<int> { occupiedCount }, DataLabels = true }
            };
        }

        private void AddReservationButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NumberOfGuestsTextBox.Text, out int guests) && !string.IsNullOrWhiteSpace(CustomerNameTextBox.Text))
            {
                Tables.Add(new Table
                {
                    TableNumber = Tables.Count + 1,
                    Status = "Reserved"
                });

                TableListView.Items.Refresh();
                UpdateChart();
                MessageBox.Show("Reservation Added Successfully!");
            }
            else
            {
                MessageBox.Show("Please fill all required fields.");
            }
        }

        private void FilterAvailable_Click(object sender, RoutedEventArgs e)
        {
            TableListView.ItemsSource = Tables.Where(t => t.Status == "Available");
        }

        private void FilterReserved_Click(object sender, RoutedEventArgs e)
        {
            TableListView.ItemsSource = Tables.Where(t => t.Status == "Reserved");
        }

        private void FilterOccupied_Click(object sender, RoutedEventArgs e)
        {
            TableListView.ItemsSource = Tables.Where(t => t.Status == "Occupied");
        }
    }

    public class Table
    {
        public int TableNumber { get; set; }
        public string Status { get; set; }
    }
}
