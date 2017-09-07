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
    /// Interaction logic for TsAndCs.xaml
    /// </summary>
    public partial class TsAndCs : Window
    {
        public TsAndCs()
        {
            InitializeComponent();
        }

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
    }
}
