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
        private Visitors TheSingleVisitor;

        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;             
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Close(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Camera CameraSystem = new Camera(TheSingleVisitor);
            CameraSystem.Show();

            // Hide the MainWindow until later
            this.Hide();
        }

        private void Clicked(object sender, TouchEventArgs e)
        {

        }

        private void Tapped(object sender, MouseButtonEventArgs e)
        {
            SignUpPage Apt1 = new SignUpPage(this, TheSingleVisitor);
            Apt1.Show();
            System.Windows.MessageBox.Show("Signuppage move");

            // Hide the MainWindow until later
            this.Hide();
        }

        private void Test(object sender, RoutedEventArgs e)
        {
            Process.Start("osk.exe");
        }

        private void Grid_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Activated(object sender, EventArgs e)
        {
            //CReate the instance of 
            if (TheSingleVisitor == null)
            {
                TheSingleVisitor = new Visitors();
            }
            else
            {
                TheSingleVisitor.Dispose();
                TheSingleVisitor = null;
                TheSingleVisitor = new Visitors();
            }
        }
    }
}
