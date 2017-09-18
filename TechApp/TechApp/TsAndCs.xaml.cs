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
    /// Interaction logic for TsAndCs.xaml
    /// </summary>
    public partial class TsAndCs : Window
    {
        public TsAndCs()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
        }

        public Boolean acceptedTerms = false;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SetUpAppointment Appt2 = new SetUpAppointment();
            Appt2.Show();

            // Hide the MainWindow until later
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Camera CameraSystem = new Camera();
            CameraSystem.Show();

            // Hide the MainWindow until later
            this.Close();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void prev_page(object sender, MouseButtonEventArgs e)
        {
          
        }

        private void next_page(object sender, MouseButtonEventArgs e)
        {
            if(acceptedTerms == true)
            {
                Camera CameraSystem = new Camera();
                CameraSystem.Show();

                // Hide the MainWindow until later
                this.Close();
            }
            else
            {
                MessageBox.Show("You must agree to the terms and conditions");
            }
        }

        private void prev_page_2(object sender, MouseButtonEventArgs e)
        {
            SetUpAppointment Appt2 = new SetUpAppointment();
            Appt2.Show();

            // Hide the MainWindow until later
            this.Close();
        }

        private void No_Checked(object sender, RoutedEventArgs e)
        {
            YesCheck.IsChecked = false;
            acceptedTerms = false;
        }

        private void Yes_Checked(object sender, RoutedEventArgs e)
        {
            NoCheck.IsChecked = false;
            acceptedTerms = true;
        }
    }
}
