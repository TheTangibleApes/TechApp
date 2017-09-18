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

        public Boolean Completed;

      
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void next_screen(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                // Message box
                System.Windows.MessageBox.Show("Please Enter First Name");
            }
            else
            {
                SetUpAppointment Apt1 = new SetUpAppointment();
                Apt1.Show();

                // Hide the MainWindow until later
                this.Hide();
            }
        }

        private void prev_page(object sender, MouseButtonEventArgs e)
        {
            MainWindow Apt1 = new MainWindow();
            Apt1.Show();

            // Hide the MainWindow until later
            this.Hide();
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
