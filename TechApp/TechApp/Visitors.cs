using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;

namespace TechApp{
    public class Visitors{
        string connectionString = "server=172.17.20.19;database=tangible;uid=2021029;pwd=2021029;";
        string firstname;
        string lastname;
        string phonenumber;
        string emailaddress;
        public JpegBitmapEncoder image;
        DateTime appointmenttime;
        int staffid;

        public Visitors()
        {
            //TODO: review this
            appointmenttime = DateTime.Now;
            staffid = -1;
        }

        public void SetInformation(string FirstName, string LastName, string PhoneNumber, string EmailAddress, DateTime AppointmentTime, int StaffID){
            //TODO: review this
            firstname = FirstName;
            lastname = LastName;
            phonenumber = PhoneNumber;
            emailaddress = EmailAddress;
            appointmenttime = AppointmentTime;
            staffid = StaffID;
        }

        public void SubmitToDatabase()
        {
            //TODO: review this
            //ConvertImageToByteArray();

            if (staffid >= 0)
            {
                MySqlConnection cnn;
                cnn = new MySqlConnection(connectionString);
                try
                {
                    cnn.Open();
                    try
                    {
                        string query =
                            "insert into tangible.tbltechVisitors(firstName,lastName,phoneNumber,emailAddress, appointmentTime, teacherID) values('" +
                                this.firstname + "','" +
                                this.lastname + "','" +
                                this.phonenumber + "','" +
                                this.emailaddress + "','" +
                                this.appointmenttime + "','" +
                                this.staffid + "';";

                        MySqlCommand MyCommand2 = new MySqlCommand(query, cnn);
                        MyCommand2.ExecuteNonQuery();

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



        private byte[] ConvertImageToByteArray()
        {
            byte[] Ret;

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms);
                Ret = ms.ToArray();
            }
            return Ret;
        }

        //private string ByteArrayToString(byte[] bytearray)
        //{
        //    string querystatement = BitConverter.ToString(bytearray);
        //    querystatement = BitConverter.ToString(bytearray).Replace("-", "");
        //    //for (int i = 0; i < bytearray.Length; i++)
        //    //{
        //    //    querystatement = querystatement + bytearray[i];
        //    //}
        //    return querystatement;
        //}

        public Boolean SubmitImageToDatabase()
        {
            ////TODO: review this
            //ByteArrayToString(ConvertImageToByteArray());
            //return true;

            bool result;
            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand cmd;
            try
            {

                byte[] ImageData = ConvertImageToByteArray();



                string CmdString = "INSERT INTO tangible.tbltechvisitors(FirstName, LastName, Image, EmailAddress) VALUES(@FirstName, @LastName, @Image, @EmailAddress)";
                cmd = new MySqlCommand(CmdString, con);

                cmd.Parameters.Add("@FirstName", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@LastName", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@Image", MySqlDbType.Blob);
                cmd.Parameters.Add("@EmailAddressAddress", MySqlDbType.VarChar, 100);

                cmd.Parameters["@FirstName"].Value = firstname;
                cmd.Parameters["@LastName"].Value = lastname;
                cmd.Parameters["@Image"].Value = ImageData;
                cmd.Parameters["@EmailAddress"].Value = emailaddress;

                con.Open();
                int RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    result = true;
                }                
                else
                {
                    result = false;
                }
                con.Close();
            }
            catch (Exception)
            {
                return result = false;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return result;
        }

    


        public void RemoveFromDatabase(int ID){
            //TODO: review this
            MySqlConnection cnn;
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
