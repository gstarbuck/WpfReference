using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BillingTools.Excel
{
    public class ExcelGenerationService
    {
        Application _app;
        _Workbook _book;

        public void GenerateExcelDocument()
        {
            Workbooks books;
            Sheets sheets;
            _Worksheet sheet;
            Range range;

            try
            {
                                // Instantiate Excel and start a new workbook
                _app = new Application();
                books = _app.Workbooks;
                _book = books.Add(Missing.Value);
                sheets = _book.Worksheets;
                sheet = (_Worksheet)sheets.get_Item(1);
                sheet.Name = "Sheet 1";

                // Get the range where the starting cell has the address
                //m_sStartingCell and its dimensions are all m_iNumRows x m_iNumCols
                range = sheet.get_Range("A1", Missing.Value);
                range = range.get_Resize(5, 5);

                // Create an array
                double[,] ret = new double[5, 5];

                // Fill the array
                for (long iRow = 0; iRow < 5; iRow++)
                {
                    for (long iCol = 0; iCol < 5; iCol++)
                    {
                        ret[iRow, iCol] = iRow * iCol;
                    }
                }
                range.set_Value(Missing.Value, ret);

                // Now create a second sheet
                var sheet2 = (_Worksheet)_book.Sheets.Add(Before: sheet);

                sheet2.Name = "Sheet 2";

                range = sheet2.get_Range("A1", Missing.Value);
                range = range.get_Resize(5, 5);

                // TODO: set to a value in the other sheet
                ((Range)sheet2.Cells[1, 1]).Formula = "='Sheet 1'!$E$5";

                // Set cell values
                sheet2.Cells[5, 3] = "-5";
                sheet2.Cells[5, 4] = "0";
                sheet2.Cells[5, 5] = "5";

                sheet2.Cells[4, 3] = "-5";
                sheet2.Cells[4, 4] = "0";
                sheet2.Cells[4, 5] = "5";




                // Return control of Excel to the user
                _app.Visible = true;
                _app.UserControl = true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

    }
}
