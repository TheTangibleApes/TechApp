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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

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
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
         
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

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Clicked(object sender, TouchEventArgs e)
        {
            SignUpPage Apt1 = new SignUpPage();
            Apt1.Show();

            // Hide the MainWindow until later
            this.Hide();
        }

        private void Tapped(object sender, MouseButtonEventArgs e)
        {
            SignUpPage Apt1 = new SignUpPage();
            Apt1.Show();

            // Hide the MainWindow until later
            this.Hide();
        }

        private void next_screen(object sender, MouseButtonEventArgs e)
        {
            SetUpAppointment Apt1 = new SetUpAppointment();
            Apt1.Show();

            // Hide the MainWindow until later
            this.Hide();
        }

        private void prev_page(object sender, MouseButtonEventArgs e)
        {
            MainWindow Apt1 = new MainWindow();
            Apt1.Show();

            // Hide the MainWindow until later
            this.Hide();
        }
    }
}
