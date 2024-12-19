using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace HotelDishManagement
{
    public partial class CategoriesPage : Page
    {
        private List<Category> largeCategories = new List<Category>
        {
            new Category { Name = "Asian Food", ImagePath = "Assets/asian_food.jpg", Subcategories = new List<SubCategory>
                {
                    new SubCategory { Name = "Chinese Food", ImagePath = "Assets/chinese_food.jpg" },
                    new SubCategory { Name = "Thai Food", ImagePath = "Assets/thai_food.jpg" }
                }
            },
            new Category { Name = "Fast Food", ImagePath = "Assets/fast_food.jpg", Subcategories = new List<SubCategory>
                {
                    new SubCategory { Name = "Burgers", ImagePath = "Assets/burgers.jpg" },
                    new SubCategory { Name = "Pizza", ImagePath = "Assets/pizza.jpg" }
                }
            }
        };

        private List<Category> smallCategories = new List<Category>
        {
            new Category { Name = "Desserts", ImagePath = "Assets/desserts.jpg" },
            new Category { Name = "Drinks", ImagePath = "Assets/drinks.jpg" },
            new Category { Name = "Vegetarian", ImagePath = "Assets/vegetarian.jpg" }
        };

        public CategoriesPage()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void LoadCategories()
        {
            LargeCategoriesGrid.Children.Clear();
            SmallCategoriesGrid.Children.Clear();

            foreach (var category in largeCategories)
            {
                var categoryCard = CreateCategoryCard(category, true);
                LargeCategoriesGrid.Children.Add(categoryCard);
            }

            foreach (var category in smallCategories)
            {
                var categoryCard = CreateCategoryCard(category, false);
                SmallCategoriesGrid.Children.Add(categoryCard);
            }
        }

        private Border CreateCategoryCard(Category category, bool isLargeCategory)
        {
            var border = new Border
            {
                Background = System.Windows.Media.Brushes.White,
                BorderBrush = System.Windows.Media.Brushes.LightGray,
                BorderThickness = new Thickness(2),
                CornerRadius = new CornerRadius(15),
                Margin = new Thickness(15),
                Padding = new Thickness(10)
            };

            var stackPanel = new StackPanel();

            // Add category image
            var image = new Image
            {
                Source = new System.Windows.Media.Imaging.BitmapImage(new System.Uri(category.ImagePath, System.UriKind.Relative)),
                Height = 180,
                Width = 240,
                Margin = new Thickness(0, 10, 0, 10),
                Stretch = System.Windows.Media.Stretch.UniformToFill
            };
            stackPanel.Children.Add(image);

            // Add category name
            stackPanel.Children.Add(new TextBlock
            {
                Text = category.Name,
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 5, 0, 5),
                Foreground = System.Windows.Media.Brushes.Black,
                TextAlignment = TextAlignment.Center
            });

            // Subcategories button for large categories
            if (isLargeCategory && category.Subcategories != null)
            {
                var viewSubcategoriesButton = new Button
                {
                    Content = "View Subcategories",
                    Background = System.Windows.Media.Brushes.DodgerBlue,
                    Foreground = System.Windows.Media.Brushes.White,
                    Height = 40,
                    Width = 160,
                    Margin = new Thickness(0, 10, 0, 0)
                };
                viewSubcategoriesButton.Click += (s, e) => ShowSubcategories(category);
                stackPanel.Children.Add(viewSubcategoriesButton);
            }

            // Action buttons
            var buttonsPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 15, 0, 0) };

            var editButton = new Button
            {
                Content = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Children =
                    {
                        new Image { Source = new System.Windows.Media.Imaging.BitmapImage(new System.Uri("Assets/edit_icon.png", System.UriKind.Relative)), Width = 20, Height = 20, Margin = new Thickness(0,0,5,0) },
                        new TextBlock { Text = "Edit", VerticalAlignment = VerticalAlignment.Center }
                    }
                },
                Width = 100,
                Height = 40,
                Background = System.Windows.Media.Brushes.LightGray,
                Foreground = System.Windows.Media.Brushes.Black,
                Margin = new Thickness(10, 0, 10, 0)
            };
            editButton.Click += (s, e) => EditCategory(category);

            var deleteButton = new Button
            {
                Content = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Children =
                    {
                        new Image { Source = new System.Windows.Media.Imaging.BitmapImage(new System.Uri("Assets/delete_icon.png", System.UriKind.Relative)), Width = 20, Height = 20, Margin = new Thickness(0,0,5,0) },
                        new TextBlock { Text = "Delete", VerticalAlignment = VerticalAlignment.Center }
                    }
                },
                Width = 100,
                Height = 40,
                Background = System.Windows.Media.Brushes.Red,
                Foreground = System.Windows.Media.Brushes.White
            };
            deleteButton.Click += (s, e) => DeleteCategory(category);

            buttonsPanel.Children.Add(editButton);
            buttonsPanel.Children.Add(deleteButton);

            stackPanel.Children.Add(buttonsPanel);

            border.Child = stackPanel;
            return border;
        }

        private void ShowSubcategories(Category category)
        {
            var subcategoriesWindow = new SubcategoriesWindow(category.Subcategories);
            subcategoriesWindow.ShowDialog();
        }

        private void EditCategory(Category category)
        {
            MessageBox.Show($"Edit {category.Name} functionality will be added later.");
        }

        private void DeleteCategory(Category category)
        {
            if (MessageBox.Show($"Are you sure you want to delete {category.Name}?", "Confirm Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                largeCategories.Remove(category);
                smallCategories.Remove(category);
                LoadCategories();
            }
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            var addCategoryWindow = new AddCategoryWindow();
            if (addCategoryWindow.ShowDialog() == true)
            {
                smallCategories.Add(new Category
                {
                    Name = addCategoryWindow.CategoryName,
                    ImagePath = addCategoryWindow.ImagePath
                });
                LoadCategories();
            }
        }
    }

    public class Category
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public List<SubCategory> Subcategories { get; set; }
    }

    public class SubCategory
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
