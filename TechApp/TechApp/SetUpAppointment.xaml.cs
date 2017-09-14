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
    /// Interaction logic for SetUpAppointment.xaml
    /// </summary>
    public partial class SetUpAppointment : Window
    {
        public SetUpAppointment()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;

            string connectionString = "server=172.17.20.19;database=tangible;uid=2021029;pwd=2021029;";
            string Sql = "select CONCAT(firstName,' ', lastname) from tangible.tbltechTeachers \r\n ORDER BY firstname";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(Sql, conn);
            MySqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                comboBox.Items.Add(DR[0]);
            }
        }

        private void next_page(object sender, MouseButtonEventArgs e)
        {

        }
    }
}

