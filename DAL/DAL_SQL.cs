using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_SQL : IDAL
    {
        public string getPassword(string userName)
        {
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\guyal\\Desktop\\SecurityTK\\DAL\\SecurityTK_DB.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT Password FROM Users WHERE UserName = '" + userName + "'", connection);
            try
            {
                connection.Open();
                string ans = (string)cmd.ExecuteScalar();
                connection.Close();
                return ans;
            }
            catch
            {
                return ("connection faild");
            }

            /*
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\guyal\\Desktop\\SecurityTK\\DAL\\SecurityTK_DB.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("getPassword", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                connection.Open();
                //creating and adding a return parameter:
                SqlParameter parm = new SqlParameter("@password", SqlDbType.VarChar);
                parm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parm);

                //adding the userName parameter:
                cmd.Parameters.Add(new SqlParameter("@UserName", userName));

                //excute the query:
                cmd.ExecuteNonQuery();
                string ans = (string)parm.Value;
                connection.Close();
                return "ans";
            }
            catch
            {
                return ("connection faild");
            }
            */
        }

        public string getRole(string userName)
        {
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\guyal\\Desktop\\SecurityTK\\DAL\\SecurityTK_DB.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT Role FROM Users WHERE UserName = '" + userName + "'", connection);
            try
            {
                connection.Open();
                string ans = (string)cmd.ExecuteScalar();
                connection.Close();
                return ans;
            }
            catch
            {
                return ("connection faild");
            }
        }

        public void setNewUser(string userName, string password, string role)
        {
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\guyal\\Desktop\\SecurityTK\\DAL\\SecurityTK_DB.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("INSERT INTO Users(UserName, Password, Role) VALUES('" + userName + "','" + password + "','" + role + "')", connection);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                Console.WriteLine("connection faild");
            }
        }

        public void setPassword(string userName, string value)
        {
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\guyal\\Desktop\\SecurityTK\\DAL\\SecurityTK_DB.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("UPDATE Users SET Password ='" + value + "' WHERE UserName = '" + userName + "'", connection);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                Console.WriteLine("connection faild");
            }
        }

        public void setRole(string userName, string value)
        {
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\guyal\\Desktop\\SecurityTK\\DAL\\SecurityTK_DB.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("UPDATE Users SET Role ='" + value + "' WHERE UserName = '" + userName + "'", connection);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                Console.WriteLine("connection faild");
            }
        }
    }
}
