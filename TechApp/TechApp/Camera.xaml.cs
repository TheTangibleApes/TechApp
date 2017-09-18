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
using MySql.Data.MySqlClient;

namespace TechApp
{
    /// <summary>
    /// Interaction logic for Camera.xaml
    /// </summary>
    public partial class Camera : Window
    {
        Visitors _visitor;
        WebCam webcam;
        public Camera(Visitors CameraVisitor)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
            _visitor = CameraVisitor;
        }

        private void mainWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            webcam = new WebCam();
            webcam.InitializeWebCam(ref imgVideo);
            if (webcam == null)
            {
                SignatureWindow Signature = new SignatureWindow(_visitor);
                Signature.Show();

                // Hide the MainWindow until later
                this.Close();
            }
            else webcam.Start();
        }

        private void bntContinue_Click(object sender, RoutedEventArgs e)
        {
            webcam.Start();
        }

        private void bntCapture_Click(object sender, RoutedEventArgs e)
        {
            webcam.Stop();
        }

        public JpegBitmapEncoder GetCameraImageAsJPEG(BitmapSource SourceImage)
        { 
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(SourceImage));
            encoder.QualityLevel = 100;


            Visitors AA = new Visitors();
            //AA.ConvertImageToByteArray(encoder, Jpeg)
            return encoder;
        }

        private void bntSaveImage_Click(object sender, RoutedEventArgs e)
        {
            Visitors AA = new Visitors();

            AA.image = GetCameraImageAsJPEG((BitmapSource)imgVideo.Source);

            //AA.SubmitImageToDatabase();

        }

        private void Return(object sender, RoutedEventArgs e)
        {
            SignatureWindow Signature = new SignatureWindow(_visitor);
            Signature.Show();

            // Hide the MainWindow until later
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            TsAndCs TandC = new TsAndCs(_visitor);
            TandC.Show();

            // Hide the MainWindow until later
            this.Close();
        }

        private void prev_page(object sender, MouseButtonEventArgs e)
        {
            TsAndCs TandC = new TsAndCs(_visitor);
            TandC.Show();

            // Hide the MainWindow until later
            this.Close();
        }

        private void next_page(object sender, MouseButtonEventArgs e)
        {
            SignatureWindow Signature = new SignatureWindow(_visitor);
            Signature.Show();

            // Hide the MainWindow until later
            this.Close();
        }
    }
}
