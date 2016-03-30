using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

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

            Application app = new Microsoft.Office.Interop.Excel.Application();
            Workbook excelWorkbook = app.Workbooks.Open(@"C:\Users\guyal\Desktop\SecurityTK\DAL\UsersDB.xlsx"); //opens the DB file, in that case the Excel file.
            Worksheet UsersDB = (Worksheet)excelWorkbook.Sheets[1]; //gets the right sheet from the Excel file.

            int lastRow = UsersDB.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row;

            for(int line=1; line<lastRow ;line++) //runs all the usernames in the DB.
            {
                Object currentUserName = UsersDB.get_Range("A" + line, "A" + line).Value; //gets a username for check.
                if (currentUserName.ToString().Equals(userName)) //if the required username found in the DB.
                {
                    excelWorkbook.Close(false); //closing the Excel file.
                    app.Workbooks.Close();
                    app.Quit();
                    return line;
                }
            }
            //The loop reached to the end of the usernames column, that means that the username doesn't exists in the DB.
            excelWorkbook.Close(false); //closing the Excel file.
            app.Quit();
            return -1; //the returning value when the username not found.
        }

        /// <summary>
        /// getPassword function - returns the password of the requested user by ID (line).
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public string getPassword(int line)
        {
            Application app = new Microsoft.Office.Interop.Excel.Application();
            Workbook excelWorkbook = app.Workbooks.Open(@"C:\Users\guyal\Desktop\SecurityTK\DAL\UsersDB.xlsx"); //opens the DB file, in that case the Excel file.
            Worksheet UsersDB = (Worksheet)excelWorkbook.Sheets[1]; //gets the right sheet from the Excel file.

            Object cell = UsersDB.get_Range("B" + line, "B" + line).Value; //gets the password of the requested user ID (line) from the DB.
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
            Workbook excelWorkbook = app.Workbooks.Open(@"C:\Users\guyal\Desktop\SecurityTK\DAL\UsersDB.xlsx"); //opens the DB file, in that case the Excel file.
            Worksheet UsersDB = (Worksheet)excelWorkbook.Sheets[1]; //gets the right sheet from the Excel file.

            UsersDB.Cells[line,2].Value = value; //sets the new password in the right place in the DB.
            excelWorkbook.Close(true,"UsersDB",false); //closes the Excel file.
            app.Quit();
        }
         
    }
}
