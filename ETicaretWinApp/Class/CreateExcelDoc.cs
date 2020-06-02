using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CSharp.RuntimeBinder;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;


namespace ETicaretWinApp
{

    public class CreateExcelDoc {
        private Microsoft.Office.Interop.Excel.Application app = null;
        private Microsoft.Office.Interop.Excel.Workbook workbook = null;
        private Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
        private Microsoft.Office.Interop.Excel.Range workSheet_range = null;
        private object misValue = System.Reflection.Missing.Value;
        public CreateExcelDoc() {
            createDoc();
        }


        public static void CreateExcellFromDataGrid(System.Windows.Forms.DataGridView gridView) {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excell File|*.xls";
            if (saveDialog.ShowDialog() != DialogResult.OK) {
                return;
            }
            CreateExcelDoc excell = new CreateExcelDoc();
            for (int i = 1; i <= gridView.ColumnCount; i++) {
                string cellName = GetCellNameByIndex(i) + "2";
                excell.createHeaders(2, i, gridView.Columns[i - 1].HeaderText, cellName, cellName, 1, "GRAY", true, 30, "n");
            }
            DataTable dt = (DataTable)gridView.DataSource;
            int rowNumber = 3;
            int rowIndex = 0;
            foreach (DataRow row in dt.Rows) {
                for (int i = 1; i <= gridView.ColumnCount; i++) {
                    string cellName = GetCellNameByIndex(i);
                    string dataFieldName = gridView.Columns[i - 1].DataPropertyName;
                    excell.addData(rowNumber, i, row[dataFieldName].ToString(), cellName + rowNumber, cellName + rowNumber, "#");
                }
                rowIndex++;
                rowNumber++;
            }


            excell.Save(saveDialog.FileName);
            Process.Start(saveDialog.FileName);


        }

        public static string GetCellNameByIndex(int index) {
            try {
                List<string> CellName = new List<string>();
                CellName.Add("A");
                CellName.Add("B");
                CellName.Add("C");
                CellName.Add("D");
                CellName.Add("E");
                CellName.Add("F");
                CellName.Add("G");
                CellName.Add("H");
                CellName.Add("I");
                CellName.Add("J");
                CellName.Add("K");
                CellName.Add("L");
                CellName.Add("M");
                CellName.Add("N");
                CellName.Add("O");
                CellName.Add("P");
                CellName.Add("Q");
                CellName.Add("R");
                CellName.Add("S");
                CellName.Add("T");
                CellName.Add("U");
                CellName.Add("V");
                CellName.Add("W");
                CellName.Add("X");
                CellName.Add("Y");
                CellName.Add("Z");


                CellName.Add("AA");
                CellName.Add("AB");
                CellName.Add("AC");
                CellName.Add("AD");
                CellName.Add("AE");
                CellName.Add("AF");
                CellName.Add("AG");
                CellName.Add("AH");
                CellName.Add("AI");
                CellName.Add("AJ");
                CellName.Add("AK");
                CellName.Add("AL");
                CellName.Add("AM");
                CellName.Add("AN");
                CellName.Add("AO");
                CellName.Add("AP");
                CellName.Add("AQ");
                CellName.Add("AR");
                CellName.Add("AS");
                CellName.Add("AT");
                CellName.Add("AU");
                CellName.Add("AV");
                CellName.Add("AW");
                CellName.Add("AX");
                CellName.Add("AY");
                CellName.Add("AZ");

                return CellName[index - 1];
            } catch (Exception ex) {
                return string.Empty;
            }
        }
        public void createDoc() {
            try {
                app = new Microsoft.Office.Interop.Excel.Application();
                app.Visible = false;
                workbook = app.Workbooks.Add(1);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];

            } catch (Exception e) {
                throw e;
            } finally {
            }
        }
        public void addData(int row, int col, string data, string cell1, string cell2, string format) {
            worksheet.Cells[row, col] = data;
            workSheet_range = worksheet.get_Range(cell1, cell2);
            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            workSheet_range.NumberFormat = format;
        }
        public void createHeaders(int row, int col, string htext, string cell1, string cell2, int mergeColumns, string b, bool font, int size, string fcolor) {
            worksheet.Cells[row, col] = htext;
            workSheet_range = worksheet.get_Range(cell1, cell2);
            workSheet_range.Merge(mergeColumns);
            switch (b) {
                case "YELLOW":
                    workSheet_range.Interior.Color = System.Drawing.Color.Yellow.ToArgb();
                    break;
                case "GRAY":
                    workSheet_range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
                    break;
                case "GAINSBORO":
                    workSheet_range.Interior.Color =
            System.Drawing.Color.Gainsboro.ToArgb();
                    break;
                case "Turquoise":
                    workSheet_range.Interior.Color =
            System.Drawing.Color.Turquoise.ToArgb();
                    break;
                case "PeachPuff":
                    workSheet_range.Interior.Color =
            System.Drawing.Color.PeachPuff.ToArgb();
                    break;
                default:
                    //  workSheet_range.Interior.Color = System.Drawing.Color..ToArgb();
                    break;
            }

            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            workSheet_range.Font.Bold = font;
            workSheet_range.ColumnWidth = size;
            if (fcolor.Equals("")) {
                workSheet_range.Font.Color = System.Drawing.Color.White.ToArgb();
            } else {
                workSheet_range.Font.Color = System.Drawing.Color.Black.ToArgb();
            }
        }

        public void Save(string saveFileName) {
            workbook.SaveAs(saveFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            workbook.Close(true, misValue, misValue);
            app.Quit();

            releaseObject(worksheet);
            releaseObject(workbook);
            releaseObject(app);
        }
        public void CloseWithoutSave() {
            workbook.Close(false, misValue, misValue);
            app.Quit();

            releaseObject(worksheet);
            releaseObject(workbook);
            releaseObject(app);
        }
        private void releaseObject(object obj) {
            try {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            } catch (Exception ex) {
                obj = null;

            } finally {
                GC.Collect();
            }
        }

    }
}
