using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_SQL : IDAL
    {
        /// <summary>
        /// checks if the userName exists in the DB
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool checkUserName(string userName)
        {
            if (userName == null) //checks if the input is legal.
            {
                throw new Exception("input is null");
            }
            string path = Directory.GetCurrentDirectory(); //gets the runtime folder
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + path + "\\Security_DB.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT count(*) FROM Users WHERE UserName = '" + userName + "'", connection);
            try
            {
                connection.Open();
                int ans = Convert.ToInt32(cmd.ExecuteScalar()); //execute the SQL query
                connection.Close();
                if (ans == 1) //if the username exists
                    return true;
                else
                    return false;
            }
            catch
            {
                throw new Exception("connection faild");
            }
        }

        /// <summary>
        /// getLine function - Returns the ID value of the username. If the username doesn't exists return the value -1 .
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int getId(string userName)
        {
            if (userName == null) //checks if the input is legal.
            {
                throw new Exception("input is null");
            }
            if (!checkUserName(userName)) return -1;
            string path = Directory.GetCurrentDirectory();
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + path + "\\Security_DB.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT Id FROM Users WHERE UserName = '" + userName + "'", connection);
            try
            {
                connection.Open();
                int ans = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();
                return ans;
            }
            catch
            {
                throw new Exception("connection faild");
            }
        }

        /// <summary>
        /// getPassword function - returns the password of the requested user by ID.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public string getPassword(int id)
        {
            string path = Directory.GetCurrentDirectory();
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + path + "\\Security_DB.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT Password FROM Users WHERE Id = '" + id + "'", connection);
            try
            {
                connection.Open();
                string ans = (string)cmd.ExecuteScalar();
                connection.Close();
                return ans;
            }
            catch
            {
                throw new Exception("connection faild");
            }
        }

        /// <summary>
        /// setPassword function - sets a password for a requested user.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="value"></param>
        public void setPassword(int id, string value)
        {
            string path = Directory.GetCurrentDirectory();
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + path + "\\Security_DB.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("UPDATE Users SET Password ='" + value + "' WHERE Id = '" + id + "'", connection);
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
