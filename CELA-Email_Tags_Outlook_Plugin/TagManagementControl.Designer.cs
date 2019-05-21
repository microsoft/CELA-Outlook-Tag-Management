namespace CELA_Email_Tags_Outlook_Plugin
{
    partial class TagManagementControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.tagsLibraryTreeView = new System.Windows.Forms.TreeView();
            this.addTagsButton = new System.Windows.Forms.Button();
            this.tagsAvailableLabel = new System.Windows.Forms.Label();
            this.tagPatternsLabel = new System.Windows.Forms.Label();
            this.tagPatternsListBox = new System.Windows.Forms.CheckedListBox();
            this.removeAllTags = new System.Windows.Forms.Button();
            this.tagsInEmailLabel = new System.Windows.Forms.Label();
            this.tagsUsedListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // tagsLibraryTreeView
            // 
            this.tagsLibraryTreeView.Location = new System.Drawing.Point(0, 46);
            this.tagsLibraryTreeView.Name = "tagsLibraryTreeView";
            this.tagsLibraryTreeView.Size = new System.Drawing.Size(362, 228);
            this.tagsLibraryTreeView.TabIndex = 1;
            this.tagsLibraryTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tagsTreeView_AfterSelect);
			this.tagsLibraryTreeView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TagsLibraryTreeView_MouseDoubleClick);
            // 
            // addTagsButton
            // 
            this.addTagsButton.Location = new System.Drawing.Point(100, 280);
            this.addTagsButton.Name = "addTagsButton";
            this.addTagsButton.Size = new System.Drawing.Size(194, 45);
            this.addTagsButton.TabIndex = 5;
            this.addTagsButton.Text = "Add Tags";
            this.addTagsButton.UseVisualStyleBackColor = true;
            this.addTagsButton.Click += new System.EventHandler(this.addTagsButton_Click);
            // 
            // tagsAvailableLabel
            // 
            this.tagsAvailableLabel.AutoSize = true;
            this.tagsAvailableLabel.Location = new System.Drawing.Point(3, 16);
            this.tagsAvailableLabel.Name = "tagsAvailableLabel";
            this.tagsAvailableLabel.Size = new System.Drawing.Size(173, 25);
            this.tagsAvailableLabel.TabIndex = 4;
            this.tagsAvailableLabel.Text = "Your Tag Library";
            // 
            // tagPatternsLabel
            // 
            this.tagPatternsLabel.AutoSize = true;
            this.tagPatternsLabel.Location = new System.Drawing.Point(4, 633);
            this.tagPatternsLabel.Name = "tagPatternsLabel";
            this.tagPatternsLabel.Size = new System.Drawing.Size(266, 25);
            this.tagPatternsLabel.TabIndex = 3;
            this.tagPatternsLabel.Text = "Your Custom Tag Patterns";
            // 
            // tagPatternsListBox
            // 
            this.tagPatternsListBox.FormattingEnabled = true;
            this.tagPatternsListBox.Location = new System.Drawing.Point(0, 662);
            this.tagPatternsListBox.Name = "tagPatternsListBox";
            this.tagPatternsListBox.Size = new System.Drawing.Size(362, 186);
            this.tagPatternsListBox.TabIndex = 2;
            // 
            // removeAllTags
            // 
            this.removeAllTags.Location = new System.Drawing.Point(100, 564);
            this.removeAllTags.Name = "removeAllTags";
            this.removeAllTags.Size = new System.Drawing.Size(194, 55);
            this.removeAllTags.TabIndex = 0;
            this.removeAllTags.Text = "Remove All Tags";
            this.removeAllTags.UseVisualStyleBackColor = true;
            this.removeAllTags.Click += new System.EventHandler(this.removeAllTagsButton_Click);
            // 
            // tagsInEmailLabel
            // 
            this.tagsInEmailLabel.AutoSize = true;
            this.tagsInEmailLabel.Location = new System.Drawing.Point(6, 327);
            this.tagsInEmailLabel.Name = "tagsInEmailLabel";
            this.tagsInEmailLabel.Size = new System.Drawing.Size(122, 25);
            this.tagsInEmailLabel.TabIndex = 6;
            this.tagsInEmailLabel.Text = "Tags Used:";
            this.tagsInEmailLabel.Click += new System.EventHandler(this.tagsInEmailLabel_Click);
            // 
            // tagsUsedListView
            // 
            this.tagsUsedListView.Location = new System.Drawing.Point(0, 356);
            this.tagsUsedListView.Name = "tagsUsedListView";
            this.tagsUsedListView.Size = new System.Drawing.Size(365, 202);
            this.tagsUsedListView.TabIndex = 7;
            this.tagsUsedListView.UseCompatibleStateImageBehavior = false;
            this.tagsUsedListView.SelectedIndexChanged += new System.EventHandler(this.tagsUsedListView_SelectedIndexChanged);
            // 
            // TagManagementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.tagsUsedListView);
            this.Controls.Add(this.tagsInEmailLabel);
            this.Controls.Add(this.addTagsButton);
            this.Controls.Add(this.tagsAvailableLabel);
            this.Controls.Add(this.tagPatternsLabel);
            this.Controls.Add(this.tagPatternsListBox);
            this.Controls.Add(this.tagsLibraryTreeView);
            this.Controls.Add(this.removeAllTags);
            this.Name = "TagManagementControl";
            this.Size = new System.Drawing.Size(365, 885);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tagsLibraryTreeView;
        private System.Windows.Forms.Button addTagsButton;
        private System.Windows.Forms.Label tagsAvailableLabel;
        private System.Windows.Forms.Label tagPatternsLabel;
        private System.Windows.Forms.CheckedListBox tagPatternsListBox;
        private System.Windows.Forms.Button removeAllTags;
        private System.Windows.Forms.Label tagsInEmailLabel;
        private System.Windows.Forms.ListView tagsUsedListView;
    }
}
