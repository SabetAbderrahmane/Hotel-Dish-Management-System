using System.Configuration;
using System.Windows;
using System.Windows.Controls;

namespace HotelDishManagement
{
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();

            // Set default page to Dashboard
            ContentFrame.Navigate(new DashboardPage());
        }

        // Method to handle button navigation
        private void NavigatePage(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            switch (button.Content.ToString())
            {
                case "Dashboard":
                    ContentFrame.Navigate(new DashboardPage());
                    break;
                case "Categories":
                    ContentFrame.Navigate(new CategoriesPage());
                    break;
                case "Products":
                    ContentFrame.Navigate(new ProductsPage());
                    break;
                case "Tables":
                    ContentFrame.Navigate(new TablesPage());
                    break;
                case "Staff":
                    ContentFrame.Navigate(new StaffPage());
                    break;
                case "Reports":
                    ContentFrame.Navigate(new ReportsPage());
                    break;
                case "Settings":
                    ContentFrame.Navigate(new SettingsPage());
                    break;
            }
        }

        // Method to handle the Exit button
        private void ExitApplication(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
