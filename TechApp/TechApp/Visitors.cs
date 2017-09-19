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
    public class Visitors : IDisposable
    {
        string connectionString = "server=172.17.20.19;database=tangible;uid=2021029;pwd=2021029;";
        string firstname;
        string lastname;
        string phonenumber;
        string emailaddress;
        public JpegBitmapEncoder visitorImage;
        public JpegBitmapEncoder signatureImage;
        DateTime appointmenttime;
        int staffid;
        string company;

        public Visitors()
        {
            //TODO: review this
            appointmenttime = DateTime.Now;
            staffid = -1;
        }

        //public void SetInformation(string FirstName, string LastName, string PhoneNumber, string EmailAddress, DateTime AppointmentTime, int StaffID){
        //    //TODO: review this
        //    firstname = FirstName;
        //    lastname = LastName;
        //    phonenumber = PhoneNumber;
        //    emailaddress = EmailAddress;
        //    appointmenttime = AppointmentTime;
        //    staffid = StaffID;
        //}
        public bool SetFirstName(string FirstName)
        {
            bool result;
            try
            {
                firstname = FirstName;
                result = true;
            }
            catch(Exception)
            {
                result = false;
            }
            return result;
            }

        public bool SetLastName(string LastName)
        {
            bool result;
            try
            {
                lastname = LastName;
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public bool SetPhoneNumber(string PhoneNumber)
        {
            bool result;
            try
            {
                phonenumber = PhoneNumber;
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public bool SetEmailAddress(string EmailAddress)
        {
            bool result;
            try
            {
                emailaddress = EmailAddress;
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public bool SetCompany(string Company)
        {
            bool result;
            try
            {
                company = Company;
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public bool SetStaffID(int StaffID)
        {
            bool result;
            try
            {
                staffid = StaffID;
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public void Dispose()
        {

        }

        //public void SubmitToDatabase()
        //{
        //    //TODO: review this
        //    //ConvertImageToByteArray();

        //    if (staffid >= 0)
        //    {
        //        MySqlConnection cnn;
        //        cnn = new MySqlConnection(connectionString);
        //        try
        //        {
        //            cnn.Open();
        //            try
        //            {
        //                string query =
        //                    "insert into tangible.tbltechVisitors(firstName,lastName,phoneNumber,emailAddress, appointmentTime, teacherID) values('" +
        //                        this.firstname + "','" +
        //                        this.lastname + "','" +
        //                        this.phonenumber + "','" +
        //                        this.emailaddress + "','" +
        //                        this.appointmenttime + "','" +
        //                        this.staffid + "';";

        //                MySqlCommand MyCommand2 = new MySqlCommand(query, cnn);
        //                MyCommand2.ExecuteNonQuery();

        //                cnn.Close();
        //            }
        //            finally
        //            {
        //                cnn.Close();
        //            }
        //        }
        //        finally
        //        {
        //            cnn.Close();
        //        }
        //    }//if
        //    else
        //    {
        //        // TODO - Fix this!!!!
        //        throw new System.Exception("Not implimented");
        //    }
        //}



        private bool ConvertImageToByteArray(JpegBitmapEncoder ImagetoConvert, out byte[] TheArray)
        {
            //Make sure that we have an image before trying to 'serialize' it
            if (ImagetoConvert != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    ImagetoConvert.Save(ms);
                    TheArray = ms.ToArray();
                    return true;
                }
            }
            else
            {
                TheArray = null;
            }
            return false;
        }



        private Boolean SubmitToFile()
        {
            //todo
            return true;
        }

        public Boolean SubmitToDatabase()
        {
            ////TODO: review this
            //ByteArrayToString(ConvertImageToByteArray());
            //return true;

            bool result = false;
            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand cmd;
            try
            {
                //byte[] SignatureImageData = ConvertSignatureImageToByteArray();
                byte[] VisitorImgData;
                byte[] SignatureImgData;

                if (ConvertImageToByteArray(visitorImage, out VisitorImgData) &&
                    ConvertImageToByteArray(signatureImage, out SignatureImgData))
                {

                    //Build up the SQL
                    string CmdString = "INSERT INTO tangible.tbltechvisitors(firstName, lastName, phoneNumber, emailAddress, appointmentTime, teacherID, image, company) VALUES(@FirstName, @LastName, @PhoneNumber, @EmailAddress, @AppointmentTime, @TeacherID, @Image, @Company)";
                    cmd = new MySqlCommand(CmdString, con);

                    cmd.Parameters.Add("@FirstName", MySqlDbType.VarChar, 50);
                    cmd.Parameters.Add("@LastName", MySqlDbType.VarChar, 50);
                    cmd.Parameters.Add("@PhoneNumber", MySqlDbType.VarChar, 50);
                    cmd.Parameters.Add("@EmailAddress", MySqlDbType.VarChar, 100);
                    cmd.Parameters.Add("@AppointmentTime", MySqlDbType.DateTime);
                    cmd.Parameters.Add("@TeacherID", MySqlDbType.Int16);
                    cmd.Parameters.Add("@Image", MySqlDbType.Blob);
                    //cmd.Parameters.Add("@SignatureImage", MySqlDbType.Blob);
                    cmd.Parameters.Add("@Company", MySqlDbType.VarChar, 100);

                    cmd.Parameters["@FirstName"].Value = firstname;
                    cmd.Parameters["@LastName"].Value = lastname;
                    cmd.Parameters["@PhoneNumber"].Value = phonenumber;
                    cmd.Parameters["@EmailAddress"].Value = emailaddress;
                    cmd.Parameters["@AppointmentTime"].Value = appointmenttime;
                    cmd.Parameters["@TeacherID"].Value = staffid;
                    cmd.Parameters["@Image"].Value = VisitorImgData;
                    //cmd.Parameters["@SignatureImage"].Value = SignatureImgData;
                    cmd.Parameters["@Company"].Value = company;

                    con.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0)
                    {
                        result = true;
                    }
                    
                    con.Close();
                }//if                
            }
            catch (Exception e)
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

            //If, for whatever reason, the data save did not work. Dump it to 
            //  the file system for the agent to pick up
            if (result != true)
            {
                result = SubmitToFile();
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
