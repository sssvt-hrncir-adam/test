using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AspNetCoreCURDMVC_Demo.Models;
using SmsServer.Data;
using SmsServer.Web.Models;

namespace AspNetCoreCURDMVC_Demo.Models
{
    public class SmsDBAccessLayer
    {

        SqlConnection con = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=SmsServer;Trusted_Connection=True;
");
        public string AddNewSms(NewSmsModel newSmsModel)
        {

            var query = $"insert into Sms(PhoneNumber, Text, Status, CreatedAt, SentAt) values ('{newSmsModel.PhoneNumber}', '{newSmsModel.Text}', 2, GETDATE(), GETDATE())";

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("SMS Sent Successfully.");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }
    }
}
