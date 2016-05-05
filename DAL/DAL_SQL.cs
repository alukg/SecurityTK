using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class DAL_SQL : IDAL
    {
        public bool userNameExists(string userName)
        {
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\guyal\\Desktop\\SecurityTK\\DAL\\SecurityTK_DB.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT count(*) FROM Users WHERE UserName = '" + userName + "'", connection);
            try
            {
                connection.Open();
                int ans = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();
                if (ans == 0) return false;
                else return true;
            }
            catch
            {
                throw new Exception("connection faild");
            }
        }

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
            value = value.First().ToString().ToUpper() + value.Substring(1).ToString().ToLower();
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

        public void writeToLog(string action, string performed, string affected)
        {
            string dateTime = DateTime.Now.ToString("yyMMdd HH:mm:ss");
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\guyal\\Desktop\\SecurityTK\\DAL\\SecurityTK_DB.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("INSERT INTO Log(Action, DateTime, Executer, Affected) VALUES('" + action + "','" + dateTime + "','" + performed + "','" + affected + "')", connection);
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

        public List<string> getLog()
        {
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\guyal\\Desktop\\SecurityTK\\DAL\\SecurityTK_DB.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Log", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<string> logList = new List<string>();
                while (reader.Read())
                {
                    logList.Add(reader.GetValue(0).ToString() + ", " + reader.GetValue(1).ToString() + ", " + reader.GetValue(2).ToString() + ", " + reader.GetValue(3).ToString());
                }
                reader.Close();
                connection.Close();
                return logList;
            }
            catch
            {
                throw new Exception("connection faild");
            }
        }

        public void removeUser(string userName)
        {
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\guyal\\Desktop\\SecurityTK\\DAL\\SecurityTK_DB.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE UserName = '" + userName + "'", connection);
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
