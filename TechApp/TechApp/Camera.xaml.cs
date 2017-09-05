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
    /// Interaction logic for Camera.xaml
    /// </summary>
    public partial class Camera : Window
    {
        WebCam webcam;
        public Camera()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
        }

        private void mainWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            webcam = new WebCam();
            webcam.InitializeWebCam(ref imgVideo);
            webcam.Start();
        }

        private void bntContinue_Click(object sender, RoutedEventArgs e)
        {
            webcam.Start();
        }

        private void bntCapture_Click(object sender, RoutedEventArgs e)
        {
            webcam.Stop();
        }

        private void bntSaveImage_Click(object sender, RoutedEventArgs e)
        {
            Helper.SaveImageCapture((BitmapSource)imgVideo.Source);
        }

        private void Return(object sender, RoutedEventArgs e)
        {
            MainWindow HomeScreen = new MainWindow();
            HomeScreen.Show();

            // Hide the MainWindow until later
            this.Close();
        }
    }
}
