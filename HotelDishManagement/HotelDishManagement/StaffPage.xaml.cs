using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;

namespace HotelDishManagement
{
    public partial class StaffPage : Page
    {
        public ObservableCollection<Staff> StaffList { get; set; } = new ObservableCollection<Staff>();

        public StaffPage()
        {
            InitializeComponent();
            StaffDataGrid.ItemsSource = StaffList;
            LoadSampleData();
            UpdateChart();
        }

        private void LoadSampleData()
        {
            StaffList.Add(new Staff { StaffId = 1, Name = "Alice Johnson", Role = "Manager", Contact = "123-456-7890", Address = "123 Main St" });
            StaffList.Add(new Staff { StaffId = 2, Name = "Bob Smith", Role = "Waiter", Contact = "234-567-8901", Address = "456 Pine St" });
            StaffList.Add(new Staff { StaffId = 3, Name = "Charlie Brown", Role = "Chef", Contact = "345-678-9012", Address = "789 Elm St" });
            StaffList.Add(new Staff { StaffId = 4, Name = "Daisy Miller", Role = "Cleaner", Contact = "456-789-0123", Address = "321 Oak St" });
            StaffList.Add(new Staff { StaffId = 5, Name = "Edward Davis", Role = "Waiter", Contact = "567-890-1234", Address = "654 Maple St" });
            StaffList.Add(new Staff { StaffId = 6, Name = "Fiona Adams", Role = "Chef", Contact = "678-901-2345", Address = "987 Birch St" });
            StaffList.Add(new Staff { StaffId = 7, Name = "George Wilson", Role = "Manager", Contact = "789-012-3456", Address = "159 Willow St" });
            StaffList.Add(new Staff { StaffId = 8, Name = "Helen Carter", Role = "Cleaner", Contact = "890-123-4567", Address = "753 Cedar St" });
            StaffList.Add(new Staff { StaffId = 9, Name = "Ian Taylor", Role = "Waiter", Contact = "901-234-5678", Address = "951 Ash St" });
            StaffList.Add(new Staff { StaffId = 10, Name = "Jack White", Role = "Chef", Contact = "012-345-6789", Address = "357 Spruce St" });
            StaffList.Add(new Staff { StaffId = 11, Name = "Kathy Green", Role = "Manager", Contact = "123-456-7891", Address = "468 Poplar St" });
            StaffList.Add(new Staff { StaffId = 12, Name = "Liam Martin", Role = "Waiter", Contact = "234-567-8902", Address = "357 Elmwood Ave" });
            StaffList.Add(new Staff { StaffId = 13, Name = "Mia Scott", Role = "Cleaner", Contact = "345-678-9013", Address = "159 Oakwood Dr" });
            StaffList.Add(new Staff { StaffId = 14, Name = "Nathan Hill", Role = "Chef", Contact = "456-789-0124", Address = "753 Redwood Ln" });
            StaffList.Add(new Staff { StaffId = 15, Name = "Olivia Evans", Role = "Manager", Contact = "567-890-1235", Address = "951 Cypress Rd" });
            StaffList.Add(new Staff { StaffId = 16, Name = "Peter Young", Role = "Cleaner", Contact = "678-901-2346", Address = "357 Alder St" });
            StaffList.Add(new Staff { StaffId = 17, Name = "Quinn Harris", Role = "Chef", Contact = "789-012-3457", Address = "654 Dogwood Ln" });
            StaffList.Add(new Staff { StaffId = 18, Name = "Rachel Moore", Role = "Waiter", Contact = "890-123-4568", Address = "468 Walnut Dr" });
            StaffList.Add(new Staff { StaffId = 19, Name = "Samuel King", Role = "Waiter", Contact = "901-234-5679", Address = "159 Beech Ave" });
            StaffList.Add(new Staff { StaffId = 20, Name = "Tina Brooks", Role = "Cleaner", Contact = "012-345-6781", Address = "753 Maple Ln" });
            StaffList.Add(new Staff { StaffId = 21, Name = "Uma Baker", Role = "Manager", Contact = "123-456-7892", Address = "951 Cedar Blvd" });
            StaffList.Add(new Staff { StaffId = 22, Name = "Victor Hughes", Role = "Chef", Contact = "234-567-8903", Address = "357 Spruce Rd" });
            StaffList.Add(new Staff { StaffId = 23, Name = "Wendy Ward", Role = "Waiter", Contact = "345-678-9014", Address = "654 Pine St" });
            StaffList.Add(new Staff { StaffId = 24, Name = "Xavier Price", Role = "Cleaner", Contact = "456-789-0125", Address = "159 Oak Blvd" });
            StaffList.Add(new Staff { StaffId = 25, Name = "Yara Collins", Role = "Waiter", Contact = "567-890-1236", Address = "753 Cypress St" });
            StaffList.Add(new Staff { StaffId = 26, Name = "Zane Parker", Role = "Chef", Contact = "678-901-2347", Address = "951 Willow Blvd" });
            StaffList.Add(new Staff { StaffId = 27, Name = "Anna Lopez", Role = "Manager", Contact = "789-012-3458", Address = "357 Birch Rd" });
            StaffList.Add(new Staff { StaffId = 28, Name = "Brian Reed", Role = "Cleaner", Contact = "890-123-4569", Address = "654 Ash Ln" });
            StaffList.Add(new Staff { StaffId = 29, Name = "Cathy Foster", Role = "Chef", Contact = "901-234-5670", Address = "159 Poplar Ave" });
            StaffList.Add(new Staff { StaffId = 30, Name = "David Hughes", Role = "Waiter", Contact = "012-345-6782", Address = "753 Beech Blvd" });
        }

        private void UpdateChart()
        {
            var roleGroups = StaffList.GroupBy(s => s.Role).Select(g => new { Role = g.Key, Count = g.Count() });

            RoleDistributionChart.Series = new SeriesCollection();
            foreach (var group in roleGroups)
            {
                RoleDistributionChart.Series.Add(new PieSeries
                {
                    Title = group.Role,
                    Values = new ChartValues<int> { group.Count },
                    DataLabels = true
                });
            }
        }

        private void AddStaffButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameTextBox.Text) && RoleComboBox.SelectedItem != null)
            {
                StaffList.Add(new Staff
                {
                    StaffId = StaffList.Count + 1,
                    Name = NameTextBox.Text,
                    Role = ((ComboBoxItem)RoleComboBox.SelectedItem).Content.ToString(),
                    Contact = ContactTextBox.Text,
                    Address = AddressTextBox.Text
                });

                StaffDataGrid.Items.Refresh();
                UpdateChart();
                ClearFields();
                MessageBox.Show("Staff added successfully!");
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.");
            }
        }

        private void ClearFields()
        {
            StaffIdTextBox.Clear();
            NameTextBox.Clear();
            RoleComboBox.SelectedIndex = -1;
            ContactTextBox.Clear();
            AddressTextBox.Clear();
        }
    }
}
