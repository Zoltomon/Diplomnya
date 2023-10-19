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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxbEmail.Text == null || TxbLogin.Text == null || TxbPass.Text == null)
                {
                    MessageBox.Show("Введите данные");
                }
                if (TxbPass != TxbCopyPass)
                {
                    MessageBox.Show("Неверно повторен пароль");
                }
                else
                {
                    MessageBox.Show("Все хорошо");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigateClass.navigate.GoBack();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
