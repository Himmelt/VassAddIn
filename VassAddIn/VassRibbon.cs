using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Interop;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace VassAddIn
{
    public partial class VassRibbon
    {

        private Application application;

        private static Regex DEVICE_LINE = new Regex(@"IOSUBSYSTEM \d+, IOADDRESS \d+, "".+, ""[0-9A-Z-]{22}""");
        private static Regex DEVICE_ID = new Regex(@"IOADDRESS \d+");
        private static Regex DEVICE_NAME = new Regex(@"""[0-9A-Z-]{22}""");
        private void VassRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            application = Globals.ThisAddIn.Application;
        }

        private void ButtonClean_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.ClearWorkBook();
        }

        private void ButtonReadSymbol_Click(object sender, RibbonControlEventArgs e)
        {
            Workbook workbook = application.ActiveWorkbook;
            if (openSymbolsDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileName = openSymbolsDialog.FileName;
                    var reader = new StreamReader(fileName);
                    Dictionary<int, List<RobEA>> map = new Dictionary<int, List<RobEA>>();
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] ss = line.Split(new string[] { "\",\"" }, StringSplitOptions.RemoveEmptyEntries);
                        if (ss.Length == 4)
                        {
                            ss[0] = ss[0].Substring(1).Trim();
                            ss[1] = ss[1].Trim();
                            ss[3] = ss[3].Substring(0, ss[3].Length - 1).Trim();
                            RobEA rob = new RobEA(ss[0], ss[1], ss[3]);
                            int num = rob.getNum();
                            if (num != 0)
                            {
                                if (!map.ContainsKey(num)) map.Add(num, new List<RobEA>());
                                map[num].Add(rob);
                            }
                        }
                    }
                    reader.Close();

                    var sort = from obj in map orderby obj.Key ascending select obj;
                    foreach (KeyValuePair<int, List<RobEA>> kvp in sort)
                    {
                        int num = kvp.Key;
                        string sheetName = num.ToString();
                        sheetName = sheetName.Insert(sheetName.Length - 1, "R0");
                        Worksheet worksheet = Utils.createEmptySheet(workbook, sheetName);
                        Range Cells = worksheet.Cells;
                        List<RobEA> list = kvp.Value;
                        var query = from rob in list orderby rob.getAddr() ascending select rob;

                        worksheet.Columns[1].ColumnWidth = 26;
                        worksheet.Columns[2].ColumnWidth = 10;
                        worksheet.Columns[2].HorizontalAlignment = Constants.xlCenter;
                        worksheet.Columns[3].ColumnWidth = 50;
                        worksheet.Columns[4].ColumnWidth = 26;
                        worksheet.Columns[5].ColumnWidth = 10;
                        worksheet.Columns[5].HorizontalAlignment = Constants.xlCenter;
                        worksheet.Columns[6].ColumnWidth = 50;
                        worksheet.Rows.RowHeight = 18;

                        // header1
                        Range range = worksheet.get_Range("A1", "C1");
                        range.Merge();
                        range.Value2 = "PLC >> Rob";
                        range.Interior.Color = 13561542;
                        range.Font.Color = -16752640;
                        range.Font.Bold = true;
                        range.Borders.Weight = XlBorderWeight.xlMedium;

                        range = worksheet.get_Range("D1", "F1");
                        range.Merge();
                        range.Value2 = "Rob >> PLC";
                        range.Interior.Color = 10283775;
                        range.Font.Color = -16751460;
                        range.Font.Bold = true;
                        range.Borders.Weight = XlBorderWeight.xlMedium;

                        range = worksheet.get_Range("A1", "F1");
                        range.HorizontalAlignment = Constants.xlCenter;
                        range.VerticalAlignment = Constants.xlCenter;
                        range.Rows.RowHeight = 24;

                        Cells[2, 1].Value2 = TextRes.colSymbol;
                        Cells[2, 2].Value2 = TextRes.colAddress;
                        Cells[2, 3].Value2 = TextRes.colComment;
                        Cells[2, 4].Value2 = TextRes.colSymbol;
                        Cells[2, 5].Value2 = TextRes.colAddress;
                        Cells[2, 6].Value2 = TextRes.colComment;
                        range = worksheet.get_Range("A2", "F2");
                        range.HorizontalAlignment = Constants.xlCenter;
                        range.VerticalAlignment = Constants.xlCenter;
                        range.Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlMedium;
                        range.Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlMedium;

                        int rowLeft = 3;
                        int rowRight = 3;
                        foreach (var rob in query)
                        {
                            if (rob.getType() == SignalType.E)
                            {
                                Cells[rowLeft, 1].Value2 = rob.getSignal();
                                Cells[rowLeft, 2].Value2 = rob.getAddrText();
                                Cells[rowLeft, 3].Value2 = rob.getComment();
                                rowLeft++;
                            }
                            else if (rob.getType() == SignalType.A)
                            {
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
                        range.Value2 = TextRes.txtFM;
                        range.Interior.Color = 13561542;
                        range.Font.Color = -16752640;
                        range.Font.Bold = true;
                        range.Borders.Weight = XlBorderWeight.xlMedium;

                        range = worksheet.Range[Cells[rowLeft, 4], Cells[rowLeft, 6]];
                        range.Merge();
                        range.Value2 = TextRes.txtFG;
                        range.Interior.Color = 10283775;
                        range.Font.Color = -16751460;
                        range.Font.Bold = true;
                        range.Borders.Weight = XlBorderWeight.xlMedium;

                        range = worksheet.Range[Cells[rowLeft, 1], Cells[rowLeft, 6]];
                        range.HorizontalAlignment = Constants.xlCenter;
                        range.VerticalAlignment = Constants.xlCenter;
                        range.Rows.RowHeight = 24;
                        range.Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlMedium;
                        range.Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlMedium;

                        Cells[rowLeft + 1, 1].Value2 = TextRes.colSymbol;
                        Cells[rowLeft + 1, 2].Value2 = TextRes.colAddress;
                        Cells[rowLeft + 1, 3].Value2 = TextRes.colComment;
                        Cells[rowLeft + 1, 4].Value2 = TextRes.colSymbol;
                        Cells[rowLeft + 1, 5].Value2 = TextRes.colAddress;
                        Cells[rowLeft + 1, 6].Value2 = TextRes.colComment;
                        range = worksheet.Range[Cells[rowLeft + 1, 1], Cells[rowLeft + 1, 6]];
                        range.HorizontalAlignment = Constants.xlCenter;
                        range.VerticalAlignment = Constants.xlCenter;
                        range.Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlMedium;
                        range.Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlMedium;

                        rowLeft = rowRight = rowLeft + 2;
                        foreach (var rob in query)
                        {
                            if (rob.getType() == SignalType.FM)
                            {
                                Cells[rowLeft, 1].Value2 = rob.getSignal();
                                Cells[rowLeft, 2].Value2 = rob.getAddrText();
                                Cells[rowLeft, 3].Value2 = rob.getComment();
                                rowLeft++;
                            }
                            else if (rob.getType() == SignalType.FG)
                            {
                                Cells[rowRight, 4].Value2 = rob.getSignal();
                                Cells[rowRight, 5].Value2 = rob.getAddrText();
                                Cells[rowRight, 6].Value2 = rob.getComment();
                                rowRight++;
                            }
                        }
                        rowLeft = rowRight = Math.Max(rowLeft, rowRight);
                        range = worksheet.Range[Cells[1, 1], Cells[rowLeft, 3]];
                        range.Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlMedium;
                        range.Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlMedium;
                        range = worksheet.Range[Cells[1, 4], Cells[rowLeft, 6]];
                        range.Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlMedium;
                        range.Borders[XlBordersIndex.xlEdgeRight].Weight = XlBorderWeight.xlMedium;
                    }
                    if (workbook.Sheets.Count > 1)
                    {
                        try
                        {
                            workbook.Sheets["EmptySheet"].Delete();
                        }
                        catch (Exception) { }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error message: {ex.Message}\n" + $"Details:\n{ex.StackTrace}");
                }
            }
        }

        private void BtnTransRob_Click(object sender, RibbonControlEventArgs e)
        {
            /*Range selection =  application.Selection as Range;
            if (selection != null) {
                foreach(dynamic cell in selection.Cells) {
                    cell.Value2 = cell.Value2;
                }
            }*/
        }

        private void btnImportPNIP_Click(object sender, RibbonControlEventArgs e)
        {
            if (openHardwareCfg.ShowDialog() == DialogResult.OK)
            {
                Dictionary<int, string> map = new Dictionary<int, string>();
                try
                {
                    string fileName = openHardwareCfg.FileName;
                    var reader = new StreamReader(fileName);
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (DEVICE_LINE.IsMatch(line))
                        {
                            int id = -1;
                            string name = "";
                            GroupCollection idGroups = DEVICE_ID.Match(line).Groups;
                            if (idGroups.Count > 0)
                            {
                                string text = idGroups[0].Value.Replace("IOADDRESS", "").Trim();
                                id = Convert.ToInt32(text);
                            }
                            GroupCollection nameGroups = DEVICE_NAME.Match(line).Groups;
                            if (nameGroups.Count > 0)
                            {
                                name = nameGroups[0].Value.Replace("\"", "").Trim();
                            }
                            if (id >= 0 && id <= 255 && name.Length == 22)
                            {
                                map.Add(id, name);
                            }
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error message: {ex.Message}\n" + $"Details:\n{ex.StackTrace}");
                }

                int row = application.ActiveCell.Row;
                int col = application.ActiveCell.Column;

                Worksheet worksheet = application.ActiveSheet;
                Range Cells = worksheet.Cells;
                foreach (var item in map)
                {
                    int id = item.Key;
                    string name = item.Value;
                    for (int i = 0; i < name.Length; i++)
                    {
                        Cells[row + id, col + i].Value2 = name.Substring(i, 1);
                    }
                }
            }
        }

        private void btnHelp_Click(object sender, RibbonControlEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.bilibili.com/video/av24511282");
        }
        private void btnFeedback_Click(object sender, RibbonControlEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Himmelt/VassAddIn/issues");
        }

        private void btnAbout_Click(object sender, RibbonControlEventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

    }
}
