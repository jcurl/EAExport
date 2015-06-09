namespace EAExport
{
    partial class frmEAExport
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
            if (disposing && (components != null)) {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEAExport));
            this.mnuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpenXmi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExportCsv = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDash1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditSearchAlias = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treXmiStructure = new System.Windows.Forms.TreeView();
            this.imgIcons = new System.Windows.Forms.ImageList(this.components);
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStereotype = new System.Windows.Forms.TextBox();
            this.lblSteroetype = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.lblAlias = new System.Windows.Forms.Label();
            this.htmlNotes = new TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel();
            this.txtIdentifier = new System.Windows.Forms.TextBox();
            this.txtHeading = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblIdentifier = new System.Windows.Forms.Label();
            this.lblHeading = new System.Windows.Forms.Label();
            this.mnuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuStrip
            // 
            this.mnuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit});
            this.mnuStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuStrip.Name = "mnuStrip";
            this.mnuStrip.Size = new System.Drawing.Size(540, 24);
            this.mnuStrip.TabIndex = 0;
            this.mnuStrip.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpenXmi,
            this.mnuFileExportCsv,
            this.mnuDash1,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuFileOpenXmi
            // 
            this.mnuFileOpenXmi.Image = global::EAExport.Properties.Resources.Open;
            this.mnuFileOpenXmi.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuFileOpenXmi.Name = "mnuFileOpenXmi";
            this.mnuFileOpenXmi.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpenXmi.Size = new System.Drawing.Size(203, 22);
            this.mnuFileOpenXmi.Text = "&Open XMI";
            this.mnuFileOpenXmi.Click += new System.EventHandler(this.mnuFileOpenXmi_Click);
            // 
            // mnuFileExportCsv
            // 
            this.mnuFileExportCsv.Enabled = false;
            this.mnuFileExportCsv.Image = global::EAExport.Properties.Resources.SaveAs;
            this.mnuFileExportCsv.Name = "mnuFileExportCsv";
            this.mnuFileExportCsv.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.mnuFileExportCsv.Size = new System.Drawing.Size(203, 22);
            this.mnuFileExportCsv.Text = "&Export CSV";
            this.mnuFileExportCsv.Click += new System.EventHandler(this.mnuFileExportCsv_Click);
            // 
            // mnuDash1
            // 
            this.mnuDash1.Name = "mnuDash1";
            this.mnuDash1.Size = new System.Drawing.Size(200, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Image = global::EAExport.Properties.Resources.Exit;
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mnuFileExit.Size = new System.Drawing.Size(203, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditSearch});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(39, 20);
            this.mnuEdit.Text = "&Edit";
            // 
            // mnuEditSearch
            // 
            this.mnuEditSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditSearchAlias});
            this.mnuEditSearch.Enabled = false;
            this.mnuEditSearch.Image = global::EAExport.Properties.Resources.Search;
            this.mnuEditSearch.Name = "mnuEditSearch";
            this.mnuEditSearch.Size = new System.Drawing.Size(152, 22);
            this.mnuEditSearch.Text = "&Search";
            // 
            // mnuEditSearchAlias
            // 
            this.mnuEditSearchAlias.Name = "mnuEditSearchAlias";
            this.mnuEditSearchAlias.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mnuEditSearchAlias.Size = new System.Drawing.Size(168, 22);
            this.mnuEditSearchAlias.Text = "For &Alias...";
            this.mnuEditSearchAlias.Click += new System.EventHandler(this.mnuEditSearchAlias_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treXmiStructure);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtStatus);
            this.splitContainer1.Panel2.Controls.Add(this.lblStatus);
            this.splitContainer1.Panel2.Controls.Add(this.txtStereotype);
            this.splitContainer1.Panel2.Controls.Add(this.lblSteroetype);
            this.splitContainer1.Panel2.Controls.Add(this.txtVersion);
            this.splitContainer1.Panel2.Controls.Add(this.lblVersion);
            this.splitContainer1.Panel2.Controls.Add(this.txtAuthor);
            this.splitContainer1.Panel2.Controls.Add(this.lblAuthor);
            this.splitContainer1.Panel2.Controls.Add(this.txtAlias);
            this.splitContainer1.Panel2.Controls.Add(this.lblAlias);
            this.splitContainer1.Panel2.Controls.Add(this.htmlNotes);
            this.splitContainer1.Panel2.Controls.Add(this.txtIdentifier);
            this.splitContainer1.Panel2.Controls.Add(this.txtHeading);
            this.splitContainer1.Panel2.Controls.Add(this.lblNotes);
            this.splitContainer1.Panel2.Controls.Add(this.lblIdentifier);
            this.splitContainer1.Panel2.Controls.Add(this.lblHeading);
            this.splitContainer1.Size = new System.Drawing.Size(540, 648);
            this.splitContainer1.SplitterDistance = 244;
            this.splitContainer1.TabIndex = 2;
            // 
            // treXmiStructure
            // 
            this.treXmiStructure.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treXmiStructure.ImageIndex = 0;
            this.treXmiStructure.ImageList = this.imgIcons;
            this.treXmiStructure.Location = new System.Drawing.Point(3, 3);
            this.treXmiStructure.Name = "treXmiStructure";
            this.treXmiStructure.SelectedImageIndex = 0;
            this.treXmiStructure.Size = new System.Drawing.Size(534, 238);
            this.treXmiStructure.TabIndex = 2;
            this.treXmiStructure.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treXmiStructure_AfterSelect);
            // 
            // imgIcons
            // 
            this.imgIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgIcons.ImageStream")));
            this.imgIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imgIcons.Images.SetKeyName(0, "Model");
            this.imgIcons.Images.SetKeyName(1, "Requirement");
            this.imgIcons.Images.SetKeyName(2, "Specification");
            this.imgIcons.Images.SetKeyName(3, "RequirementApproved");
            this.imgIcons.Images.SetKeyName(4, "RequirementImplemented");
            this.imgIcons.Images.SetKeyName(5, "RequirementMandatory");
            this.imgIcons.Images.SetKeyName(6, "RequirementProposed");
            this.imgIcons.Images.SetKeyName(7, "RequirementValidated");
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Window;
            this.txtStatus.Location = new System.Drawing.Point(344, 101);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(193, 20);
            this.txtStatus.TabIndex = 15;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(294, 104);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(43, 13);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Status: ";
            // 
            // txtStereotype
            // 
            this.txtStereotype.BackColor = System.Drawing.SystemColors.Window;
            this.txtStereotype.Location = new System.Drawing.Point(83, 101);
            this.txtStereotype.Name = "txtStereotype";
            this.txtStereotype.ReadOnly = true;
            this.txtStereotype.Size = new System.Drawing.Size(193, 20);
            this.txtStereotype.TabIndex = 13;
            // 
            // lblSteroetype
            // 
            this.lblSteroetype.AutoSize = true;
            this.lblSteroetype.Location = new System.Drawing.Point(13, 104);
            this.lblSteroetype.Name = "lblSteroetype";
            this.lblSteroetype.Size = new System.Drawing.Size(64, 13);
            this.lblSteroetype.TabIndex = 12;
            this.lblSteroetype.Text = "Stereotype: ";
            // 
            // txtVersion
            // 
            this.txtVersion.BackColor = System.Drawing.SystemColors.Window;
            this.txtVersion.Location = new System.Drawing.Point(344, 75);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            this.txtVersion.Size = new System.Drawing.Size(193, 20);
            this.txtVersion.TabIndex = 11;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(294, 78);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(48, 13);
            this.lblVersion.TabIndex = 10;
            this.lblVersion.Text = "Version: ";
            // 
            // txtAuthor
            // 
            this.txtAuthor.BackColor = System.Drawing.SystemColors.Window;
            this.txtAuthor.Location = new System.Drawing.Point(83, 75);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.ReadOnly = true;
            this.txtAuthor.Size = new System.Drawing.Size(193, 20);
            this.txtAuthor.TabIndex = 9;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(33, 78);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(44, 13);
            this.lblAuthor.TabIndex = 8;
            this.lblAuthor.Text = "Author: ";
            // 
            // txtAlias
            // 
            this.txtAlias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlias.BackColor = System.Drawing.SystemColors.Window;
            this.txtAlias.Location = new System.Drawing.Point(83, 49);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.ReadOnly = true;
            this.txtAlias.Size = new System.Drawing.Size(454, 20);
            this.txtAlias.TabIndex = 7;
            // 
            // lblAlias
            // 
            this.lblAlias.AutoSize = true;
            this.lblAlias.Location = new System.Drawing.Point(42, 52);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(35, 13);
            this.lblAlias.TabIndex = 6;
            this.lblAlias.Text = "Alias: ";
            // 
            // htmlNotes
            // 
            this.htmlNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.htmlNotes.AutoScroll = true;
            this.htmlNotes.BackColor = System.Drawing.SystemColors.Window;
            this.htmlNotes.BaseStylesheet = null;
            this.htmlNotes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.htmlNotes.Location = new System.Drawing.Point(83, 127);
            this.htmlNotes.Name = "htmlNotes";
            this.htmlNotes.Size = new System.Drawing.Size(454, 270);
            this.htmlNotes.TabIndex = 5;
            this.htmlNotes.Text = null;
            this.htmlNotes.UseSystemCursors = true;
            // 
            // txtIdentifier
            // 
            this.txtIdentifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdentifier.BackColor = System.Drawing.SystemColors.Window;
            this.txtIdentifier.Location = new System.Drawing.Point(83, 23);
            this.txtIdentifier.Name = "txtIdentifier";
            this.txtIdentifier.ReadOnly = true;
            this.txtIdentifier.Size = new System.Drawing.Size(454, 20);
            this.txtIdentifier.TabIndex = 4;
            // 
            // txtHeading
            // 
            this.txtHeading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeading.BackColor = System.Drawing.SystemColors.Window;
            this.txtHeading.Location = new System.Drawing.Point(83, -3);
            this.txtHeading.Name = "txtHeading";
            this.txtHeading.ReadOnly = true;
            this.txtHeading.Size = new System.Drawing.Size(454, 20);
            this.txtHeading.TabIndex = 3;
            // 
            // lblNotes
            // 
            this.lblNotes.Location = new System.Drawing.Point(24, 127);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(53, 16);
            this.lblNotes.TabIndex = 2;
            this.lblNotes.Text = "Notes: ";
            this.lblNotes.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblIdentifier
            // 
            this.lblIdentifier.Location = new System.Drawing.Point(21, 26);
            this.lblIdentifier.Name = "lblIdentifier";
            this.lblIdentifier.Size = new System.Drawing.Size(56, 17);
            this.lblIdentifier.TabIndex = 1;
            this.lblIdentifier.Text = "Identifier: ";
            this.lblIdentifier.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblHeading
            // 
            this.lblHeading.Location = new System.Drawing.Point(12, 0);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(65, 17);
            this.lblHeading.TabIndex = 0;
            this.lblHeading.Text = "Heading: ";
            this.lblHeading.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmEAExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 672);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mnuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuStrip;
            this.MinimumSize = new System.Drawing.Size(320, 240);
            this.Name = "frmEAExport";
            this.Text = "EA XMI Export Tool";
            this.mnuStrip.ResumeLayout(false);
            this.mnuStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpenXmi;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExportCsv;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treXmiStructure;
        private System.Windows.Forms.TextBox txtIdentifier;
        private System.Windows.Forms.TextBox txtHeading;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblIdentifier;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.ImageList imgIcons;
        private System.Windows.Forms.ToolStripSeparator mnuDash1;
        private TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel htmlNotes;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.Label lblAlias;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStereotype;
        private System.Windows.Forms.Label lblSteroetype;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuEditSearch;
        private System.Windows.Forms.ToolStripMenuItem mnuEditSearchAlias;
    }
}

