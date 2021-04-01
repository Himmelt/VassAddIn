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
                    double k = num1 * 1.0 / num2;
                    Vec2l result = calculateNearest(k, new Vec2l(decimal.ToInt64(maxDenominator.Value), decimal.ToInt64(maxNumerator.Value)));
                    resultDenominator.Text = result.x.ToString();
                    resultNumerator.Text = result.y.ToString();
                    resultDouble.Text = result.y == 0 ? "NaN" : (result.y * 1.0 / result.x).ToString();
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

        struct Vec2l
        {
            public long x;
            public long y;

            public Vec2l(long x, long y)
            {
                this.x = x;
                this.y = y;
            }
        }

        private static Vec2l calculateNearest(double k, Vec2l range)
        {
            if (k > 0 && range.x > 0 && range.y > 0)
            {
                double xx = Math.Min(range.y / k, range.x);
                double yy = Math.Min(range.x * k, range.y);

                double k_diff = double.MaxValue;
                Vec2l result = new Vec2l(0, 0);
                if (xx <= yy)
                {
                    long xx_left = (long)Math.Floor(xx);
                    long xx_right = (long)Math.Ceiling(xx);
                    if (xx_left == xx_right)
                    {
                        return new Vec2l(xx_left, range.y);
                    }
                    else
                    {
                        for (int i = 1; i <= xx_right; i++)
                        {
                            double yi = i * k;
                            long y_ceil = (long)Math.Ceiling(yi);
                            long y_floor = (long)Math.Floor(yi);
                            if (y_ceil > 0 && y_ceil <= range.y)
                            {
                                double tmp_diff = Math.Abs(k - y_ceil * 1.0 / i);
                                if (tmp_diff < k_diff)
                                {
                                    k_diff = tmp_diff;
                                    result.x = i;
                                    result.y = y_ceil;
                                }
                            }
                            if (y_floor > 0 && y_floor <= range.y)
                            {
                                double tmp_diff = Math.Abs(k - y_floor * 1.0 / i);
                                if (tmp_diff < k_diff)
                                {
                                    k_diff = tmp_diff;
                                    result.x = i;
                                    result.y = y_floor;
                                }
                            }
                        }
                        return result;
                    }
                }
                else
                {
                    long yy_left = (long)Math.Floor(yy);
                    long yy_right = (long)Math.Ceiling(yy);
                    if (yy_left == yy_right)
                    {
                        return new Vec2l(range.x, yy_left);
                    }
                    else
                    {
                        for (int i = 1; i <= yy_right; i++)
                        {
                            double xi = i / k;
                            long x_ceil = (long)Math.Ceiling(xi);
                            long x_floor = (long)Math.Floor(xi);
                            if (x_ceil > 0 && x_ceil <= range.x)
                            {
                                double tmp_diff = Math.Abs(k - i * 1.0 / x_ceil);
                                if (tmp_diff < k_diff)
                                {
                                    k_diff = tmp_diff;
                                    result.x = x_ceil;
                                    result.y = i;
                                }
                            }
                            if (x_floor > 0 && x_floor <= range.x)
                            {
                                double tmp_diff = Math.Abs(k - i * 1.0 / x_floor);
                                if (tmp_diff < k_diff)
                                {
                                    k_diff = tmp_diff;
                                    result.x = x_floor;
                                    result.y = i;
                                }
                            }
                        }
                        return result;
                    }
                }
            }
            return new Vec2l(0, 0);
        }
    }
}
