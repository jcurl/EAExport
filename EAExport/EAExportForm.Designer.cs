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
            this.mnuFileExport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExportCsv = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExportCsvPlain = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExportDB45Chapters = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDash1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditSearchAlias = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblElementCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.treXmiStructure = new EAExport.Windows.TreeView();
            this.txtModifiedTime = new System.Windows.Forms.TextBox();
            this.lblModifyTime = new System.Windows.Forms.Label();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.lblCreateTime = new System.Windows.Forms.Label();
            this.mnuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuStrip
            // 
            this.mnuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit});
            this.mnuStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuStrip.Name = "mnuStrip";
            this.mnuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mnuStrip.Size = new System.Drawing.Size(476, 24);
            this.mnuStrip.TabIndex = 0;
            this.mnuStrip.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpenXmi,
            this.mnuFileExport,
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
            this.mnuFileOpenXmi.Size = new System.Drawing.Size(170, 22);
            this.mnuFileOpenXmi.Text = "&Open XMI";
            this.mnuFileOpenXmi.Click += new System.EventHandler(this.mnuFileOpenXmi_Click);
            // 
            // mnuFileExport
            // 
            this.mnuFileExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileExportCsv,
            this.mnuFileExportCsvPlain,
            this.mnuFileExportDB45Chapters});
            this.mnuFileExport.Enabled = false;
            this.mnuFileExport.Image = global::EAExport.Properties.Resources.SaveAs;
            this.mnuFileExport.Name = "mnuFileExport";
            this.mnuFileExport.Size = new System.Drawing.Size(170, 22);
            this.mnuFileExport.Text = "&Export";
            // 
            // mnuFileExportCsv
            // 
            this.mnuFileExportCsv.Name = "mnuFileExportCsv";
            this.mnuFileExportCsv.Size = new System.Drawing.Size(232, 22);
            this.mnuFileExportCsv.Text = "As CSV...";
            this.mnuFileExportCsv.Click += new System.EventHandler(this.mnuFileExportCsv_Click);
            // 
            // mnuFileExportCsvPlain
            // 
            this.mnuFileExportCsvPlain.Name = "mnuFileExportCsvPlain";
            this.mnuFileExportCsvPlain.Size = new System.Drawing.Size(232, 22);
            this.mnuFileExportCsvPlain.Text = "As CSV PlainText...";
            this.mnuFileExportCsvPlain.Click += new System.EventHandler(this.mnuFileExportCsvPlain_Click);
            // 
            // mnuFileExportDB45Chapters
            // 
            this.mnuFileExportDB45Chapters.Name = "mnuFileExportDB45Chapters";
            this.mnuFileExportDB45Chapters.Size = new System.Drawing.Size(232, 22);
            this.mnuFileExportDB45Chapters.Text = "As DocBook 4.5 with Chapters";
            this.mnuFileExportDB45Chapters.Click += new System.EventHandler(this.mnuFileExportDB45Chapters_Click);
            // 
            // mnuDash1
            // 
            this.mnuDash1.Name = "mnuDash1";
            this.mnuDash1.Size = new System.Drawing.Size(167, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Image = global::EAExport.Properties.Resources.Exit;
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mnuFileExit.Size = new System.Drawing.Size(170, 22);
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
            this.mnuEditSearch.Size = new System.Drawing.Size(109, 22);
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
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treXmiStructure);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtModifiedTime);
            this.splitContainer1.Panel2.Controls.Add(this.lblModifyTime);
            this.splitContainer1.Panel2.Controls.Add(this.txtCreateTime);
            this.splitContainer1.Panel2.Controls.Add(this.lblCreateTime);
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
            this.splitContainer1.Size = new System.Drawing.Size(476, 592);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
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
            this.txtStatus.Location = new System.Drawing.Point(300, 109);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(4);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(170, 20);
            this.txtStatus.TabIndex = 15;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(257, 112);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Status:";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtStereotype
            // 
            this.txtStereotype.BackColor = System.Drawing.SystemColors.Window;
            this.txtStereotype.Location = new System.Drawing.Point(70, 109);
            this.txtStereotype.Margin = new System.Windows.Forms.Padding(4);
            this.txtStereotype.Name = "txtStereotype";
            this.txtStereotype.ReadOnly = true;
            this.txtStereotype.Size = new System.Drawing.Size(170, 20);
            this.txtStereotype.TabIndex = 13;
            // 
            // lblSteroetype
            // 
            this.lblSteroetype.AutoSize = true;
            this.lblSteroetype.Location = new System.Drawing.Point(5, 112);
            this.lblSteroetype.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSteroetype.Name = "lblSteroetype";
            this.lblSteroetype.Size = new System.Drawing.Size(64, 13);
            this.lblSteroetype.TabIndex = 12;
            this.lblSteroetype.Text = "Stereotype: ";
            this.lblSteroetype.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtVersion
            // 
            this.txtVersion.BackColor = System.Drawing.SystemColors.Window;
            this.txtVersion.Location = new System.Drawing.Point(300, 82);
            this.txtVersion.Margin = new System.Windows.Forms.Padding(4);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            this.txtVersion.Size = new System.Drawing.Size(170, 20);
            this.txtVersion.TabIndex = 11;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(252, 85);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(45, 13);
            this.lblVersion.TabIndex = 10;
            this.lblVersion.Text = "Version:";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtAuthor
            // 
            this.txtAuthor.BackColor = System.Drawing.SystemColors.Window;
            this.txtAuthor.Location = new System.Drawing.Point(70, 82);
            this.txtAuthor.Margin = new System.Windows.Forms.Padding(4);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.ReadOnly = true;
            this.txtAuthor.Size = new System.Drawing.Size(170, 20);
            this.txtAuthor.TabIndex = 9;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(25, 85);
            this.lblAuthor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(44, 13);
            this.lblAuthor.TabIndex = 8;
            this.lblAuthor.Text = "Author: ";
            this.lblAuthor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtAlias
            // 
            this.txtAlias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlias.BackColor = System.Drawing.SystemColors.Window;
            this.txtAlias.Location = new System.Drawing.Point(70, 55);
            this.txtAlias.Margin = new System.Windows.Forms.Padding(4);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.ReadOnly = true;
            this.txtAlias.Size = new System.Drawing.Size(400, 20);
            this.txtAlias.TabIndex = 7;
            // 
            // lblAlias
            // 
            this.lblAlias.AutoSize = true;
            this.lblAlias.Location = new System.Drawing.Point(34, 58);
            this.lblAlias.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(35, 13);
            this.lblAlias.TabIndex = 6;
            this.lblAlias.Text = "Alias: ";
            this.lblAlias.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.htmlNotes.Location = new System.Drawing.Point(70, 163);
            this.htmlNotes.Margin = new System.Windows.Forms.Padding(4);
            this.htmlNotes.Name = "htmlNotes";
            this.htmlNotes.Size = new System.Drawing.Size(400, 193);
            this.htmlNotes.TabIndex = 5;
            this.htmlNotes.Text = null;
            this.htmlNotes.UseSystemCursors = true;
            // 
            // txtIdentifier
            // 
            this.txtIdentifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdentifier.BackColor = System.Drawing.SystemColors.Window;
            this.txtIdentifier.Location = new System.Drawing.Point(70, 28);
            this.txtIdentifier.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdentifier.Name = "txtIdentifier";
            this.txtIdentifier.ReadOnly = true;
            this.txtIdentifier.Size = new System.Drawing.Size(400, 20);
            this.txtIdentifier.TabIndex = 4;
            // 
            // txtHeading
            // 
            this.txtHeading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeading.BackColor = System.Drawing.SystemColors.Window;
            this.txtHeading.Location = new System.Drawing.Point(70, 2);
            this.txtHeading.Margin = new System.Windows.Forms.Padding(4);
            this.txtHeading.Name = "txtHeading";
            this.txtHeading.ReadOnly = true;
            this.txtHeading.Size = new System.Drawing.Size(400, 20);
            this.txtHeading.TabIndex = 3;
            // 
            // lblNotes
            // 
            this.lblNotes.Location = new System.Drawing.Point(8, 166);
            this.lblNotes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(61, 20);
            this.lblNotes.TabIndex = 2;
            this.lblNotes.Text = "Notes: ";
            this.lblNotes.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblIdentifier
            // 
            this.lblIdentifier.Location = new System.Drawing.Point(8, 31);
            this.lblIdentifier.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdentifier.Name = "lblIdentifier";
            this.lblIdentifier.Size = new System.Drawing.Size(61, 21);
            this.lblIdentifier.TabIndex = 1;
            this.lblIdentifier.Text = "Identifier: ";
            this.lblIdentifier.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblHeading
            // 
            this.lblHeading.Location = new System.Drawing.Point(8, 5);
            this.lblHeading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(61, 21);
            this.lblHeading.TabIndex = 0;
            this.lblHeading.Text = "Heading: ";
            this.lblHeading.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblElementCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 619);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(476, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblElementCount
            // 
            this.lblElementCount.Name = "lblElementCount";
            this.lblElementCount.Size = new System.Drawing.Size(0, 17);
            // 
            // treXmiStructure
            // 
            this.treXmiStructure.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treXmiStructure.EnableDragDropScrolling = false;
            this.treXmiStructure.ExplorerStyle = false;
            this.treXmiStructure.ImageIndex = 0;
            this.treXmiStructure.ImageList = this.imgIcons;
            this.treXmiStructure.Location = new System.Drawing.Point(4, 4);
            this.treXmiStructure.Margin = new System.Windows.Forms.Padding(4);
            this.treXmiStructure.Name = "treXmiStructure";
            this.treXmiStructure.SelectedImageIndex = 0;
            this.treXmiStructure.ShowLines = false;
            this.treXmiStructure.Size = new System.Drawing.Size(466, 212);
            this.treXmiStructure.TabIndex = 2;
            this.treXmiStructure.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treXmiStructure_AfterSelect);
            // 
            // txtModifiedTime
            // 
            this.txtModifiedTime.BackColor = System.Drawing.SystemColors.Window;
            this.txtModifiedTime.Location = new System.Drawing.Point(300, 135);
            this.txtModifiedTime.Margin = new System.Windows.Forms.Padding(4);
            this.txtModifiedTime.Name = "txtModifiedTime";
            this.txtModifiedTime.ReadOnly = true;
            this.txtModifiedTime.Size = new System.Drawing.Size(170, 20);
            this.txtModifiedTime.TabIndex = 19;
            // 
            // lblModifyTime
            // 
            this.lblModifyTime.AutoSize = true;
            this.lblModifyTime.Location = new System.Drawing.Point(247, 138);
            this.lblModifyTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblModifyTime.Name = "lblModifyTime";
            this.lblModifyTime.Size = new System.Drawing.Size(50, 13);
            this.lblModifyTime.TabIndex = 18;
            this.lblModifyTime.Text = "Modified:";
            this.lblModifyTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.BackColor = System.Drawing.SystemColors.Window;
            this.txtCreateTime.Location = new System.Drawing.Point(70, 135);
            this.txtCreateTime.Margin = new System.Windows.Forms.Padding(4);
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(170, 20);
            this.txtCreateTime.TabIndex = 17;
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.AutoSize = true;
            this.lblCreateTime.Location = new System.Drawing.Point(15, 138);
            this.lblCreateTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(52, 13);
            this.lblCreateTime.TabIndex = 16;
            this.lblCreateTime.Text = "Creation: ";
            this.lblCreateTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmEAExport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(476, 641);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mnuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(421, 285);
            this.Name = "frmEAExport";
            this.Text = "EA XMI Export Tool";
            this.mnuStrip.ResumeLayout(false);
            this.mnuStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpenXmi;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private EAExport.Windows.TreeView treXmiStructure;
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblElementCount;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExport;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExportCsv;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExportCsvPlain;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExportDB45Chapters;
        private System.Windows.Forms.TextBox txtModifiedTime;
        private System.Windows.Forms.Label lblModifyTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.Label lblCreateTime;
    }
}

