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
using PorjectStudentWPF.Classes;
using System.Windows.Shapes;

namespace PorjectStudentWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutoPage.xaml
    /// </summary>
    public partial class AutoPage : Page
    {
        public AutoPage()
        {
            InitializeComponent();
        }

        private void BtnAuto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigateClass.navigate.Navigate(new MainPage());
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigateClass.navigate.Navigate(new RegPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
