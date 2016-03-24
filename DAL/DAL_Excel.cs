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
        public int getLine(string userName)
        {
            if (userName == null)
            {
                throw new Exception("input is null");
            }
            Workbook excelWorkbook = getWorkbook();
            Sheets excelSheets = excelWorkbook.Worksheets;
            string currentSheet = "default";
            Worksheet UsersDB = (Worksheet)excelSheets.get_Item(currentSheet);

            bool notFound = false;
            for(int line=1;!notFound;line++)
            {
                Object currentUserName = UsersDB.get_Range("A" + line, "A" + line).Value;
                if (currentUserName==null)
                {
                    notFound = true;
                }
                else if (currentUserName.ToString().Equals(userName))
                {
                    excelWorkbook.Close();
                    return line;
                }
            }
            excelWorkbook.Close();
            return -1;
        }

        public string getPassword(int line)
        {
            Workbook excelWorkbook = getWorkbook();
            Sheets excelSheets = excelWorkbook.Worksheets;
            string currentSheet = "default";
            Worksheet UsersDB = (Worksheet)excelSheets.get_Item(currentSheet);

            Object cell = UsersDB.get_Range("B" + line, "B" + line).Value;
            if (cell == null)
            {
                excelWorkbook.Close();
                throw new Exception("There is no such user number");
            }
            else {
                excelWorkbook.Close();
                return cell.ToString();
            }
        }

        public void setPassword(int line, string value)
        {
            Workbook excelWorkbook = getWorkbook();
            Sheets excelSheets = excelWorkbook.Worksheets;
            string currentSheet = "default";
            Worksheet UsersDB = (Worksheet)excelSheets.get_Item(currentSheet);

            UsersDB.Cells[line,2].Value = value;
            excelWorkbook.Save();
            excelWorkbook.Close();
        }

        private Workbook getWorkbook()
        {
            Application app = new Microsoft.Office.Interop.Excel.Application();
            Workbook excelWorkbook = app.Workbooks.Open(@"C:\Users\guyal\Desktop\SecurityTK\DAL\UsersDB.xlsx");
            return excelWorkbook;
        }
                
    }
}
