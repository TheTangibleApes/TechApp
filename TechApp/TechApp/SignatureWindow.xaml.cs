﻿using System;
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
    /// Interaction logic for SignatureWindow.xaml
    /// </summary>
    public partial class SignatureWindow : Window
    {
        Visitors _visitor;
        public SignatureWindow(Visitors SignatureVisitor)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
            _visitor = SignatureVisitor;
        }
        Point downPoint;

        Point upPoint;

        Point currentPoint;

        bool isMouseDown = false;

        Rectangle rubberBand = null;

        string savePath = @"c:\canvas1.jpg";

        string selectPath = @"c:\select1x.jpg";

        private double zoomFactor = 1.0;





        private void canvas1_MouseDown(object sender, MouseButtonEventArgs e)

        {

            if (!this.canvas1.IsMouseCaptured)

            {



                isMouseDown = true;

                downPoint = new Point();

                downPoint = e.GetPosition(this.canvas1);

            }



        }



        private void canvas1_MouseMove(object sender, MouseEventArgs e)

        {



            if (isMouseDown == true)

            {





                if (rubberBand == null)

                {

                    rubberBand = new Rectangle();

                    rubberBand.Stroke = Brushes.LightCoral;

                    rubberBand.StrokeDashArray = new DoubleCollection(new double[] { 4, 2 });

                    canvas1.Children.Add(rubberBand);

                }



                currentPoint = e.GetPosition(this.canvas1);



                double width = Math.Abs(downPoint.X - currentPoint.X);

                double height = Math.Abs(downPoint.Y - currentPoint.Y);

                double left = Math.Min(downPoint.X, currentPoint.X);

                double top = Math.Min(downPoint.Y, currentPoint.Y);

                rubberBand.Width = width;

                rubberBand.Height = height;

                Canvas.SetLeft(rubberBand, left);

                Canvas.SetTop(rubberBand, top);



            }

        }

        private void canvas1_MouseUp(object sender, MouseButtonEventArgs e)

        {



            if (!this.canvas1.IsMouseCaptured)

            {



                isMouseDown = false;

                upPoint = new Point();

                upPoint = e.GetPosition(this.canvas1);

                CanvasToJpg(downPoint, upPoint);

                RectangleToJpg();



            }

        }



        private void CanvasToJpg(Point pt1, Point pt2)

        {

            RenderTargetBitmap bmp = new RenderTargetBitmap((int)canvas1.ActualWidth, (int)canvas1.ActualHeight, 96, 96, PixelFormats.Pbgra32);

            bmp.Render(canvas1);

            string Extension = System.IO.Path.GetExtension(savePath).ToLower();

            BitmapEncoder encoder = new JpegBitmapEncoder();

            encoder.Frames.Add(BitmapFrame.Create(bmp));

            using (System.IO.Stream stm = System.IO.File.Create(savePath))

            {

                encoder.Save(stm);

            }

        }

        private void RectangleToJpg()

        {

            double rubberBandLeft = Canvas.GetLeft(rubberBand);

            double rubberBandTop = Canvas.GetTop(rubberBand);

            using (System.Drawing.Bitmap source =

              new System.Drawing.Bitmap(savePath))

            {



                using (System.Drawing.Bitmap target =

                  new System.Drawing.Bitmap((int)rubberBand.Width,

                  (int)rubberBand.Height))

                {

                    System.Drawing.RectangleF recDest =

                      new System.Drawing.RectangleF

                     (0.0f, 0.0f, (float)target.Width,

                     (float)target.Height);

                    float hd = 1.0f / (target.HorizontalResolution /

                         source.HorizontalResolution);

                    float vd = 1.0f / (target.VerticalResolution /

                          source.VerticalResolution);

                    float hScale = 1.0f / (float)zoomFactor;

                    float vScale = 1.0f / (float)zoomFactor;

                    System.Drawing.RectangleF recSrc =

                     new System.Drawing.RectangleF

                     ((hd * (float)rubberBandLeft) *

                     hScale, (vd * (float)rubberBandTop) *

                     vScale, (hd * (float)rubberBand.Width) *

                     hScale, (vd * (float)rubberBand.Height) *

                     vScale);

                    using (System.Drawing.Graphics gfx =

                     System.Drawing.Graphics.FromImage(target))

                    {

                        gfx.DrawImage(source, recDest, recSrc,

                         System.Drawing.GraphicsUnit.Pixel);

                    }



                    target.Save(selectPath, System.Drawing.Imaging.ImageFormat.Jpeg);

                }

            }

        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            Camera Camera = new Camera(_visitor);
            Camera.Show();

            // Hide the MainWindow until later
            this.Close();
        }

        private void prev_page(object sender, MouseButtonEventArgs e)
        {
            Camera Camera = new Camera(_visitor);
            Camera.Show();

            // Hide the MainWindow until later
            this.Close();
        }

        private void next_page(object sender, MouseButtonEventArgs e)
        {
            CompleteWindow CW = new CompleteWindow(_visitor);
            CW.Show();

            // Hide the MainWindow until later
            this.Close();
        }
    }
}
