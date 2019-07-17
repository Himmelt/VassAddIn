using System;
using System.Collections;
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
                    var reader = new StreamReader(fileName);
                    Dictionary<int, List<RobEA>> map = new Dictionary<int, List<RobEA>>();
                    String line = "";
                    while ((line = reader.ReadLine()) != null) {
                        string[] ss = line.Split('\t');
                        if (ss.Length == 4) {
                            RobEA rob = new RobEA(ss[2], ss[1], ss[3]);
                            int num = rob.getNum();
                            if (num != 0) {
                                if (!map.ContainsKey(num)) map.Add(num, new List<RobEA>());
                                map[num].Add(rob);
                            }
                        }
                    }
                    reader.Close();

                    var sort = from obj in map orderby obj.Key ascending select obj;
                    foreach (KeyValuePair<int, List<RobEA>> kvp in sort) {
                        int num = kvp.Key;
                        string sheetName = num.ToString();
                        sheetName = sheetName.Insert(sheetName.Length - 1, "R0");
                        Worksheet worksheet = Utils.createEmptySheet(workbook, sheetName);
                        List<RobEA> list = kvp.Value;
                        var query = from rob in list orderby rob.getAddr() ascending select rob;
                        int row = 1;
                        foreach (var rob in query) {
                            worksheet.Cells[row, 1].Value2 = rob.getSignal();
                            worksheet.Cells[row, 2].Value2 = rob.getAddrText();
                            worksheet.Cells[row, 3].Value2 = rob.getComment();
                            row++;
                        }
                        worksheet.Columns.AutoFit();
                    }
                } catch (Exception ex) {
                    MessageBox.Show($"Error message: {ex.Message}\n" + $"Details:\n{ex.StackTrace}");
                }
            }
        }
    }
}
