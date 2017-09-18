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
                MessageBox.Show("Please Enter Your First Name");
            }
            else if(string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please Enter Your Last Name");
            }
            else if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please Enter Your Phone Number");
            }
            else if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please Enter Your Email Address");
            }
            else
            {
                SetUpAppointment Apt1 = new SetUpAppointment(_visitor);
                Apt1.Show();

                // Hide the MainWindow until later
                this.Hide();
            }
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


        private void Number_Only(object sender, EventArgs e)
        {
            /*if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }*/
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
        }
    }
}
