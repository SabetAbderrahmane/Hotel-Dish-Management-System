using Microsoft.Win32;
using System.Windows;

namespace HotelDishManagement
{
    public partial class AddCategoryWindow : Window
    {
        public string CategoryName { get; private set; }
        public string ImagePath { get; private set; }

        public AddCategoryWindow()
        {
            InitializeComponent();
        }

        // Handle Browse Button Click
        private void BrowseImage_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png",
                Title = "Select a Category Image"
            };

            if (dialog.ShowDialog() == true)
            {
                ImagePath = dialog.FileName;
                ImagePathText.Text = System.IO.Path.GetFileName(ImagePath); // Display file name
            }
        }

        // Handle Save Button Click
        private void SaveCategory_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CategoryNameBox.Text) || string.IsNullOrWhiteSpace(ImagePath))
            {
                MessageBox.Show("Please provide both a category name and an image.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            CategoryName = CategoryNameBox.Text;
            DialogResult = true; // Close window and return true
        }
    }
}
