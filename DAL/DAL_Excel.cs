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
            Worksheet UsersDB = get_Worksheet();
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
                    return line;
                }
            }
            return -1;
        }

        public string getPassword(int line)
        {
            Worksheet UsersDB = get_Worksheet();
            Object cell = UsersDB.get_Range("B" + line, "B" + line).Value;
            if (cell == null)
            {
                throw new Exception("There is no such user number");
            }
            else {
                return cell.ToString();
            }
        }

        public Worksheet get_Worksheet()
        {
            Application app = new Microsoft.Office.Interop.Excel.Application();
            Workbook excelWorkbook = app.Workbooks.Open(@"C:\Users\guyal\Desktop\SecurityTK\DAL\UsersDB.xlsx");
            Sheets excelSheets = excelWorkbook.Worksheets;
            string currentSheet = "default";
            return (Worksheet)excelSheets.get_Item(currentSheet);
        }
    }
}
