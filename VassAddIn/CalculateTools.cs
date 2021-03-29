using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VassAddIn
{
    public partial class CalculateTools : UserControl
    {
        public CalculateTools()
        {
            InitializeComponent();
        }

        private void radioBtnFrac_ValueChanged(object sender, bool value)
        {
         
        }

        private void calculate1()
        {
   
        }

        private void calculate2()
        {
          
        }

        private void originDenominator_TextChanged(object sender, EventArgs e)
        {
            calculate1();
        }

        private void originNumerator_TextChanged(object sender, EventArgs e)
        {
            calculate1();
        }

        private void originDecimal_TextChanged(object sender, EventArgs e)
        {
            calculate2();
        }

        private void simplify()
        {

        }

        public int commonDivisor(int num1, int num2)
        {
            int re = 1;
            while (num1 % num2 > 0)
            {
                re = num1 % num2;
                num1 = num2;
                num2 = re;
            }
            return re;
        }
    }
}
