﻿namespace VassAddIn {
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
            this.btnTransRob = this.Factory.CreateRibbonButton();
            this.groupPNIP = this.Factory.CreateRibbonGroup();
            this.btnImportPNIP = this.Factory.CreateRibbonButton();
            this.groupGraph = this.Factory.CreateRibbonGroup();
            this.btnGenerateS7G = this.Factory.CreateRibbonButton();
            this.btnFormatS7G = this.Factory.CreateRibbonButton();
            this.groupTranslate = this.Factory.CreateRibbonGroup();
            this.btnTransSheet = this.Factory.CreateRibbonButton();
            this.btnTransBook = this.Factory.CreateRibbonButton();
            this.btnShowDic = this.Factory.CreateRibbonButton();
            this.btnSaveDic = this.Factory.CreateRibbonButton();
            this.groupWorkbook = this.Factory.CreateRibbonGroup();
            this.buttonClean = this.Factory.CreateRibbonButton();
            this.groupAbout = this.Factory.CreateRibbonGroup();
            this.btnHelp = this.Factory.CreateRibbonButton();
            this.btnFeedback = this.Factory.CreateRibbonButton();
            this.btnAbout = this.Factory.CreateRibbonButton();
            this.openSymbolsDialog = new System.Windows.Forms.OpenFileDialog();
            this.openHardwareCfg = new System.Windows.Forms.OpenFileDialog();
            this.tabVassTools.SuspendLayout();
            this.groupSymbol.SuspendLayout();
            this.groupPNIP.SuspendLayout();
            this.groupGraph.SuspendLayout();
            this.groupTranslate.SuspendLayout();
            this.groupWorkbook.SuspendLayout();
            this.groupAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabVassTools
            // 
            this.tabVassTools.Groups.Add(this.groupSymbol);
            this.tabVassTools.Groups.Add(this.groupPNIP);
            this.tabVassTools.Groups.Add(this.groupGraph);
            this.tabVassTools.Groups.Add(this.groupTranslate);
            this.tabVassTools.Groups.Add(this.groupWorkbook);
            this.tabVassTools.Groups.Add(this.groupAbout);
            resources.ApplyResources(this.tabVassTools, "tabVassTools");
            this.tabVassTools.Name = "tabVassTools";
            this.tabVassTools.Position = this.Factory.RibbonPosition.AfterOfficeId("TabDeveloper");
            // 
            // groupSymbol
            // 
            this.groupSymbol.Items.Add(this.buttonReadSymbol);
            this.groupSymbol.Items.Add(this.btnTransRob);
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
            // btnTransRob
            // 
            this.btnTransRob.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            resources.ApplyResources(this.btnTransRob, "btnTransRob");
            this.btnTransRob.Name = "btnTransRob";
            this.btnTransRob.OfficeImageId = "TranslateToSimplifiedChinese";
            this.btnTransRob.ShowImage = true;
            this.btnTransRob.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BtnTransRob_Click);
            // 
            // groupPNIP
            // 
            this.groupPNIP.Items.Add(this.btnImportPNIP);
            resources.ApplyResources(this.groupPNIP, "groupPNIP");
            this.groupPNIP.Name = "groupPNIP";
            // 
            // btnImportPNIP
            // 
            this.btnImportPNIP.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            resources.ApplyResources(this.btnImportPNIP, "btnImportPNIP");
            this.btnImportPNIP.Name = "btnImportPNIP";
            this.btnImportPNIP.OfficeImageId = "OrganizationChartLayoutRightHanging";
            this.btnImportPNIP.ShowImage = true;
            this.btnImportPNIP.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnImportPNIP_Click);
            // 
            // groupGraph
            // 
            this.groupGraph.Items.Add(this.btnGenerateS7G);
            this.groupGraph.Items.Add(this.btnFormatS7G);
            resources.ApplyResources(this.groupGraph, "groupGraph");
            this.groupGraph.Name = "groupGraph";
            // 
            // btnGenerateS7G
            // 
            this.btnGenerateS7G.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            resources.ApplyResources(this.btnGenerateS7G, "btnGenerateS7G");
            this.btnGenerateS7G.Name = "btnGenerateS7G";
            this.btnGenerateS7G.OfficeImageId = "PublishToPdfOrEdoc";
            this.btnGenerateS7G.ShowImage = true;
            // 
            // btnFormatS7G
            // 
            this.btnFormatS7G.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            resources.ApplyResources(this.btnFormatS7G, "btnFormatS7G");
            this.btnFormatS7G.Name = "btnFormatS7G";
            this.btnFormatS7G.OfficeImageId = "FPTableAutoFormat";
            this.btnFormatS7G.ShowImage = true;
            this.btnFormatS7G.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnFormatS7G_Click);
            // 
            // groupTranslate
            // 
            this.groupTranslate.Items.Add(this.btnTransSheet);
            this.groupTranslate.Items.Add(this.btnTransBook);
            this.groupTranslate.Items.Add(this.btnShowDic);
            this.groupTranslate.Items.Add(this.btnSaveDic);
            resources.ApplyResources(this.groupTranslate, "groupTranslate");
            this.groupTranslate.Name = "groupTranslate";
            // 
            // btnTransSheet
            // 
            this.btnTransSheet.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            resources.ApplyResources(this.btnTransSheet, "btnTransSheet");
            this.btnTransSheet.Name = "btnTransSheet";
            this.btnTransSheet.OfficeImageId = "Translate";
            this.btnTransSheet.ShowImage = true;
            // 
            // btnTransBook
            // 
            this.btnTransBook.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            resources.ApplyResources(this.btnTransBook, "btnTransBook");
            this.btnTransBook.Name = "btnTransBook";
            this.btnTransBook.OfficeImageId = "Translator";
            this.btnTransBook.ShowImage = true;
            // 
            // btnShowDic
            // 
            this.btnShowDic.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            resources.ApplyResources(this.btnShowDic, "btnShowDic");
            this.btnShowDic.Name = "btnShowDic";
            this.btnShowDic.OfficeImageId = "Thesaurus";
            this.btnShowDic.ShowImage = true;
            // 
            // btnSaveDic
            // 
            this.btnSaveDic.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            resources.ApplyResources(this.btnSaveDic, "btnSaveDic");
            this.btnSaveDic.Name = "btnSaveDic";
            this.btnSaveDic.OfficeImageId = "FunctionsTextInsertGallery";
            this.btnSaveDic.ShowImage = true;
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
            // groupAbout
            // 
            this.groupAbout.Items.Add(this.btnHelp);
            this.groupAbout.Items.Add(this.btnFeedback);
            this.groupAbout.Items.Add(this.btnAbout);
            resources.ApplyResources(this.groupAbout, "groupAbout");
            this.groupAbout.Name = "groupAbout";
            // 
            // btnHelp
            // 
            this.btnHelp.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            resources.ApplyResources(this.btnHelp, "btnHelp");
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.OfficeImageId = "Help";
            this.btnHelp.ShowImage = true;
            this.btnHelp.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnHelp_Click);
            // 
            // btnFeedback
            // 
            this.btnFeedback.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            resources.ApplyResources(this.btnFeedback, "btnFeedback");
            this.btnFeedback.Name = "btnFeedback";
            this.btnFeedback.OfficeImageId = "ShapeSmileyFace";
            this.btnFeedback.ShowImage = true;
            this.btnFeedback.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnFeedback_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            resources.ApplyResources(this.btnAbout, "btnAbout");
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.OfficeImageId = "Info";
            this.btnAbout.ShowImage = true;
            this.btnAbout.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnAbout_Click);
            // 
            // openSymbolsDialog
            // 
            resources.ApplyResources(this.openSymbolsDialog, "openSymbolsDialog");
            // 
            // openHardwareCfg
            // 
            resources.ApplyResources(this.openHardwareCfg, "openHardwareCfg");
            // 
            // VassRibbon
            // 
            this.Name = "VassRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tabVassTools);
            resources.ApplyResources(this, "$this");
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.VassRibbon_Load);
            this.tabVassTools.ResumeLayout(false);
            this.tabVassTools.PerformLayout();
            this.groupSymbol.ResumeLayout(false);
            this.groupSymbol.PerformLayout();
            this.groupPNIP.ResumeLayout(false);
            this.groupPNIP.PerformLayout();
            this.groupGraph.ResumeLayout(false);
            this.groupGraph.PerformLayout();
            this.groupTranslate.ResumeLayout(false);
            this.groupTranslate.PerformLayout();
            this.groupWorkbook.ResumeLayout(false);
            this.groupWorkbook.PerformLayout();
            this.groupAbout.ResumeLayout(false);
            this.groupAbout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabVassTools;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupSymbol;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonReadSymbol;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupWorkbook;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonClean;
        private System.Windows.Forms.OpenFileDialog openSymbolsDialog;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupTranslate;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnTransSheet;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnTransBook;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnTransRob;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnShowDic;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSaveDic;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupPNIP;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnImportPNIP;
        private System.Windows.Forms.OpenFileDialog openHardwareCfg;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupAbout;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnHelp;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAbout;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnFeedback;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupGraph;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnGenerateS7G;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnFormatS7G;
    }

    partial class ThisRibbonCollection {
        internal VassRibbon VassRibbon {
            get { return this.GetRibbon<VassRibbon>(); }
        }
    }
}
