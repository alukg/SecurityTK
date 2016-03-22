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
        public string getLine(string username)
        {
            throw new NotImplementedException();
        }

        public string getPassword(int line)
        {
            Application app = new Microsoft.Office.Interop.Excel.Application();
            Workbook excelWorkbook = app.Workbooks.Open(@"C:\Users\guyal\Desktop\SecurityTK\DAL\UsersDB.xlsx");
            Sheets excelSheets = excelWorkbook.Worksheets;
            string currentSheet = "default";
            Worksheet UsersDB = (Worksheet)excelSheets.get_Item(currentSheet);
            return UsersDB.get_Range("B"+line,"B"+line).Value.ToString();

        }
    }
}
