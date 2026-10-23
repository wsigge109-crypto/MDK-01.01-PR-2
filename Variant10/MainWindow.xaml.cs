using System.Windows;
using System.Windows.Controls;
using Variant10.Pages;

namespace Variant10
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Открыть страницу задания: прячем меню, показываем рамку со страницей
        private void OpenPage(Page page)
        {
            PanelMenu.Visibility = Visibility.Collapsed;
            FrmMain.Visibility = Visibility.Visible;
            FrmMain.Navigate(page);
        }

        private void btnTask1_Click(object sender, RoutedEventArgs e) { OpenPage(new PageTask1()); }
        private void btnTask2_Click(object sender, RoutedEventArgs e) { OpenPage(new PageTask2()); }
        private void btnTask3_Click(object sender, RoutedEventArgs e) { OpenPage(new PageTask3()); }
        private void btnTask4_Click(object sender, RoutedEventArgs e) { OpenPage(new PageTask4()); }
        private void btnTask5_Click(object sender, RoutedEventArgs e) { OpenPage(new PageTask5()); }

        // Назад: прячем страницу, показываем меню
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrmMain.Visibility = Visibility.Collapsed;
            FrmMain.Content = null;
            PanelMenu.Visibility = Visibility.Visible;
        }
    }
}
