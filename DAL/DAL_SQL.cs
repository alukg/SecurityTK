using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SharedClasses;
using System.Net.Mail;
using System.Net;
using System.Collections;

namespace DAL
{
    public class DAL_SQL : IDAL
    {
        private string connectionString = "Data Source=ISE-SQL12; Initial Catalog=aluk; Integrated Security=SSPI";

        /// <summary>
        /// checks if the user is in the DB.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool userNameExists(string userName)
        {
            userName = userName.ToLower();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT count(*) FROM Users WHERE UserName = '" + userName + "'", connection);
            try
            {
                connection.Open();
                int ans = Convert.ToInt32(cmd.ExecuteScalar()); //convert the answer to int.
                connection.Close();
                if (ans == 0) return false; //if there is no rows with that username.
                else return true;
            }
            catch //if there is connection problem to the DB.
            {
                throw new Exception("connection faild");
            }
        }

        /// <summary>
        /// get password of user from the DB.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string getPassword(string userName)
        {
            userName = userName.ToLower();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT Password FROM Users WHERE UserName = '" + userName + "'", connection);
            try
            {
                connection.Open();
                string ans = Convert.ToString(cmd.ExecuteScalar()); //execute the SQL command ans convert the password ro string.
                ans = ans.TrimEnd('\r', '\n');
                connection.Close();
                return ans;
            }
            catch
            {
                return ("connection faild");
            }
        }

        /// <summary>
        /// get role of user from the DB.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Role getRole(string userName)
        {
            userName = userName.ToLower();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT Role FROM Users WHERE UserName = '" + userName + "'", connection);
            try
            {
                connection.Open();
                string ans = Convert.ToString(cmd.ExecuteScalar());
                ans = ans.TrimEnd('\r', '\n');
                connection.Close();
                //The DB works with strings, so recive the answer and convert it to enum Role.
                if (ans.Equals("Administrator")) return Role.Administrator;
                else if (ans.Equals("Manager")) return Role.Manager;
                else
                {
                    return Role.Employee;
                }
            }
            catch
            {
                throw new Exception("connection faild");
            }
        }

        /// <summary>
        /// set new user in the DB.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        public void setNewUser(string userName, string password, Role role)
        {
            userName = userName.ToLower();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO Users(UserName, Password, Role) VALUES('" + userName + "','" + password + "','" + role.ToString() + "')", connection);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                throw new Exception("connection faild");
            }
        }

        /// <summary>
        /// set password for user in the DB.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="value"></param>
        public void setPassword(string userName, string value)
        {
            userName = userName.ToLower();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("UPDATE Users SET Password ='" + value + "' WHERE UserName = '" + userName + "'", connection);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                throw new Exception("connection faild");
            }
        }

        /// <summary>
        /// set rassword for user in the DB.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="value"></param>
        public void setRole(string userName, Role value)
        {
            userName = userName.ToLower();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("UPDATE Users SET Role ='" + value.ToString() + "' WHERE UserName = '" + userName + "'", connection);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                throw new Exception("connection faild");
            }
        }

        /// <summary>
        /// write to the log table in the DB.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="performed"></param>
        /// <param name="affected"></param>
        public void writeLogToDB(string dateTime, string action, string performed, String affected)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd;
            if (affected == null)
            {
                cmd = new SqlCommand("INSERT INTO Log(Action, DateTime, Executer) VALUES('" + action + "','" + dateTime + "','" + performed + "')", connection);
            }
            else
            {
                cmd = new SqlCommand("INSERT INTO Log(Action, DateTime, Executer, Affected) VALUES('" + action + "','" + dateTime + "','" + performed + "','" + affected + "')", connection);
            }
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                throw new Exception("connection faild");
            }
        }

        /// <summary>
        /// returns the software log.
        /// </summary>
        /// <returns></returns>
        public List<string> getLog()
        {
            SqlConnection connection = new SqlConnection(connectionString);
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

        /// <summary>
        /// remove user from the DB.
        /// </summary>
        /// <param name="userName"></param>
        public void removeUser(string userName)
        {
            userName = userName.ToLower();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE UserName = '" + userName + "'", connection);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                throw new Exception("connection faild");
            }
        }

        /// <summary>
        /// returns the software log.
        /// </summary>
        /// <returns></returns>
        public List<string> getLiveAlertsMailsForAction(string action)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT Email FROM Users WHERE Role = 'Administrator' AND GetUpdate = '1' AND [" + action.ToString() + "] = '1'", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<string> emailList = new List<string>();
                while (reader.Read())
                {
                    emailList.Add(reader.GetValue(0).ToString());
                }
                reader.Close();
                connection.Close();
                return emailList;
            }
            catch
            {
                throw new Exception("connection faild");
            }
        }

        public Dictionary<string, object> getLineForUsername(string username)
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + path + "\\SecurityTK_DB.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Role = 'Administrator' AND UserName = " + username, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Dictionary<string, object> table = new Dictionary<string, object>();
                table.Add("GetUpdate",reader["GetUpdate"]);
                table.Add("logOn", reader["User log on"]);
                table.Add("logOff", reader["User log off"]);
                table.Add("changePassword", reader["User change password"]);
                table.Add("encryption", reader["User accessed Encryption Tool"]);
                table.Add("dataLeakage", reader["User accessed Data Leakage Tool"]);
                table.Add("processMonitor", reader["User accessed Process Monitor"]);
                table.Add("Email", reader["Email"]);

                reader.Close();
                connection.Close();
                return table;
            }
            catch
            {
                throw new Exception("connection faild");
            }
        }

        public void updateEmailLine(Dictionary<string,object> h, string userName)
        {
            userName = userName.ToLower();
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + path + "\\SecurityTK_DB.mdf;Integrated Security=True");
            foreach (KeyValuePair<string,object> a in h)
            {
                string s;

                if (a.Key == "GetUpdate") s = "GetUpdate";
                else if (a.Key == "logOn") s = "User log on";
                else if (a.Key == "logOff") s = "User log off";
                else if (a.Key == "changePassword") s = "User change password";
                else if (a.Key == "encryption") s = "User accessed Encryption Tool";
                else if (a.Key == "dataLeakage") s = "User accessed Data Leakage Tool";
                else if (a.Key == "processMonitor") s = "User accessed Process Monitor";
                else if (a.Key == "Email") s = "Email";
                else throw new Exception();

                SqlCommand cmd = new SqlCommand("UPDATE Users SET "+s+" ='" + a.Value.ToString() + "' WHERE UserName = '" + userName + "'", connection);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch
                {
                    throw new Exception("connection faild");
                }
            }
        }

    }
}
