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
using TechApp;

namespace TechApp
{
    /// <summary>
    /// Interaction logic for SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Window
    {
        private Window _parent;
        private Visitors _visitor;
        public SignUpPage(Window Parent, Visitors TheSUPVisitor)
        {
            _parent = Parent;
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
            _visitor = TheSUPVisitor;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            /*
            We cannot create another instance of the Hoem screen since it was never destroyed to start off with
            
            MainWindow HomeScreen = new MainWindow();
            HomeScreen.Show();

            Rather hide this screen, after showing the main screen
            */

            _parent.Show();
            // Hide the MainWindow until later
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            SetUpAppointment Apt2 = new SetUpAppointment(_visitor);
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

        private void next_screen(object sender, MouseButtonEventArgs e)
        {
            
            SetUpAppointment Apt1 = new SetUpAppointment(_visitor);
            Apt1.Show();

            // Hide the MainWindow until later
            this.Close();
        }

        private void prev_page(object sender, MouseButtonEventArgs e)
        {
            _parent.Show();

            // Hide the MainWindow until later
            this.Close();
        }

        private void FNText(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if ((e.Key < Key.A) || (e.Key > Key.Z))
                e.Handled = true;
        }

        private void LNText(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if ((e.Key < Key.A) || (e.Key > Key.Z))
                e.Handled = true;
        }

        private void Phone_No(object sender, System.Windows.Input.KeyEventArgs e)
        {
            
        }
    }
}
