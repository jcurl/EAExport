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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treXmiStructure = new System.Windows.Forms.TreeView();
            this.imgIcons = new System.Windows.Forms.ImageList(this.components);
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtIdentifier = new System.Windows.Forms.TextBox();
            this.txtHeading = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblIdentifier = new System.Windows.Forms.Label();
            this.lblHeading = new System.Windows.Forms.Label();
            this.mnuDash1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileOpenXmi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExportCsv = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
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
            this.mnuFile});
            this.mnuStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuStrip.Name = "mnuStrip";
            this.mnuStrip.Size = new System.Drawing.Size(654, 24);
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
            this.splitContainer1.Panel2.Controls.Add(this.txtNotes);
            this.splitContainer1.Panel2.Controls.Add(this.txtIdentifier);
            this.splitContainer1.Panel2.Controls.Add(this.txtHeading);
            this.splitContainer1.Panel2.Controls.Add(this.lblNotes);
            this.splitContainer1.Panel2.Controls.Add(this.lblIdentifier);
            this.splitContainer1.Panel2.Controls.Add(this.lblHeading);
            this.splitContainer1.Size = new System.Drawing.Size(654, 403);
            this.splitContainer1.SplitterDistance = 193;
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
            this.treXmiStructure.Size = new System.Drawing.Size(648, 187);
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
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(83, 49);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(568, 154);
            this.txtNotes.TabIndex = 5;
            // 
            // txtIdentifier
            // 
            this.txtIdentifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdentifier.Location = new System.Drawing.Point(83, 23);
            this.txtIdentifier.Name = "txtIdentifier";
            this.txtIdentifier.Size = new System.Drawing.Size(568, 20);
            this.txtIdentifier.TabIndex = 4;
            // 
            // txtHeading
            // 
            this.txtHeading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeading.Location = new System.Drawing.Point(83, -3);
            this.txtHeading.Name = "txtHeading";
            this.txtHeading.Size = new System.Drawing.Size(568, 20);
            this.txtHeading.TabIndex = 3;
            // 
            // lblNotes
            // 
            this.lblNotes.Location = new System.Drawing.Point(24, 49);
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
            // mnuDash1
            // 
            this.mnuDash1.Name = "mnuDash1";
            this.mnuDash1.Size = new System.Drawing.Size(200, 6);
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
            // mnuFileExit
            // 
            this.mnuFileExit.Image = global::EAExport.Properties.Resources.Exit;
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mnuFileExit.Size = new System.Drawing.Size(203, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // frmEAExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 427);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mnuStrip);
            this.MainMenuStrip = this.mnuStrip;
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
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.TextBox txtIdentifier;
        private System.Windows.Forms.TextBox txtHeading;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblIdentifier;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.ImageList imgIcons;
        private System.Windows.Forms.ToolStripSeparator mnuDash1;
    }
}

