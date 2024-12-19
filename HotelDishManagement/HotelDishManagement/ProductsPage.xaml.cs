using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HotelDishManagement
{
    public partial class ProductsPage : Page
    {
        public ObservableCollection<Dish> Dishes { get; set; } = new ObservableCollection<Dish>();

        public ProductsPage()
        {
            InitializeComponent();
            LoadDishes(); // Load hardcoded dishes
            DishDataGrid.ItemsSource = Dishes; // Bind DataGrid to dishes
        }

        private void LoadDishes()
        {
            // Hardcoded list of 10 dishes
            Dishes.Add(new Dish { Number = 1, Name = "Sushi", Price = 12.99, Introduction = "Fresh fish on rice", Category = "Asian Food", Type = "Meat", IsSpecial = true });
            Dishes.Add(new Dish { Number = 2, Name = "Pizza", Price = 8.99, Introduction = "Classic cheese pizza", Category = "Fast Food", Type = "Vegetarian", IsSpecial = false });
            Dishes.Add(new Dish { Number = 3, Name = "Ice Cream", Price = 4.49, Introduction = "Vanilla dessert", Category = "Desserts", Type = "Vegetarian", IsSpecial = true });
            Dishes.Add(new Dish { Number = 4, Name = "Ramen", Price = 10.99, Introduction = "Japanese noodle soup", Category = "Asian Food", Type = "Meat", IsSpecial = false });
            Dishes.Add(new Dish { Number = 5, Name = "Burger", Price = 9.49, Introduction = "Beef burger", Category = "Fast Food", Type = "Meat", IsSpecial = true });
            Dishes.Add(new Dish { Number = 6, Name = "Brownie", Price = 3.99, Introduction = "Chocolate dessert", Category = "Desserts", Type = "Vegetarian", IsSpecial = false });
            Dishes.Add(new Dish { Number = 7, Name = "Pad Thai", Price = 12.49, Introduction = "Stir-fried noodles with peanuts", Category = "Asian Food", Type = "Vegetarian", IsSpecial = true });
            Dishes.Add(new Dish { Number = 8, Name = "Tacos", Price = 7.99, Introduction = "Mexican-style tacos", Category = "Fast Food", Type = "Meat", IsSpecial = false });
            Dishes.Add(new Dish { Number = 9, Name = "Cheesecake", Price = 6.99, Introduction = "Rich and creamy cheesecake", Category = "Desserts", Type = "Vegetarian", IsSpecial = true });
            Dishes.Add(new Dish { Number = 10, Name = "Spring Rolls", Price = 5.49, Introduction = "Crispy vegetarian rolls", Category = "Asian Food", Type = "Vegetarian", IsSpecial = false });
        }

        private void AddDishButton_Click(object sender, RoutedEventArgs e)
        {
            var newDish = new Dish
            {
                Number = int.Parse(DishNumberTextBox.Text),
                Name = DishNameTextBox.Text,
                Price = double.Parse(DishPriceTextBox.Text),
                Introduction = DishIntroductionTextBox.Text,
                Category = ((ComboBoxItem)DishCategoryComboBox.SelectedItem).Content.ToString(),
                Type = ((ComboBoxItem)DishTypeComboBox.SelectedItem).Content.ToString(),
                IsSpecial = SpecialDishCheckBox.IsChecked == true
            };

            Dishes.Add(newDish);
            ClearInputFields();
        }

        private void EditDishButton_Click(object sender, RoutedEventArgs e)
        {
            if (DishDataGrid.SelectedItem is Dish selectedDish)
            {
                selectedDish.Name = DishNameTextBox.Text;
                selectedDish.Price = double.Parse(DishPriceTextBox.Text);
                selectedDish.Introduction = DishIntroductionTextBox.Text;
                selectedDish.Category = ((ComboBoxItem)DishCategoryComboBox.SelectedItem).Content.ToString();
                selectedDish.Type = ((ComboBoxItem)DishTypeComboBox.SelectedItem).Content.ToString();
                selectedDish.IsSpecial = SpecialDishCheckBox.IsChecked == true;

                DishDataGrid.Items.Refresh();
                ClearInputFields();
            }
        }

        private void DeleteDishButton_Click(object sender, RoutedEventArgs e)
        {
            if (DishDataGrid.SelectedItem is Dish selectedDish)
            {
                Dishes.Remove(selectedDish);
            }
        }

        private void QueryDishByInput_Click(object sender, RoutedEventArgs e)
        {
            string query = QueryInputTextBox.Text.ToLower();

            var filteredDishes = Dishes.Where(d =>
                d.Number.ToString().Contains(query) ||
                d.Name.ToLower().Contains(query) ||
                d.Introduction.ToLower().Contains(query) ||
                d.Category.ToLower().Contains(query) ||
                d.Price.ToString("F2").Contains(query)).ToList();

            if (filteredDishes.Any())
            {
                DishDataGrid.ItemsSource = filteredDishes;
            }
            else
            {
                MessageBox.Show("No matching dishes found!", "Query Results", MessageBoxButton.OK, MessageBoxImage.Information);
                DishDataGrid.ItemsSource = Dishes; // Reset to all dishes
            }
        }

        private void FilterByPrice_Click(object sender, RoutedEventArgs e)
        {
            var filteredDishes = Dishes.Where(d => d.Price < 5).ToList();

            if (filteredDishes.Any())
            {
                DishDataGrid.ItemsSource = filteredDishes;
            }
            else
            {
                MessageBox.Show("No dishes under $5 found!", "Filter Results", MessageBoxButton.OK, MessageBoxImage.Information);
                DishDataGrid.ItemsSource = Dishes; // Reset to all dishes
            }
        }

        private void FilterBySpecial_Click(object sender, RoutedEventArgs e)
        {
            var filteredDishes = Dishes.Where(d => d.IsSpecial).ToList();

            if (filteredDishes.Any())
            {
                DishDataGrid.ItemsSource = filteredDishes;
            }
            else
            {
                MessageBox.Show("No special dishes found!", "Filter Results", MessageBoxButton.OK, MessageBoxImage.Information);
                DishDataGrid.ItemsSource = Dishes; // Reset to all dishes
            }
        }

        private void ClearInputFields()
        {
            DishNumberTextBox.Clear();
            DishNameTextBox.Clear();
            DishPriceTextBox.Clear();
            DishIntroductionTextBox.Clear();
            DishCategoryComboBox.SelectedIndex = -1;
            DishTypeComboBox.SelectedIndex = -1;
            SpecialDishCheckBox.IsChecked = false;
        }

        private void AddDishButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DishNumberTextBox.Text) ||
        string.IsNullOrWhiteSpace(DishNameTextBox.Text) ||
        string.IsNullOrWhiteSpace(DishPriceTextBox.Text) ||
        string.IsNullOrWhiteSpace(DishIntroductionTextBox.Text) ||
        DishCategoryComboBox.SelectedItem == null ||
        DishTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields before adding a dish.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var newDish = new Dish
                {
                    Number = int.Parse(DishNumberTextBox.Text),
                    Name = DishNameTextBox.Text,
                    Price = double.Parse(DishPriceTextBox.Text),
                    Introduction = DishIntroductionTextBox.Text,
                    Category = ((ComboBoxItem)DishCategoryComboBox.SelectedItem).Content.ToString(),
                    Type = ((ComboBoxItem)DishTypeComboBox.SelectedItem).Content.ToString(),
                    IsSpecial = SpecialDishCheckBox.IsChecked == true
                };

                Dishes.Add(newDish);
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the dish: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    public class Dish
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Introduction { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public bool IsSpecial { get; set; }
    }
}
