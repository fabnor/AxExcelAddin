namespace AXExcelAddIn
{
    partial class PublishItem : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public PublishItem()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Test = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.Test.SuspendLayout();
            // 
            // Test
            // 
            this.Test.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.Test.Groups.Add(this.group1);
            this.Test.Label = "Test";
            this.Test.Name = "Test";
            // 
            // group1
            // 
            this.group1.Label = "group1";
            this.group1.Name = "group1";
            // 
            // PublishItem
            // 
            this.Name = "PublishItem";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.Test);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.PublishItem_Load);
            this.Test.ResumeLayout(false);
            this.Test.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab Test;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
    }

    partial class ThisRibbonCollection
    {
        internal PublishItem PublishItem
        {
            get { return this.GetRibbon<PublishItem>(); }
        }
    }
}
