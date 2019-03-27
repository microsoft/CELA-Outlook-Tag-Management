namespace CELA_Email_Tags_Outlook_Plugin
{
    partial class CustomTagRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public CustomTagRibbon()
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
            this.celaCustom = this.Factory.CreateRibbonTab();
            this.celaKMGroup = this.Factory.CreateRibbonGroup();
            this.showTagManagementTaskPaneToggleButton = this.Factory.CreateRibbonToggleButton();
            this.manageTagsButton = this.Factory.CreateRibbonButton();
            this.archiveButton = this.Factory.CreateRibbonButton();
            this.settingsButton = this.Factory.CreateRibbonButton();
            this.celaCustom.SuspendLayout();
            this.celaKMGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // celaCustom
            // 
            this.celaCustom.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.celaCustom.Groups.Add(this.celaKMGroup);
            this.celaCustom.Label = "CELA Custom";
            this.celaCustom.Name = "celaCustom";
            // 
            // celaKMGroup
            // 
            this.celaKMGroup.Items.Add(this.showTagManagementTaskPaneToggleButton);
            this.celaKMGroup.Items.Add(this.manageTagsButton);
            this.celaKMGroup.Items.Add(this.archiveButton);
            this.celaKMGroup.Items.Add(this.settingsButton);
            this.celaKMGroup.Label = "CELA KM";
            this.celaKMGroup.Name = "celaKMGroup";
            // 
            // showTagManagementTaskPaneToggleButton
            // 
            this.showTagManagementTaskPaneToggleButton.Label = "Manage Tags";
            this.showTagManagementTaskPaneToggleButton.Name = "showTagManagementTaskPaneToggleButton";
            this.showTagManagementTaskPaneToggleButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.showTagManagementTaskPaneToggleButton_Click);
            // 
            // manageTagsButton
            // 
            this.manageTagsButton.Image = global::CELA_Email_Tags_Outlook_Plugin.CELA_Custom_Ribbon.Checked;
            this.manageTagsButton.Label = "Add Tags";
            this.manageTagsButton.Name = "manageTagsButton";
            this.manageTagsButton.ShowImage = true;
            // 
            // archiveButton
            // 
            this.archiveButton.Image = global::CELA_Email_Tags_Outlook_Plugin.CELA_Custom_Ribbon.Archive;
            this.archiveButton.Label = "Send to Archive";
            this.archiveButton.Name = "archiveButton";
            this.archiveButton.ShowImage = true;
            // 
            // settingsButton
            // 
            this.settingsButton.Image = global::CELA_Email_Tags_Outlook_Plugin.CELA_Custom_Ribbon.Settings;
            this.settingsButton.Label = "Settings";
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.ShowImage = true;
            // 
            // CustomTagRibbon
            // 
            this.Name = "CustomTagRibbon";
            this.RibbonType = "Microsoft.Outlook.Mail.Compose, Microsoft.Outlook.Mail.Read";
            this.Tabs.Add(this.celaCustom);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.CustomTagRibbon_Load);
            this.celaCustom.ResumeLayout(false);
            this.celaCustom.PerformLayout();
            this.celaKMGroup.ResumeLayout(false);
            this.celaKMGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab celaCustom;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup celaKMGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton manageTagsButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton settingsButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton archiveButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton showTagManagementTaskPaneToggleButton;
    }

    partial class ThisRibbonCollection
    {
        internal CustomTagRibbon CustomTagRibbon
        {
            get { return this.GetRibbon<CustomTagRibbon>(); }
        }
    }
}
