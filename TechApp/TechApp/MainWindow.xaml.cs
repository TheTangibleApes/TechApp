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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SignUpPage Apt1 = new SignUpPage();
            Apt1.Show();
            MessageBox.Show("Signuppage move");

            // Hide the MainWindow until later
            this.Hide();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Camera CameraSystem = new Camera();
            CameraSystem.Show();

            // Hide the MainWindow until later
            this.Hide();
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

        private void Test(object sender, RoutedEventArgs e)
        {
            Process.Start("osk.exe");
        }
    }
}
