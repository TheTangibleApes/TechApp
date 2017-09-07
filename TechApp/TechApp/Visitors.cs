using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Media.Imaging;


namespace TechApp{
    public class Visitors{
        string firstname;
        string lastname;
        string phonenumber;
        string emailaddress;
        public JpegBitmapEncoder image;
        DateTime appointmenttime;
        int staffid;

        public Visitors()
        {
            appointmenttime = DateTime.Now;
            staffid = -1;
        }

        public void SetInformation(string FirstName, string LastName, string PhoneNumber, string EmailAddress, DateTime AppointmentTime, int StaffID){
            firstname = FirstName;
            lastname = LastName;
            phonenumber = PhoneNumber;
            emailaddress = EmailAddress;
            appointmenttime = AppointmentTime;
            staffid = StaffID;
        }

        public void SubmitToDatabase()
        {
            if (staffid >= 0)
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
                            "insert into tangible.tbltechVisitors(firstName,lastName,phoneNumber,emailAddress, appointmentTime, teacherID) values('" + this.firstname + "','" + this.lastname + "','" + this.phonenumber + "','" + this.emailaddress + "','" + this.appointmenttime + "','" + this.staffid + "';";
                        MySqlCommand MyCommand2 = new MySqlCommand(query, cnn);
                        MySqlDataReader queryReader;
                        cnn.Open();
                        queryReader = MyCommand2.ExecuteReader();
                        while (queryReader.Read())
                        {

                        }
                        cnn.Close();
                    }
                    finally
                    {
                        cnn.Close();
                    }
                }
                finally
                {
                    cnn.Close();
                }
            }//if
            else
            {
                // TODO - Fix this!!!!
                throw new System.Exception("Not implimented");
            }
        }
        

        //public Boolean SubmitImageToDatabase()
        //{

        //}


        public void RemoveFromDatabase(int ID){
            string connectionString;
            MySqlConnection cnn;
            connectionString = "server=172.17.20.19;database=tangible;uid=2021029;pwd=2021029;";
            cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();

                try
                {
                    string query = "delete from tangible.tbltechVisitors where visitorID=(SELECT max(id) FROM table);";

                    MySqlCommand MyCommand2 = new MySqlCommand(query, cnn);
                    MySqlDataReader MyReader2;
                    cnn.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    while (MyReader2.Read())
                    {
                    }
                    cnn.Close();
                }
                finally{
                    cnn.Close();
                }
            }
            finally{
                cnn.Close();
            }
        }
    }    
}
