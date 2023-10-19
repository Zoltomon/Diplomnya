
using BCrypt.Net;
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
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var userResponseList = JsonConvert.DeserializeObject<List<UserClass>>(responseContent);
                        if (userResponseList.Count > 0)
                        {
                            var userStatus = userResponseList[0].UserStatus;
                            switch(userStatus)
                            {
                                case "Аккаунт активен":
                                    NavigateClass.navigate.Navigate(new MainPage());
                                    break;
                                case "Аккаунт неактивен":
                                    MessageBox.Show("Ваш аккаунт заблокирован\nОбратитесь к администратору вашей системы");
                                    break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пользователь не найден");
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
