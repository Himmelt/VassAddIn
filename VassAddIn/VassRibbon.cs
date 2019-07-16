using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace VassAddIn {
    public partial class VassRibbon {

        private Application application;

        private void VassRibbon_Load(object sender, RibbonUIEventArgs e) {
            application = Globals.ThisAddIn.Application;
        }

        private void ButtonClean_Click(object sender, RibbonControlEventArgs e) {
            Globals.ThisAddIn.ClearWorkBook();
        }

        private void ButtonReadSymbol_Click(object sender, RibbonControlEventArgs e) {
            Workbook workbook = application.ActiveWorkbook;
            if (openSymbolsDialog.ShowDialog() == DialogResult.OK) {
                try {
                    string fileName = openSymbolsDialog.FileName;
                    bool sdf = fileName.EndsWith(".sdf");
                    bool seq = fileName.EndsWith(".seq");
                    var reader = new StreamReader(fileName);

                    Sheets sheets = workbook.Sheets;
                    dynamic sheet = sheets.Add();
                    try {
                        sheets["EmptySheet"].Delete();
                    } catch (Exception) { }
                    try {
                        sheets["Symbols"].Delete();
                    } catch (Exception) { }
                    sheet.Name = "Symbols";

                    Worksheet worksheet = sheet;

                    String line = "";
                    int row = 1;
                    while ((line = reader.ReadLine()) != null) {
                        string[] ss = line.Split(seq ? '\t' : ',');
                        for (int i = 1; i <= ss.Length; i++) {
                            worksheet.Cells[row, i].Value2 = ss[i - 1];
                        }
                        row++;
                    }
                    reader.Close();

                } catch (Exception ex) {
                    MessageBox.Show($"Error message: {ex.Message}\n" + $"Details:\n{ex.StackTrace}");
                }
            }
        }
    }
}
