using System;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace VassAddIn
{
    public partial class CalculateTools : UserControl
    {
        public CalculateTools()
        {
            InitializeComponent();
        }

        private void originDenominator_TextChanged(object sender, EventArgs e)
        {
            if (radioBtnFrac.Checked)
            {
                calculate1();
            }
        }

        private void originNumerator_TextChanged(object sender, EventArgs e)
        {
            if (radioBtnFrac.Checked)
            {
                calculate1();
            }
        }
        private void originDouble_TextChanged(object sender, EventArgs e)
        {
            if (radioBtnDeci.Checked)
            {
                calculate2();
            }
        }

        public long commonDivisor(long num1, long num2)
        {
            long re = 1;
            while (num1 % num2 > 0)
            {
                re = num1 % num2;
                num1 = num2;
                num2 = re;
            }
            return re;
        }

        private void calculate1()
        {
            if (checkIntNum(originNumerator.Text)
                && checkIntNum(originDenominator.Text)
                && long.TryParse(originNumerator.Text, out long num1)
                && long.TryParse(originDenominator.Text, out long num2)
                && radioBtnFrac.Enabled)
            {
                if (num2 != 0)
                {
                    originDouble.Text = (num1 * 1.0 / num2).ToString();
                }
                else
                {
                    originDouble.Text = "NaN";
                }
            }
            else
            {
                originDouble.Text = "NaN";
            }
        }

        private void calculate2()
        {
            if (checkDoubleNum(originDouble.Text))
            {
                string text = originDouble.Text;
                while (text.StartsWith("0") && text.Length > 1)
                {
                    text = text.Substring(1);
                }
                if (long.TryParse(text.Replace(".", ""), out long num1) && radioBtnDeci.Checked)
                {
                    if (num1 == 0)
                    {
                        originNumerator.Text = "0";
                        originDenominator.Text = "1";
                    }
                    else
                    {
                        long num2 = 1;
                        string[] ss = text.Split('.');
                        if (ss.Length == 2)
                        {
                            num2 = pow(10, ss[1].Length);
                        }
                        if (num2 <= 0)
                        {
                            originNumerator.Text = "NaN";
                            originDenominator.Text = "NaN";
                        }
                        else
                        {
                            long cd = commonDivisor(num1, num2);
                            originNumerator.Text = (num1 * 1.0 / cd).ToString();
                            originDenominator.Text = (num2 * 1.0 / cd).ToString();
                        }
                    }
                }
            }
            else
            {
                originNumerator.Text = "";
                originDenominator.Text = "";
            }
        }

        private void radioBtnFrac_CheckedChanged(object sender, EventArgs e)
        {
            originNumerator.Enabled = radioBtnFrac.Checked;
            originDenominator.Enabled = radioBtnFrac.Checked;
            originDouble.Enabled = !radioBtnFrac.Checked;
        }

        private static Regex REG_INT_NUM = new Regex(@"^\d+$");
        private static Regex REG_DOUBLE_NUM = new Regex(@"^((\d+)?\.)?\d+$");

        private static bool checkIntNum(string text)
        {
            return text != null && REG_INT_NUM.IsMatch(text);
        }
        private static bool checkDoubleNum(string text)
        {
            return text != null && REG_DOUBLE_NUM.IsMatch(text);
        }

        private void originDouble_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '.' || e.KeyChar == 8)
            {
                if (e.KeyChar == '.' && originDouble.Text.Contains("."))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void originNumerator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void originDenominator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private static long pow(long @base, int pow)
        {
            if (pow == 0)
            {
                return 1;
            }
            long num = 1;
            for (int i = 0; i < pow; i++)
            {
                num *= @base;
            }
            return num;
        }
    }
}
