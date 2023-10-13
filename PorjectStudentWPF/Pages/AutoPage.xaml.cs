
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using PorjectStudentWPF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
using System.Windows.Threading;

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

        private async void BtnAuto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxbLog.Text == null || TxbPass.Password == null)
                {
                    MessageBox.Show("Введите данные");
                }
                else
                {
                    string url = $"https://localhost:7089/api/User?UserLogin={TxbLog.Text}&UserPassword={TxbPass.Password}";
                    HttpClient client = new HttpClient();

                    var response = await client.GetAsync(url);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(TxbLog.Text) && !string.IsNullOrEmpty(TxbPass.Password))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            NavigateClass.navigate.Navigate(new MainPage());
                            MessageBox.Show("Все хорошо");
                        }
                    }
                }

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
