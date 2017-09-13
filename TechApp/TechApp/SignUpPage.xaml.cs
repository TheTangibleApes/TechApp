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

namespace TechApp
{
    /// <summary>
    /// Interaction logic for SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Window
    {
        public SignUpPage()
        {
            InitializeComponent();
            MessageBox.Show("Init done");
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
            MessageBox.Show("sizing done");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow HomeScreen = new MainWindow();
            HomeScreen.Show();

            // Hide the MainWindow until later
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SetUpAppointment Apt2 = new SetUpAppointment();
            Apt2.Show();

            // Hide the MainWindow until later
            this.Close();
        }
    }
}
