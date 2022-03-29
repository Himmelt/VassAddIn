
namespace VassAddIn
{
    partial class CalculateTools
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupOrigin = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioBtnDeci = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.radioBtnFrac = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.originDouble = new Guna.UI2.WinForms.Guna2TextBox();
            this.originDenominator = new Guna.UI2.WinForms.Guna2TextBox();
            this.originNumerator = new Guna.UI2.WinForms.Guna2TextBox();
            this.groupResult = new Guna.UI2.WinForms.Guna2GroupBox();
            this.maxDenominator = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.maxNumerator = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.resultDouble = new Guna.UI2.WinForms.Guna2TextBox();
            this.resultDenominator = new Guna.UI2.WinForms.Guna2TextBox();
            this.resultNumerator = new Guna.UI2.WinForms.Guna2TextBox();
            this.groupOrigin.SuspendLayout();
            this.groupResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxDenominator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxNumerator)).BeginInit();
            this.SuspendLayout();
            // 
            // groupOrigin
            // 
            this.groupOrigin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupOrigin.BackColor = System.Drawing.Color.Transparent;
            this.groupOrigin.BorderColor = System.Drawing.Color.Transparent;
            this.groupOrigin.BorderThickness = 2;
            this.groupOrigin.Controls.Add(this.label4);
            this.groupOrigin.Controls.Add(this.radioBtnDeci);
            this.groupOrigin.Controls.Add(this.radioBtnFrac);
            this.groupOrigin.Controls.Add(this.guna2Separator1);
            this.groupOrigin.Controls.Add(this.originDouble);
            this.groupOrigin.Controls.Add(this.originDenominator);
            this.groupOrigin.Controls.Add(this.originNumerator);
            this.groupOrigin.CustomBorderColor = System.Drawing.Color.Transparent;
            this.groupOrigin.FillColor = System.Drawing.Color.Transparent;
            this.groupOrigin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupOrigin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupOrigin.Location = new System.Drawing.Point(8, 32);
            this.groupOrigin.Name = "groupOrigin";
            this.groupOrigin.ShadowDecoration.Parent = this.groupOrigin;
            this.groupOrigin.Size = new System.Drawing.Size(550, 220);
            this.groupOrigin.TabIndex = 0;
            this.groupOrigin.Text = "原始精确值";
            this.groupOrigin.UseTransparentBackground = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label4.Location = new System.Drawing.Point(264, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "=";
            // 
            // radioBtnDeci
            // 
            this.radioBtnDeci.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radioBtnDeci.CheckedState.BorderThickness = 0;
            this.radioBtnDeci.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radioBtnDeci.CheckedState.InnerColor = System.Drawing.Color.White;
            this.radioBtnDeci.CheckedState.Parent = this.radioBtnDeci;
            this.radioBtnDeci.Location = new System.Drawing.Point(407, 176);
            this.radioBtnDeci.Name = "radioBtnDeci";
            this.radioBtnDeci.ShadowDecoration.Parent = this.radioBtnDeci;
            this.radioBtnDeci.Size = new System.Drawing.Size(20, 20);
            this.radioBtnDeci.TabIndex = 5;
            this.radioBtnDeci.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.radioBtnDeci.UncheckedState.BorderThickness = 2;
            this.radioBtnDeci.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radioBtnDeci.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.radioBtnDeci.UncheckedState.Parent = this.radioBtnDeci;
            // 
            // radioBtnFrac
            // 
            this.radioBtnFrac.Checked = true;
            this.radioBtnFrac.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radioBtnFrac.CheckedState.BorderThickness = 0;
            this.radioBtnFrac.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radioBtnFrac.CheckedState.InnerColor = System.Drawing.Color.White;
            this.radioBtnFrac.CheckedState.Parent = this.radioBtnFrac;
            this.radioBtnFrac.Location = new System.Drawing.Point(123, 176);
            this.radioBtnFrac.Name = "radioBtnFrac";
            this.radioBtnFrac.ShadowDecoration.Parent = this.radioBtnFrac;
            this.radioBtnFrac.Size = new System.Drawing.Size(20, 20);
            this.radioBtnFrac.TabIndex = 4;
            this.radioBtnFrac.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.radioBtnFrac.UncheckedState.BorderThickness = 2;
            this.radioBtnFrac.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radioBtnFrac.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.radioBtnFrac.UncheckedState.Parent = this.radioBtnFrac;
            this.radioBtnFrac.CheckedChanged += new System.EventHandler(this.radioBtnFrac_CheckedChanged);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.Black;
            this.guna2Separator1.Location = new System.Drawing.Point(12, 97);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(240, 10);
            this.guna2Separator1.TabIndex = 3;
            this.guna2Separator1.UseTransparentBackground = true;
            // 
            // originDouble
            // 
            this.originDouble.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.originDouble.DefaultText = "0.0";
            this.originDouble.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.originDouble.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.originDouble.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.originDouble.DisabledState.Parent = this.originDouble;
            this.originDouble.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.originDouble.Enabled = false;
            this.originDouble.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.originDouble.FocusedState.Parent = this.originDouble;
            this.originDouble.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.originDouble.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.originDouble.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.originDouble.HoverState.Parent = this.originDouble;
            this.originDouble.Location = new System.Drawing.Point(297, 86);
            this.originDouble.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.originDouble.Name = "originDouble";
            this.originDouble.PasswordChar = '\0';
            this.originDouble.PlaceholderText = "";
            this.originDouble.SelectedText = "";
            this.originDouble.SelectionStart = 3;
            this.originDouble.ShadowDecoration.Parent = this.originDouble;
            this.originDouble.Size = new System.Drawing.Size(240, 35);
            this.originDouble.TabIndex = 2;
            this.originDouble.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.originDouble.TextChanged += new System.EventHandler(this.originDouble_TextChanged);
            this.originDouble.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.originDouble_KeyPress);
            // 
            // originDenominator
            // 
            this.originDenominator.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.originDenominator.DefaultText = "1";
            this.originDenominator.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.originDenominator.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.originDenominator.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.originDenominator.DisabledState.Parent = this.originDenominator;
            this.originDenominator.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.originDenominator.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.originDenominator.FocusedState.Parent = this.originDenominator;
            this.originDenominator.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.originDenominator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.originDenominator.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.originDenominator.HoverState.Parent = this.originDenominator;
            this.originDenominator.Location = new System.Drawing.Point(12, 119);
            this.originDenominator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.originDenominator.Name = "originDenominator";
            this.originDenominator.PasswordChar = '\0';
            this.originDenominator.PlaceholderText = "";
            this.originDenominator.SelectedText = "";
            this.originDenominator.SelectionStart = 1;
            this.originDenominator.ShadowDecoration.Parent = this.originDenominator;
            this.originDenominator.Size = new System.Drawing.Size(240, 35);
            this.originDenominator.TabIndex = 1;
            this.originDenominator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.originDenominator.TextChanged += new System.EventHandler(this.originDenominator_TextChanged);
            this.originDenominator.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.originDenominator_KeyPress);
            // 
            // originNumerator
            // 
            this.originNumerator.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.originNumerator.DefaultText = "0";
            this.originNumerator.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.originNumerator.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.originNumerator.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.originNumerator.DisabledState.Parent = this.originNumerator;
            this.originNumerator.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.originNumerator.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.originNumerator.FocusedState.Parent = this.originNumerator;
            this.originNumerator.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.originNumerator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.originNumerator.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.originNumerator.HoverState.Parent = this.originNumerator;
            this.originNumerator.Location = new System.Drawing.Point(12, 50);
            this.originNumerator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.originNumerator.Name = "originNumerator";
            this.originNumerator.PasswordChar = '\0';
            this.originNumerator.PlaceholderText = "";
            this.originNumerator.SelectedText = "";
            this.originNumerator.SelectionStart = 1;
            this.originNumerator.ShadowDecoration.Parent = this.originNumerator;
            this.originNumerator.Size = new System.Drawing.Size(240, 35);
            this.originNumerator.TabIndex = 0;
            this.originNumerator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.originNumerator.TextChanged += new System.EventHandler(this.originNumerator_TextChanged);
            this.originNumerator.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.originNumerator_KeyPress);
            // 
            // groupResult
            // 
            this.groupResult.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupResult.BackColor = System.Drawing.Color.Transparent;
            this.groupResult.BorderColor = System.Drawing.Color.Transparent;
            this.groupResult.BorderThickness = 2;
            this.groupResult.Controls.Add(this.maxDenominator);
            this.groupResult.Controls.Add(this.maxNumerator);
            this.groupResult.Controls.Add(this.label3);
            this.groupResult.Controls.Add(this.label2);
            this.groupResult.Controls.Add(this.label1);
            this.groupResult.Controls.Add(this.guna2Separator2);
            this.groupResult.Controls.Add(this.resultDouble);
            this.groupResult.Controls.Add(this.resultDenominator);
            this.groupResult.Controls.Add(this.resultNumerator);
            this.groupResult.CustomBorderColor = System.Drawing.Color.Transparent;
            this.groupResult.FillColor = System.Drawing.Color.Transparent;
            this.groupResult.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupResult.Location = new System.Drawing.Point(8, 286);
            this.groupResult.Name = "groupResult";
            this.groupResult.ShadowDecoration.Parent = this.groupResult;
            this.groupResult.Size = new System.Drawing.Size(550, 250);
            this.groupResult.TabIndex = 6;
            this.groupResult.Text = "最趋近最简整数比";
            this.groupResult.UseTransparentBackground = true;
            // 
            // maxDenominator
            // 
            this.maxDenominator.BackColor = System.Drawing.Color.Transparent;
            this.maxDenominator.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.maxDenominator.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.maxDenominator.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.maxDenominator.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.maxDenominator.DisabledState.Parent = this.maxDenominator;
            this.maxDenominator.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.maxDenominator.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.maxDenominator.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.maxDenominator.FocusedState.Parent = this.maxDenominator;
            this.maxDenominator.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.maxDenominator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.maxDenominator.Location = new System.Drawing.Point(386, 190);
            this.maxDenominator.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.maxDenominator.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxDenominator.Name = "maxDenominator";
            this.maxDenominator.ShadowDecoration.Parent = this.maxDenominator;
            this.maxDenominator.Size = new System.Drawing.Size(150, 35);
            this.maxDenominator.TabIndex = 10;
            this.maxDenominator.Value = new decimal(new int[] {
            8191,
            0,
            0,
            0});
            // 
            // maxNumerator
            // 
            this.maxNumerator.BackColor = System.Drawing.Color.Transparent;
            this.maxNumerator.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.maxNumerator.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.maxNumerator.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.maxNumerator.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.maxNumerator.DisabledState.Parent = this.maxNumerator;
            this.maxNumerator.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.maxNumerator.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.maxNumerator.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.maxNumerator.FocusedState.Parent = this.maxNumerator;
            this.maxNumerator.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.maxNumerator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.maxNumerator.Location = new System.Drawing.Point(103, 190);
            this.maxNumerator.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.maxNumerator.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxNumerator.Name = "maxNumerator";
            this.maxNumerator.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.maxNumerator.ShadowDecoration.Parent = this.maxNumerator;
            this.maxNumerator.Size = new System.Drawing.Size(150, 35);
            this.maxNumerator.TabIndex = 9;
            this.maxNumerator.Value = new decimal(new int[] {
            8191,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label3.Location = new System.Drawing.Point(264, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(296, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "分母最大值";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "分子最大值";
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.FillColor = System.Drawing.Color.Black;
            this.guna2Separator2.Location = new System.Drawing.Point(13, 99);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(240, 10);
            this.guna2Separator2.TabIndex = 3;
            this.guna2Separator2.UseTransparentBackground = true;
            // 
            // resultDouble
            // 
            this.resultDouble.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.resultDouble.DefaultText = "0.0";
            this.resultDouble.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.resultDouble.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.resultDouble.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.resultDouble.DisabledState.Parent = this.resultDouble;
            this.resultDouble.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.resultDouble.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.resultDouble.FocusedState.Parent = this.resultDouble;
            this.resultDouble.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.resultDouble.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.resultDouble.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.resultDouble.HoverState.Parent = this.resultDouble;
            this.resultDouble.Location = new System.Drawing.Point(297, 86);
            this.resultDouble.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.resultDouble.Name = "resultDouble";
            this.resultDouble.PasswordChar = '\0';
            this.resultDouble.PlaceholderText = "";
            this.resultDouble.ReadOnly = true;
            this.resultDouble.SelectedText = "";
            this.resultDouble.SelectionStart = 3;
            this.resultDouble.ShadowDecoration.Parent = this.resultDouble;
            this.resultDouble.Size = new System.Drawing.Size(240, 35);
            this.resultDouble.TabIndex = 2;
            this.resultDouble.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // resultDenominator
            // 
            this.resultDenominator.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.resultDenominator.DefaultText = "1";
            this.resultDenominator.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.resultDenominator.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.resultDenominator.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.resultDenominator.DisabledState.Parent = this.resultDenominator;
            this.resultDenominator.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.resultDenominator.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.resultDenominator.FocusedState.Parent = this.resultDenominator;
            this.resultDenominator.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.resultDenominator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.resultDenominator.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.resultDenominator.HoverState.Parent = this.resultDenominator;
            this.resultDenominator.Location = new System.Drawing.Point(13, 119);
            this.resultDenominator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.resultDenominator.Name = "resultDenominator";
            this.resultDenominator.PasswordChar = '\0';
            this.resultDenominator.PlaceholderText = "";
            this.resultDenominator.ReadOnly = true;
            this.resultDenominator.SelectedText = "";
            this.resultDenominator.SelectionStart = 1;
            this.resultDenominator.ShadowDecoration.Parent = this.resultDenominator;
            this.resultDenominator.Size = new System.Drawing.Size(240, 35);
            this.resultDenominator.TabIndex = 1;
            this.resultDenominator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // resultNumerator
            // 
            this.resultNumerator.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.resultNumerator.DefaultText = "0";
            this.resultNumerator.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.resultNumerator.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.resultNumerator.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.resultNumerator.DisabledState.Parent = this.resultNumerator;
            this.resultNumerator.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.resultNumerator.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.resultNumerator.FocusedState.Parent = this.resultNumerator;
            this.resultNumerator.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.resultNumerator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.resultNumerator.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.resultNumerator.HoverState.Parent = this.resultNumerator;
            this.resultNumerator.Location = new System.Drawing.Point(13, 54);
            this.resultNumerator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.resultNumerator.Name = "resultNumerator";
            this.resultNumerator.PasswordChar = '\0';
            this.resultNumerator.PlaceholderText = "";
            this.resultNumerator.ReadOnly = true;
            this.resultNumerator.SelectedText = "";
            this.resultNumerator.SelectionStart = 1;
            this.resultNumerator.ShadowDecoration.Parent = this.resultNumerator;
            this.resultNumerator.Size = new System.Drawing.Size(240, 35);
            this.resultNumerator.TabIndex = 0;
            this.resultNumerator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CalculateTools
            // 
            this.Controls.Add(this.groupResult);
            this.Controls.Add(this.groupOrigin);
            this.Name = "CalculateTools";
            this.Size = new System.Drawing.Size(565, 563);
            this.groupOrigin.ResumeLayout(false);
            this.groupOrigin.PerformLayout();
            this.groupResult.ResumeLayout(false);
            this.groupResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxDenominator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxNumerator)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox groupOrigin;
        private Guna.UI2.WinForms.Guna2TextBox originDenominator;
        private Guna.UI2.WinForms.Guna2TextBox originNumerator;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2CustomRadioButton radioBtnDeci;
        private Guna.UI2.WinForms.Guna2CustomRadioButton radioBtnFrac;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2GroupBox groupResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Guna.UI2.WinForms.Guna2TextBox resultDouble;
        private Guna.UI2.WinForms.Guna2TextBox resultDenominator;
        private Guna.UI2.WinForms.Guna2TextBox resultNumerator;
        private Guna.UI2.WinForms.Guna2TextBox originDouble;
        private Guna.UI2.WinForms.Guna2NumericUpDown maxDenominator;
        private Guna.UI2.WinForms.Guna2NumericUpDown maxNumerator;
    }
}
