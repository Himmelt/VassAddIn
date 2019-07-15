using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;

namespace VassAddIn {
    public partial class VassRibbon {
        private void VassRibbon_Load(object sender, RibbonUIEventArgs e) {

        }

        private void ButtonClean_Click(object sender, RibbonControlEventArgs e) {
            Globals.ThisAddIn.ClearWorkBook();
        }

        private void ButtonReadSymbol_Click(object sender, RibbonControlEventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = 
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                try {
                    var reader = new StreamReader(openFileDialog.FileName);
                    Globals.ThisAddIn.Application.ActiveCell.Value = reader.ReadToEnd();
                } catch (SecurityException ex) {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
    }
}
