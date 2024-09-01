namespace DeepwokenChecklist
{
    partial class Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.TalentGroup = new System.Windows.Forms.GroupBox();
            this.TalentCheckList = new System.Windows.Forms.CheckedListBox();
            this.NextTalentGroup = new System.Windows.Forms.GroupBox();
            this.RequirementsTree = new System.Windows.Forms.TreeView();
            this.QuickCheckGroup = new System.Windows.Forms.GroupBox();
            this.QuickCheckBox = new System.Windows.Forms.ComboBox();
            this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deepwokenBuilderURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TalentGroup.SuspendLayout();
            this.NextTalentGroup.SuspendLayout();
            this.QuickCheckGroup.SuspendLayout();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TalentGroup
            // 
            this.TalentGroup.Controls.Add(this.TalentCheckList);
            this.TalentGroup.Location = new System.Drawing.Point(13, 80);
            this.TalentGroup.Name = "TalentGroup";
            this.TalentGroup.Size = new System.Drawing.Size(200, 312);
            this.TalentGroup.TabIndex = 3;
            this.TalentGroup.TabStop = false;
            this.TalentGroup.Text = "Talents";
            // 
            // TalentCheckList
            // 
            this.TalentCheckList.CheckOnClick = true;
            this.TalentCheckList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TalentCheckList.FormattingEnabled = true;
            this.TalentCheckList.Location = new System.Drawing.Point(3, 16);
            this.TalentCheckList.Name = "TalentCheckList";
            this.TalentCheckList.Size = new System.Drawing.Size(194, 293);
            this.TalentCheckList.TabIndex = 0;
            this.TalentCheckList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TalentCheckList_ItemCheck);
            // 
            // NextTalentGroup
            // 
            this.NextTalentGroup.Controls.Add(this.RequirementsTree);
            this.NextTalentGroup.Location = new System.Drawing.Point(219, 28);
            this.NextTalentGroup.Name = "NextTalentGroup";
            this.NextTalentGroup.Size = new System.Drawing.Size(200, 361);
            this.NextTalentGroup.TabIndex = 4;
            this.NextTalentGroup.TabStop = false;
            this.NextTalentGroup.Text = "Next Talent Requirements";
            // 
            // RequirementsTree
            // 
            this.RequirementsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RequirementsTree.Indent = 19;
            this.RequirementsTree.Location = new System.Drawing.Point(3, 16);
            this.RequirementsTree.Name = "RequirementsTree";
            this.RequirementsTree.Size = new System.Drawing.Size(194, 342);
            this.RequirementsTree.TabIndex = 6;
            // 
            // QuickCheckGroup
            // 
            this.QuickCheckGroup.Controls.Add(this.QuickCheckBox);
            this.QuickCheckGroup.Location = new System.Drawing.Point(13, 28);
            this.QuickCheckGroup.Name = "QuickCheckGroup";
            this.QuickCheckGroup.Size = new System.Drawing.Size(200, 46);
            this.QuickCheckGroup.TabIndex = 3;
            this.QuickCheckGroup.TabStop = false;
            this.QuickCheckGroup.Text = "Quick Check";
            // 
            // QuickCheckBox
            // 
            this.QuickCheckBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.QuickCheckBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.QuickCheckBox.FormattingEnabled = true;
            this.QuickCheckBox.Location = new System.Drawing.Point(6, 18);
            this.QuickCheckBox.Name = "QuickCheckBox";
            this.QuickCheckBox.Size = new System.Drawing.Size(184, 21);
            this.QuickCheckBox.Sorted = true;
            this.QuickCheckBox.TabIndex = 0;
            this.QuickCheckBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QuickCheckBox_KeyDown);
            // 
            // SaveDialog
            // 
            this.SaveDialog.Filter = "Trackwoken Saves|*.twk";
            // 
            // OpenDialog
            // 
            this.OpenDialog.FileName = "openFileDialog1";
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(432, 24);
            this.Menu.TabIndex = 5;
            this.Menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.deepwokenBuilderURLToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // deepwokenBuilderURLToolStripMenuItem
            // 
            this.deepwokenBuilderURLToolStripMenuItem.Name = "deepwokenBuilderURLToolStripMenuItem";
            this.deepwokenBuilderURLToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.deepwokenBuilderURLToolStripMenuItem.Text = "Deepwoken Builder URL";
            this.deepwokenBuilderURLToolStripMenuItem.Click += new System.EventHandler(this.deepwokenBuilderURLToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 401);
            this.Controls.Add(this.QuickCheckGroup);
            this.Controls.Add(this.NextTalentGroup);
            this.Controls.Add(this.TalentGroup);
            this.Controls.Add(this.Menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Menu;
            this.Name = "Main";
            this.Text = "Trackwoken";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.TalentGroup.ResumeLayout(false);
            this.NextTalentGroup.ResumeLayout(false);
            this.QuickCheckGroup.ResumeLayout(false);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox TalentGroup;
        private System.Windows.Forms.CheckedListBox TalentCheckList;
        private System.Windows.Forms.GroupBox NextTalentGroup;
        private System.Windows.Forms.TreeView RequirementsTree;
        private System.Windows.Forms.GroupBox QuickCheckGroup;
        private System.Windows.Forms.ComboBox QuickCheckBox;
        private System.Windows.Forms.SaveFileDialog SaveDialog;
        private System.Windows.Forms.OpenFileDialog OpenDialog;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deepwokenBuilderURLToolStripMenuItem;
    }
}

