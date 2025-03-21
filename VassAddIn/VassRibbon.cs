﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools;
using Microsoft.Office.Tools.Ribbon;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace VassAddIn
{
    public partial class VassRibbon
    {

        private Application application;

        private static Regex HW_DEVICE_LINE = new Regex(@"IOSUBSYSTEM \d+, IOADDRESS \d+, "".+, ""[0-9A-Z-]{22}""");
        private static Regex HW_DEVICE_ID = new Regex(@"IOADDRESS \d+");
        private static Regex HW_DEVICE_NAME = new Regex(@"[0-9A-Za-z-]{22}");
        private static Regex HW_IP = new Regex(@"[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}");

        private void VassRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            application = Globals.ThisAddIn.Application;
        }

        private void ButtonClean_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.ClearWorkBook();
        }

        private void ButtonReadSdf_Click(object sender, RibbonControlEventArgs e)
        {
            if (openSymbolsDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileName = openSymbolsDialog.FileName;
                    readSymbols(new StreamReader(fileName), "\",\"");
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


        private void btnHwImportIP_Click(object sender, RibbonControlEventArgs e)
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
                        if (HW_DEVICE_LINE.IsMatch(line))
                        {
                            int id = -1;
                            string name = "";
                            GroupCollection idGroups = HW_DEVICE_ID.Match(line).Groups;
                            if (idGroups.Count > 0)
                            {
                                string text = idGroups[0].Value.Replace("IOADDRESS", "").Trim();
                                id = Convert.ToInt32(text);
                            }
                            GroupCollection nameGroups = HW_DEVICE_NAME.Match(line).Groups;
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
                    string name = item.Value.ToUpper();
                    for (int i = 0; i < name.Length; i++)
                    {
                        Cells[row + id, col + i].Value2 = name.Substring(i, 1);
                    }
                }
            }
        }

        private void btnTopoImportIP_Click(object sender, RibbonControlEventArgs e)
        {
            if (openTopologyCsv.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileName = openTopologyCsv.FileName;
                    var reader = new StreamReader(fileName);

                    Worksheet worksheet = application.ActiveSheet;
                    Range Cells = worksheet.Cells;

                    int theIp_1 = Convert.ToInt32(Cells[7, 4].Value2);
                    int theIp_2 = Convert.ToInt32(Cells[7, 6].Value2);
                    int theIp_3 = Convert.ToInt32(Cells[7, 8].Value2);

                    string line = "";
                    Dictionary<int, IpName> map = new Dictionary<int, IpName>();

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] ss = line.Split(new string[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries);
                        IpName ipName = new IpName("", -1, -1, -1, -1);
                        foreach (string s in ss)
                        {
                            if (HW_DEVICE_NAME.IsMatch(s))
                            {
                                ipName.name = s.ToUpper();
                            }
                            else if (HW_IP.IsMatch(s))
                            {
                                string[] ips = s.Split(new string[] { "." }, StringSplitOptions.None);
                                ipName.ip_1 = Convert.ToInt32(ips[0]);
                                ipName.ip_2 = Convert.ToInt32(ips[1]);
                                ipName.ip_3 = Convert.ToInt32(ips[2]);
                                ipName.ip_4 = Convert.ToInt32(ips[3]);
                            }
                        }
                        if (ipName.isValid(theIp_1, theIp_2, theIp_3))
                        {
                            try
                            {
                                map.Add(ipName.ip_4, ipName);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error at IP address : {ipName.ip_4}");
                                MessageBox.Show($"Error message: {ex.Message}\n" + $"Details:\n{ex.StackTrace}");
                            }
                        }
                    }

                    reader.Close();

                    foreach (var item in map)
                    {
                        int id = item.Key;
                        string name = item.Value.name;
                        for (int i = 0; i < name.Length; i++)
                        {
                            Cells[7 + id, 12 + i].Value2 = name.Substring(i, 1);
                        }
                        Cells[7 + id, 4].Value2 = item.Value.ip_1;
                        Cells[7 + id, 6].Value2 = item.Value.ip_2;
                        Cells[7 + id, 8].Value2 = item.Value.ip_3;
                        Cells[7 + id, 10].Value2 = item.Value.ip_4;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error message: {ex.Message}\n" + $"Details:\n{ex.StackTrace}");
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
        }

        private void btnFormatS7G_Click(object sender, RibbonControlEventArgs e)
        {
        }

        private void nearFract_Click(object sender, RibbonControlEventArgs e)
        {
            if (ThisAddIn.taskPanes.TryGetValue(application.ActiveWorkbook.FullName, out CustomTaskPane pane))
            {
                pane.Visible = !pane.Visible;
            }
        }

        private void ButtonReadPaste_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                readSymbols(new StringReader(Clipboard.GetText()), "\t");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error message: {ex.Message}\n" + $"Details:\n{ex.StackTrace}");
            }
        }

        private void readSymbols(TextReader reader, string spliter)
        {
            Workbook workbook = application.ActiveWorkbook;
            Dictionary<string, List<RobEA>> map = new Dictionary<string, List<RobEA>>();
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                string[] ss = line.Split(new string[] { spliter }, StringSplitOptions.RemoveEmptyEntries);
                if (ss.Length == 4)
                {
                    if (ss[0].StartsWith("\""))
                    {
                        ss[0] = ss[0].Substring(1).Trim();
                    }
                    else
                    {
                        ss[0] = ss[0].Trim();
                    }
                    ss[1] = ss[1].Trim();
                    if (ss[3].EndsWith("\""))
                    {
                        ss[3] = ss[3].Substring(0, ss[3].Length - 1).Trim();
                    }
                    else
                    {
                        ss[3] = ss[3].Trim();
                    }
                    RobEA rob = new RobEA(ss[0], ss[1], ss[3]);
                    string num = rob.getNum();
                    if (num != null && !num.Equals(""))
                    {
                        if (!map.ContainsKey(num)) map.Add(num, new List<RobEA>());
                        map[num].Add(rob);
                    }
                }
            }
            reader.Close();

            var sort = from obj in map orderby obj.Key ascending select obj;
            foreach (KeyValuePair<string, List<RobEA>> kvp in sort)
            {
                string num = kvp.Key;
                string sheetName = kvp.Key; //num.ToString();
                sheetName = sheetName.Insert(sheetName.Length - 1, "R0");
                Worksheet worksheet = Utils.createEmptySheet(workbook, sheetName);
                Range Cells = worksheet.Cells;
                List<RobEA> list = kvp.Value;
                var query = from rob in list orderby rob.getAddr() ascending select rob;

                worksheet.Columns[1].ColumnWidth = 26;
                worksheet.Columns[2].ColumnWidth = 10;
                worksheet.Columns[2].HorizontalAlignment = Constants.xlCenter;

                worksheet.Columns[4].ColumnWidth = 26;
                worksheet.Columns[5].ColumnWidth = 10;
                worksheet.Columns[5].HorizontalAlignment = Constants.xlCenter;

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

                worksheet.Columns[3].AutoFit();
                worksheet.Columns[6].AutoFit();
                if (worksheet.Columns[3].ColumnWidth < 50)
                {
                    worksheet.Columns[3].ColumnWidth = 50;
                }
                if (worksheet.Columns[6].ColumnWidth < 50)
                {
                    worksheet.Columns[6].ColumnWidth = 50;
                }
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

        private void btnSymbolsOrder_Click(object sender, RibbonControlEventArgs e)
        {
            Worksheet worksheet = application.ActiveSheet;
            var selection = application.Selection;
            if (selection is Range range)
            {
                try
                {
                    Range cells = range.Columns[1].Cells;
                    string start = cells[1].Value2;
                    start = start.Trim();
                    string head = start.Substring(0, 1);

                    int address = (int)(Convert.ToSingle(start.Remove(0, 1).Trim()) * 10);
                    int count = cells.Count;
                    for (int i = 1; i <= count; i++)
                    {
                        int m = address % 10;
                        if (m == 8)
                        {
                            address += 2;
                        }
                        cells[i].Value2 = head + "    " + string.Format("{0:F1}", address / 10F);
                        address++;
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
