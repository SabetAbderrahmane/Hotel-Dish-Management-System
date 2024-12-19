using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace HotelDishManagement
{
    public partial class SubcategoriesWindow : Window
    {
        public SubcategoriesWindow(List<SubCategory> subcategories)
        {
            InitializeComponent();
            LoadSubcategories(subcategories);
        }

        private void LoadSubcategories(List<SubCategory> subcategories)
        {
            foreach (var subcategory in subcategories)
            {
                var card = new Border
                {
                    Background = System.Windows.Media.Brushes.White,
                    BorderBrush = System.Windows.Media.Brushes.LightGray,
                    BorderThickness = new Thickness(1),
                    CornerRadius = new CornerRadius(10),
                    Padding = new Thickness(10),
                    Margin = new Thickness(10),
                    Width = 150,
                    Height = 200
                };

                var stackPanel = new StackPanel();

                var image = new Image
                {
                    Source = new System.Windows.Media.Imaging.BitmapImage(new System.Uri(subcategory.ImagePath, System.UriKind.Relative)),
                    Height = 100,
                    Stretch = System.Windows.Media.Stretch.UniformToFill
                };
                stackPanel.Children.Add(image);

                stackPanel.Children.Add(new TextBlock
                {
                    Text = subcategory.Name,
                    FontSize = 14,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 5, 0, 0),
                    TextAlignment = TextAlignment.Center
                });

                card.Child = stackPanel;
                SubcategoriesWrapPanel.Children.Add(card);
            }
        }
    }
}
