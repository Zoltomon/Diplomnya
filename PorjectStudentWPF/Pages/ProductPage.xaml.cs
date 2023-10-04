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
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
            CmbBxProd.SelectionChanged += CmbBxProd_SelectionChanged;
        }
        private void CmbBxProd_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Проверяем, выбран ли "тайтл" (первый элемент)
            if (CmbBxProd.SelectedIndex == 0)
            {
                // Делаем что-то, например, очищаем выбор
                CmbBxProd.SelectedIndex = -1;
            }
        }
    }
}
