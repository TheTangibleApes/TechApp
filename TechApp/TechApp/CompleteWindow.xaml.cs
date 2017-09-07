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
    /// Interaction logic for CompleteWindow.xaml
    /// </summary>
    public partial class CompleteWindow : Window
    {
        public CompleteWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow HomeScreen = new MainWindow();
            HomeScreen.Show();

            // Hide the MainWindow until later
            this.Close();
        }
    }
}
