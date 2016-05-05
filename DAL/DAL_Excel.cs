using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;

namespace DAL
{
    public class DAL_Excel : IDAL
    {
        /// <summary>
        /// getLine function - Returns the line value of the username. If the username doesn't exists return the value -1 .
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int getLine(string userName)
        {
            if (userName == null) //checks if the input is legal.
            {
                throw new Exception("input is null");
            }

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = path + "\\UsersDB.csv";

            TextReader sw = new StreamReader(path);
            string[] nextUser = sw.ReadLine().Split(',');
            for(int line=1; nextUser[0]!=""; line++) //runs all the usernames in the DB.
            {
                if (nextUser[0].Equals(userName)) //if the required username found in the DB.
                {
                    sw.Close(); //closing the CSV file.
                    return line;
                }
                nextUser = sw.ReadLine().Split(',');
            }
            //The loop reached to the end of the usernames column, that means that the username doesn't exists in the DB.
            sw.Close(); //closing the CSV file.
            return -1; //the returning value when the username not found.

        }

        /// <summary>
        /// getPassword function - returns the password of the requested user by ID (line).
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public string getPassword(int line)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = path + "\\UsersDB.csv";

            TextReader sw = new StreamReader(path);
            //gets the password of the requested user ID (line) from the DB.
            string password = (sw.ReadLine().Split(','))[1]; ;
            for(int i = 1; i <= line; i++)
            {
                password = (sw.ReadLine().Split(','))[1];
            }

            for (int line = 1; nextUser[0] != ""; line++) //runs all the usernames in the DB.
            {
                if (nextUser[0].Equals(userName)) //if the required username found in the DB.
                {
                    sw.Close(); //closing the CSV file.
                    return line;
                }
                nextUser = sw.ReadLine().Split(',');
            }

            if (cell == null) //the requested ID isn't exists.
            {
                excelWorkbook.Close(false); //closing the Excel file.
                app.Quit();
                throw new Exception("There is no such user number");
            }
            else { //if there is such ID.
                excelWorkbook.Close(false); //closing the Excel file.
                app.Quit();
                return cell.ToString(); //return the password as requested.
            }
        }

        /// <summary>
        /// setPassword function - sets a password for a requested user.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="value"></param>
        public void setPassword(int line, string value)
        {
            Application app = new Microsoft.Office.Interop.Excel.Application();

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = path + "\\UsersDB.csv";

            Workbook excelWorkbook = app.Workbooks.Open(path); //opens the DB file, in that case the Excel file.
            Worksheet UsersDB = (Worksheet)excelWorkbook.Sheets[1]; //gets the right sheet from the Excel file.

            UsersDB.Cells[line,"B"].Value = value; //sets the new password in the right place in the DB.
            excelWorkbook.Save();
            excelWorkbook.Close();
           // excelWorkbook.Close(true,"UsersDB",false); //closes the Excel file.
            app.Quit();
        }
         
    }
}
