﻿using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using Worksheet = Microsoft.Office.Interop.Excel.Worksheet;
using System.Text.RegularExpressions;
using Workbook = Microsoft.Office.Interop.Excel.Workbook;
using Microsoft.Office.Tools;

namespace VassAddIn
{
    public partial class ThisAddIn
    {

        public static Dictionary<string, CustomTaskPane> taskPanes = new Dictionary<string, CustomTaskPane>();
        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
            Application.WorkbookActivate += Application_WorkbookActivate;
            Application.DisplayAlerts = false;
        }

        private void ThisAddIn_Shutdown(object sender, EventArgs e)
        {
        }
        private void Application_WorkbookActivate(Workbook wb)
        {
            if (!taskPanes.ContainsKey(wb.FullName))
            {
                CustomTaskPane taskPane = CustomTaskPanes.Add(new CalculateTools(), TextRes.calTools);
                taskPane.Width = 580;
                taskPanes.Add(wb.FullName, taskPane);
            }
        }
        public void ClearWorkBook()
        {
            Sheets sheets = Application.ActiveWorkbook.Sheets;
            sheets.Add().Name = "29185D52CD5441A";
            foreach (dynamic sheet in sheets)
            {
                if (sheet.Name != "29185D52CD5441A")
                {
                    sheets[sheet.Name].Delete();
                }
            }
            sheets[1].Name = "EmptySheet";
        }

        #region VSTO 生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }

    public static class Utils
    {
        public static bool contains(Sheets sheets, string name)
        {
            bool found = false;
            foreach (dynamic sheet in sheets)
            {
                if (sheet.Name == name)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        public static Worksheet createEmptySheet(Workbook workbook, string name)
        {
            dynamic sheet = workbook.Sheets.Add(After: workbook.ActiveSheet);
            try
            {
                workbook.Sheets[name].Delete();
            }
            catch (Exception) { }
            sheet.Name = name;
            Worksheet worksheet = sheet;
            return worksheet;
        }
    }

    public class RobEA
    {
        private string number = null;
        private float address = 0.0F;
        private string signal = "";
        private string comment = "";
        private SignalType type = SignalType.NONE;
        private static Regex SIGNAL_E = new Regex(@"^M_[A-Z0-9]{6}R0\d_(E\d{2,3}(_\S+)?)(?<!_\d)$");
        private static Regex SIGNAL_A = new Regex(@"^M_[A-Z0-9]{6}R0\d_(A\d{2,3}(_\S+)?)$");
        private static Regex SIGNAL_FM = new Regex(@"^M_[A-Z0-9]{6}R0\d_FM[1-8]$");
        private static Regex SIGNAL_FG = new Regex(@"^M_[A-Z0-9]{6}R0\dFrgFolg\d{1,2}$");
        private static Regex ROB = new Regex(@"[A-Z0-9]{6}R0\d");

        public RobEA(string signal, string address, string comment)
        {
            bool isValid = true;
            if (SIGNAL_E.IsMatch(signal))
            {
                type = SignalType.E;
            }
            else if (SIGNAL_A.IsMatch(signal))
            {
                type = SignalType.A;
            }
            else if (SIGNAL_FM.IsMatch(signal))
            {
                type = SignalType.FM;
            }
            else if (SIGNAL_FG.IsMatch(signal))
            {
                type = SignalType.FG;
            }
            else
            {
                isValid = false;
            }
            if (isValid)
            {
                GroupCollection groups = ROB.Match(signal).Groups;
                if (groups.Count > 0)
                {
                    string text = groups[0].Value.Replace("R0", "");
                    number = text;// Convert.ToInt32(text);
                    text = address.Replace("M ", "").Trim();
                    this.signal = signal.Trim();
                    this.address = Convert.ToSingle(text);
                    this.comment = comment.Trim();
                }
            }
        }

        public string getNum()
        {
            return number;
        }

        public string getSignal()
        {
            return signal;
        }

        public float getAddr()
        {
            return address;
        }

        public string getAddrText()
        {
            return "M " + address.ToString("#.0");
        }

        public string getComment()
        {
            return comment;
        }

        public SignalType getType()
        {
            return type;
        }
    }

    public class IpName
    {
        public string name;
        public int ip_1, ip_2, ip_3, ip_4;

        public IpName(string name, int ip_1, int ip_2, int ip_3, int ip_4)
        {
            this.name = name;
            this.ip_1 = ip_1;
            this.ip_2 = ip_2;
            this.ip_3 = ip_3;
            this.ip_4 = ip_4;
        }

        public bool isValid(int ip_1, int ip_2, int ip_3)
        {
            return name.Length == 22 && this.ip_1 == ip_1 && this.ip_2 == ip_2 && this.ip_3 == ip_3 && ip_4 > 0 && ip_4 < 255;
        }
    }

    public enum SignalType
    {
        E, A, FM, FG, NONE
    }
}
