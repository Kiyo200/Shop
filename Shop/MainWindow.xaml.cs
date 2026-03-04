using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowHome();
        }


        private void ShowHome()
        {
            PageHome.Visibility = Visibility.Visible;
            PageProducts.Visibility = Visibility.Collapsed;
            PageCart.Visibility = Visibility.Collapsed;
            PageAdminAdd.Visibility = Visibility.Collapsed;
            PageAdminDelete.Visibility = Visibility.Collapsed;
            PageAdminEdit.Visibility = Visibility.Collapsed;
        }

        private void ShowProducts()
        {
            PageHome.Visibility = Visibility.Collapsed;
            PageProducts.Visibility = Visibility.Visible;
            PageCart.Visibility = Visibility.Collapsed;
            PageAdminAdd.Visibility = Visibility.Collapsed;
            PageAdminDelete.Visibility = Visibility.Collapsed;
            PageAdminEdit.Visibility = Visibility.Collapsed;
        }

        private void ShowCart()
        {
            PageHome.Visibility = Visibility.Collapsed;
            PageProducts.Visibility = Visibility.Collapsed;
            PageCart.Visibility = Visibility.Visible;
            PageAdminAdd.Visibility = Visibility.Collapsed;
            PageAdminDelete.Visibility = Visibility.Collapsed;
            PageAdminEdit.Visibility = Visibility.Collapsed;
        }

        private void ShowAdminAdd()
        {
            PageHome.Visibility = Visibility.Collapsed;
            PageProducts.Visibility = Visibility.Collapsed;
            PageCart.Visibility = Visibility.Collapsed;
            PageAdminAdd.Visibility = Visibility.Visible;
            PageAdminDelete.Visibility = Visibility.Collapsed;
            PageAdminEdit.Visibility = Visibility.Collapsed;
        }

        private void ShowAdminDelete()
        {
            PageHome.Visibility = Visibility.Collapsed;
            PageProducts.Visibility = Visibility.Collapsed;
            PageCart.Visibility = Visibility.Collapsed;
            PageAdminAdd.Visibility = Visibility.Collapsed;
            PageAdminDelete.Visibility = Visibility.Visible;
            PageAdminEdit.Visibility = Visibility.Collapsed;
        }

        private void ShowAdminEdit()
        {
            PageHome.Visibility = Visibility.Collapsed;
            PageProducts.Visibility = Visibility.Collapsed;
            PageCart.Visibility = Visibility.Collapsed;
            PageAdminAdd.Visibility = Visibility.Collapsed;
            PageAdminDelete.Visibility = Visibility.Collapsed;
            PageAdminEdit.Visibility = Visibility.Visible;
        }

        // --- Button click handlers ---

        private void MainPageButton_Click(object sender, RoutedEventArgs e) => ShowHome();
        private void ProductsButton_Click(object sender, RoutedEventArgs e) => ShowProducts();
        private void CartButton_Click(object sender, RoutedEventArgs e) => ShowCart();
        private void AdminAddButton_Click(object sender, RoutedEventArgs e) => ShowAdminAdd();
        private void AdminDeleteButton_Click(object sender, RoutedEventArgs e) => ShowAdminDelete();
        private void AdminEditButton_Click(object sender, RoutedEventArgs e) => ShowAdminEdit();

        // --- Discount page logic ---

        private void DiscountSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (DiscountLabel == null) return;

            int discount = (int)DiscountSlider.Value;
            DiscountLabel.Text = $"{discount}%";

            if (decimal.TryParse(CurrentPriceLabel.Text.Replace(" Ft", "").Trim(), out decimal basePrice))
            {
                decimal discounted = basePrice * (1 - discount / 100m);
                DiscountedPriceLabel.Text = $"{discounted:0.##} Ft";
            }
        }

        private void SaveDiscount_Click(object sender, RoutedEventArgs e)
        {
            string productName = EditProductNameBox.Text.Trim();
            int discount = (int)DiscountSlider.Value;

            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("Kérjük, add meg a termék nevét.", "Hiányzó adat",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // TODO: save discount to your data source here
            MessageBox.Show($"'{productName}' termékre {discount}% kedvezmény mentve!",
                            "Sikeres mentés", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}