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

        }

    }
}
