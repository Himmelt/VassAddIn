namespace VassAddIn {
    partial class VassRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public VassRibbon()
            : base(Globals.Factory.GetRibbonFactory()) {
            InitializeComponent();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VassRibbon));
            this.tabVassTools = this.Factory.CreateRibbonTab();
            this.groupSymbol = this.Factory.CreateRibbonGroup();
            this.buttonReadSymbol = this.Factory.CreateRibbonButton();
            this.groupWorkbook = this.Factory.CreateRibbonGroup();
            this.buttonClean = this.Factory.CreateRibbonButton();
            this.openSymbolsDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabVassTools.SuspendLayout();
            this.groupSymbol.SuspendLayout();
            this.groupWorkbook.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabVassTools
            // 
            this.tabVassTools.Groups.Add(this.groupSymbol);
            this.tabVassTools.Groups.Add(this.groupWorkbook);
            resources.ApplyResources(this.tabVassTools, "tabVassTools");
            this.tabVassTools.Name = "tabVassTools";
            this.tabVassTools.Position = this.Factory.RibbonPosition.AfterOfficeId("TabDeveloper");
            // 
            // groupSymbol
            // 
            this.groupSymbol.Items.Add(this.buttonReadSymbol);
            resources.ApplyResources(this.groupSymbol, "groupSymbol");
            this.groupSymbol.Name = "groupSymbol";
            // 
            // buttonReadSymbol
            // 
            this.buttonReadSymbol.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            resources.ApplyResources(this.buttonReadSymbol, "buttonReadSymbol");
            this.buttonReadSymbol.Name = "buttonReadSymbol";
            this.buttonReadSymbol.OfficeImageId = "ImportTextFile";
            this.buttonReadSymbol.ShowImage = true;
            this.buttonReadSymbol.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ButtonReadSymbol_Click);
            // 
            // groupWorkbook
            // 
            this.groupWorkbook.Items.Add(this.buttonClean);
            resources.ApplyResources(this.groupWorkbook, "groupWorkbook");
            this.groupWorkbook.Name = "groupWorkbook";
            // 
            // buttonClean
            // 
            this.buttonClean.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            resources.ApplyResources(this.buttonClean, "buttonClean");
            this.buttonClean.Name = "buttonClean";
            this.buttonClean.OfficeImageId = "DeleteTable";
            this.buttonClean.ShowImage = true;
            this.buttonClean.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ButtonClean_Click);
            // 
            // openSymbolsDialog
            // 
            resources.ApplyResources(this.openSymbolsDialog, "openSymbolsDialog");
            // 
            // VassRibbon
            // 
            this.Name = "VassRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tabVassTools);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.VassRibbon_Load);
            this.tabVassTools.ResumeLayout(false);
            this.tabVassTools.PerformLayout();
            this.groupSymbol.ResumeLayout(false);
            this.groupSymbol.PerformLayout();
            this.groupWorkbook.ResumeLayout(false);
            this.groupWorkbook.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabVassTools;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupSymbol;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonReadSymbol;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupWorkbook;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonClean;
        private System.Windows.Forms.OpenFileDialog openSymbolsDialog;
    }

    partial class ThisRibbonCollection {
        internal VassRibbon VassRibbon {
            get { return this.GetRibbon<VassRibbon>(); }
        }
    }
}
