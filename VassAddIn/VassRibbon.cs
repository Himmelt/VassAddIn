using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;

namespace VassAddIn {
    public partial class VassRibbon {
        private void VassRibbon_Load(object sender, RibbonUIEventArgs e) {

        }

        private void ButtonClean_Click(object sender, RibbonControlEventArgs e) {
            Globals.ThisAddIn.ClearWorkBook();
        }

        private void ButtonReadSymbol_Click(object sender, RibbonControlEventArgs e) {
            Workbook workbook = Globals.ThisAddIn.Application.ActiveWorkbook;

            if (openSymbolsDialog.ShowDialog() == DialogResult.OK) {
                try {
                    var reader = new StreamReader(openSymbolsDialog.FileName);
                    reader.Close();
                    Sheets sheets = workbook.Sheets;
                    dynamic sheet = sheets.Add();
                    try {
                        sheets["EmptySheet"].Delete();
                    } catch (Exception) { }
                    try {
                        sheets["Symbols"].Delete();
                    } catch (Exception) { }
                    sheet.Name = "Symbols";
                } catch (Exception ex) {
                    MessageBox.Show($"Error message: {ex.Message}\n" + $"Details:\n{ex.StackTrace}");
                }
            }
        }
    }
}
