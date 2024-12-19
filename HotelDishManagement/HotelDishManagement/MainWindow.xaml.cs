using System.Collections.Generic;
using System.Windows;

namespace HotelDishManagement
{
    public partial class MainWindow : Window
    {
        // Hardcoded Staff Credentials (to be replaced with database later)
        private readonly Dictionary<string, string> staffCredentials = new Dictionary<string, string>
        {
            { "admin", "12345" },
            { "staff1", "password1" },
            { "staff2", "securepass" }
        };

        public MainWindow()
        {
            InitializeComponent();
            DatabaseInitializer.InitializeDatabase();

        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string staffID = txtStaffID.Text;
            string password = txtPassword.Password;

            // Validate credentials
            if (staffCredentials.ContainsKey(staffID) && staffCredentials[staffID] == password)
            {
                // Open Dashboard if login is successful
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Close(); // Close the login window
            }
            else
            {
                MessageBox.Show("Invalid Staff ID or Password", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
