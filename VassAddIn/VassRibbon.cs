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
                    string line = "";
                    while ((line = reader.ReadLine()) != null) {
                        string[] ss = line.Split(new string[] { "\",\"" }, StringSplitOptions.RemoveEmptyEntries);
                        if (ss.Length == 4) {
                            ss[0] = ss[0].Substring(1).Trim();
                            ss[1] = ss[1].Trim();
                            ss[3] = ss[3].Substring(0, ss[3].Length - 1).Trim();
                            RobEA rob = new RobEA(ss[0], ss[1], ss[3]);
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
                        Range Cells = worksheet.Cells;
                        List<RobEA> list = kvp.Value;
                        var query = from rob in list orderby rob.getAddr() ascending select rob;
                        // header
                        Range range = worksheet.get_Range("A1", "C1");
                        range.Merge();
                        range.Value2 = "PLC >> Rob";
                        range = worksheet.get_Range("D1", "F1");
                        range.Merge();
                        range.Value2 = "Rob >> PLC";
                        range = worksheet.get_Range("A1", "F1");
                        range.HorizontalAlignment = Constants.xlCenter;
                        range.VerticalAlignment = Constants.xlCenter;
                        range.Rows.RowHeight = 22;
                        range.Interior.Color = 11921586;

                        //
                        Cells[2, 1].Value2 = "符号";
                        Cells[2, 2].Value2 = "地址";
                        Cells[2, 3].Value2 = "描述";
                        Cells[2, 4].Value2 = "符号";
                        Cells[2, 5].Value2 = "地址";
                        Cells[2, 6].Value2 = "描述";
                        range = worksheet.get_Range("A2", "F2");
                        range.HorizontalAlignment = Constants.xlCenter;
                        range.VerticalAlignment = Constants.xlCenter;

                        int rowLeft = 3;
                        int rowRight = 3;
                        foreach (var rob in query) {
                            if (rob.getType() == SignalType.E) {
                                Cells[rowLeft, 1].Value2 = rob.getSignal();
                                Cells[rowLeft, 2].Value2 = rob.getAddrText();
                                Cells[rowLeft, 3].Value2 = rob.getComment();
                                rowLeft++;
                            } else if (rob.getType() == SignalType.A) {
                                Cells[rowRight, 4].Value2 = rob.getSignal();
                                Cells[rowRight, 5].Value2 = rob.getAddrText();
                                Cells[rowRight, 6].Value2 = rob.getComment();
                                rowRight++;
                            }
                        }
                        rowLeft = rowRight = Math.Max(rowLeft, rowRight);

                        // header2
                        range = worksheet.Range[Cells[rowLeft, 1], Cells[rowLeft, 3]];
                        range.Merge();
                        range.Value2 = "完成信号";
                        range = worksheet.Range[Cells[rowLeft, 4], Cells[rowLeft, 6]];
                        range.Merge();
                        range.Value2 = "程序号";
                        range = worksheet.Range[Cells[rowLeft, 1], Cells[rowLeft, 6]];
                        range.HorizontalAlignment = Constants.xlCenter;
                        range.VerticalAlignment = Constants.xlCenter;
                        range.Rows.RowHeight = 22;
                        range.Interior.Color = 11921586;

                        //
                        Cells[rowLeft + 1, 1].Value2 = "符号";
                        Cells[rowLeft + 1, 2].Value2 = "地址";
                        Cells[rowLeft + 1, 3].Value2 = "描述";
                        Cells[rowLeft + 1, 4].Value2 = "符号";
                        Cells[rowLeft + 1, 5].Value2 = "地址";
                        Cells[rowLeft + 1, 6].Value2 = "描述";
                        range = worksheet.Range[Cells[rowLeft + 1, 1], Cells[rowLeft + 1, 6]];
                        range.HorizontalAlignment = Constants.xlCenter;
                        range.VerticalAlignment = Constants.xlCenter;

                        rowLeft = rowRight = rowLeft + 2;
                        //
                        foreach (var rob in query) {
                            if (rob.getType() == SignalType.FM) {
                                Cells[rowLeft, 1].Value2 = rob.getSignal();
                                Cells[rowLeft, 2].Value2 = rob.getAddrText();
                                Cells[rowLeft, 3].Value2 = rob.getComment();
                                rowLeft++;
                            } else if (rob.getType() == SignalType.FG) {
                                Cells[rowRight, 4].Value2 = rob.getSignal();
                                Cells[rowRight, 5].Value2 = rob.getAddrText();
                                Cells[rowRight, 6].Value2 = rob.getComment();
                                rowRight++;
                            }
                        }

                        // worksheet style
                        worksheet.Columns.AutoFit();
                    }
                } catch (Exception ex) {
                    MessageBox.Show($"Error message: {ex.Message}\n" + $"Details:\n{ex.StackTrace}");
                }
            }
        }
    }
}
