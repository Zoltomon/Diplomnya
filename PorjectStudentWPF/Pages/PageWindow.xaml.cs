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
using System.Windows.Shapes;

namespace PorjectStudentWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageWindow.xaml
    /// </summary>
    public partial class PageWindow : Window
    {
        public PageWindow()
        {
            InitializeComponent();
            NavigateClass.navigate = FrmMainWindow;
            FrmMainWindow.Navigate(new MainPage());
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.RightButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void BtnDashWndw_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Minimized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void BtnMaxWndw_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void BtnExtWndw_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
