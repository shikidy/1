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
using WpfApp1.Utils;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            var user_id = DBworker.Check_login(LoginTextBox.Text, PasswordTextBox.Text);
            if (user_id == -1)
            {
                MessageBox.Show("Неверный логин или пароль!");
                return;
            }
            Utils.DataHolder.UserID = user_id;
            var newwindow = new Views.ControlPanel();
            newwindow.Show();
            this.Hide();

        }
    }
}
