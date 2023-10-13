using PorjectStudentWPF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PorjectStudentWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            NavigateClass.navigate = FrmMainPage;
        }

        private void BtnMain_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string hexColor = "#4B9BD6";
                
                SolidColorBrush colorBrush = new SolidColorBrush((Color) ColorConverter.ConvertFromString(hexColor));
                BtnMain.Foreground = colorBrush;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigateClass.navigate.Navigate(new ProductPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
