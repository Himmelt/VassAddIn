using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using Microsoft.Office.Interop.Excel;
using Worksheet = Microsoft.Office.Interop.Excel.Worksheet;
using System.Text.RegularExpressions;
using Workbook = Microsoft.Office.Interop.Excel.Workbook;

namespace VassAddIn {
    public partial class ThisAddIn {
        private void ThisAddIn_Startup(object sender, System.EventArgs e) {
            Application.DisplayAlerts = false;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e) {
        }

        public void ClearWorkBook() {
            Sheets sheets = Application.ActiveWorkbook.Sheets;
            sheets.Add().Name = "29185D52CD5441A";
            foreach (dynamic sheet in sheets) {
                if (sheet.Name != "29185D52CD5441A") {
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
        private void InternalStartup() {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }

    public static class Utils {
        public static bool contains(Sheets sheets, string name) {
            bool found = false;
            foreach (dynamic sheet in sheets) {
                if (sheet.Name == name) {
                    found = true;
                    break;
                }
            }
            return found;
        }

        public static Worksheet createEmptySheet(Workbook workbook, string name) {
            dynamic sheet = workbook.Sheets.Add(After: workbook.ActiveSheet);
            try {
                workbook.Sheets[name].Delete();
            } catch (Exception) { }
            sheet.Name = name;
            Worksheet worksheet = sheet;
            return worksheet;
        }
    }

    public class RobEA {
        private int number = 0;
        private float address = 0.0F;
        private string signal = "";
        private string comment = "";
        private static Regex SIGNAL = new Regex(@"M_\d{6}R0\d_([EA]\d{2}(_\S+)?|FM\d)");
        private static Regex ROB = new Regex(@"\d{6}R0\d");

        public RobEA(string signal, string address, string comment) {
            if (SIGNAL.IsMatch(signal)) {
                GroupCollection groups = ROB.Match(signal).Groups;
                if (groups.Count > 0) {
                    string text = groups[0].Value.Replace("R0", "");
                    this.number = Convert.ToInt32(text);
                    text = address.Replace("M ", "").Trim();
                    this.signal = signal.Trim();
                    this.address = Convert.ToSingle(text);
                    this.comment = comment.Trim();
                }
            }
        }

        public int getNum() {
            return number;
        }

        public string getSignal() {
            return signal;
        }

        public float getAddr() {
            return address;
        }

        public string getAddrText() {
            return "M " + address.ToString("#.0");
        }

        public string getComment() {
            return comment;
        }
    }
}
