using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace TechApp
{
    class Visitors
    {
        string firstname;
        string lastname;
        string phonenumber;
        string emailaddress;
        DateTime appointmenttime;
        int teacherid;

        public void SetInformation(string FirstName, string LastName, string PhoneNumber, string EmailAddress, DateTime AppointmentTime, int TeacherID)
        {
            firstname = FirstName;
            lastname = LastName;
            phonenumber = PhoneNumber;
            emailaddress = EmailAddress;
            appointmenttime = AppointmentTime;
            teacherid = TeacherID;
        }

        public void SubmitToDatabase()
        {
            string connectionString = "server=172.17.20.19;database=tangible;uid=2021029;pwd=2021029;";
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();

                try
                {
                    string query =
                        "insert into tangible.tbltechVisitors(firstName,lastName,phoneNumber,emailAddress, appointmentTime, teacherID) values('" + this.firstname + "','" + this.lastname + "','" + this.phonenumber + "','" + this.emailaddress + "','" + this.appointmenttime+ "','" + this.teacherid + "';";
                    MySqlCommand MyCommand2 = new MySqlCommand(query, cnn);
                    MySqlDataReader queryReader;
                    cnn.Open();
                    queryReader = MyCommand2.ExecuteReader();
                    //MessageBox.Show("Save Data");
                    while (queryReader.Read())
                    {

                    }

                    cnn.Close();
                }
                finally
                {
                    cnn.Close();
                }

            }finally
            {
                cnn.Close();
            }


        }

    }



    
}
