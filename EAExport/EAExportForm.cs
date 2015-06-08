﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EAExport
{
    public partial class frmEAExport : Form
    {
        private Model.EAModel eaModel;

        public frmEAExport()
        {
            InitializeComponent();
            Text = Text + " (version " + typeof(frmEAExport).Assembly.GetName().Version + ")";
        }

        private int m_FormWidthOnLoad;
        private int m_Text1WidthOnLoad;
        private int m_Text2WidthOnLoad;
        private int m_Text2LeftOnLoad;
        private int m_Label2LeftOnLoad;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            m_FormWidthOnLoad = Width;
            m_Text1WidthOnLoad = txtAuthor.Width;
            m_Text2WidthOnLoad = txtVersion.Width;
            m_Text2LeftOnLoad = txtVersion.Left;
            m_Label2LeftOnLoad = lblVersion.Left;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (m_FormWidthOnLoad == 0) return;

            int newWidth = Width;

            txtAuthor.Width = m_Text1WidthOnLoad + (newWidth - m_FormWidthOnLoad) / 2;
            txtStereotype.Width = m_Text1WidthOnLoad + (newWidth - m_FormWidthOnLoad) / 2;
            txtVersion.Width = m_Text2WidthOnLoad + (newWidth - m_FormWidthOnLoad) / 2;
            txtVersion.Left = m_Text2LeftOnLoad + (newWidth - m_FormWidthOnLoad) / 2;
            txtStatus.Width = m_Text2WidthOnLoad + (newWidth - m_FormWidthOnLoad) / 2;
            txtStatus.Left = m_Text2LeftOnLoad + (newWidth - m_FormWidthOnLoad) / 2;
            lblVersion.Left = m_Label2LeftOnLoad + (newWidth - m_FormWidthOnLoad) / 2;
            lblStatus.Left = m_Label2LeftOnLoad + (newWidth - m_FormWidthOnLoad) / 2;
        }

        private void mnuFileOpenXmi_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.CheckFileExists = true;
            openDialog.CheckPathExists = true;
            openDialog.DefaultExt = "xml";
            openDialog.Filter = "XMI (*.xml)|*.xml";
            openDialog.Multiselect = false;
            openDialog.ShowReadOnly = true;
            openDialog.ReadOnlyChecked = true;
            openDialog.Title = "Open XMI File";
            openDialog.ShowDialog();
            string fileName = openDialog.FileName;
            if (string.IsNullOrWhiteSpace(fileName)) return;

            try {
                Model.EAModel loadModel = Model.EAModel.LoadXmi(fileName);
                mnuFileExportCsv.Enabled = true;
                eaModel = loadModel;
                BuildTree();
            } catch (System.Exception exception) {
                EATrace.XmiImport(System.Diagnostics.TraceEventType.Warning, "EAExport Load Failure: {0}", exception.Message);
                MessageBox.Show(exception.Message, "EAExport Load Failure");
            }
        }

        private void BuildTree()
        {
            treXmiStructure.BeginUpdate();
            treXmiStructure.Nodes.Clear();

            BuildTree(null, eaModel.Root);

            treXmiStructure.EndUpdate();
        }

        private void BuildTree(TreeNode parent, Model.EATree element)
        {
            TreeNode node;

            StringBuilder heading = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(element.Stereotype)) {
                heading.Append("«").Append(element.Stereotype).Append("» ");
            }
            heading.Append(element.Heading);
            if (!string.IsNullOrWhiteSpace(element.Alias)) {
                heading.Append(" (").Append(element.Alias).Append(")");
            }

            node = new TreeNode(heading.ToString());
            node.Tag = element;
            if (parent == null) {
                treXmiStructure.Nodes.Add(node);
            } else {
                parent.Nodes.Add(node);
            }

            if (element.Id.StartsWith("MX_EAID_")) {
                node.ImageKey = "Model";
                node.SelectedImageKey = "Model";
            } else if (element.Id.StartsWith("EAPK")) {
                node.ImageKey = "Specification";
                node.SelectedImageKey = "Specification";
            } else {
                node.ImageKey = "Requirement";
                node.SelectedImageKey = "Requirement";
            }

            foreach (Model.EATree child in element.Children) {
                BuildTree(node, child);
            }
        }

        private void treXmiStructure_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Model.EATree element = e.Node.Tag as Model.EATree;
            if (element == null) return;

            txtHeading.Text = element.Heading;
            txtIdentifier.Text = element.Id;
            htmlNotes.Text = element.Text;
            txtAlias.Text = element.Alias;
            txtAuthor.Text = element.Author;
            txtStatus.Text = element.Status;
            txtStereotype.Text = element.Stereotype;
            txtVersion.Text = element.Version;
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuFileExportCsv_Click(object sender, EventArgs e)
        {
            Model.EATree element;
            if (treXmiStructure.SelectedNode == null) {
                element = eaModel.Root;
            } else {
                element = treXmiStructure.SelectedNode.Tag as Model.EATree;
            }
            if (element == null) return;

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.CheckPathExists = true;
            saveDialog.DefaultExt = "csv";
            saveDialog.Filter = "CSV (*.csv)|*.csv";
            saveDialog.Title = "Save CSV File";
            saveDialog.ShowDialog();
            string fileName = saveDialog.FileName;
            if (string.IsNullOrWhiteSpace(fileName)) return;

            try {
                using (Model.ITreeExport exportFormat = new Model.CsvDoorsTreeExport(fileName)) {
                    exportFormat.ExportTree(element, false);
                }
            } catch (System.Exception exception) {
                EATrace.XmiImport(System.Diagnostics.TraceEventType.Warning, "EAExport CSV Export Failure: {0}", exception.Message);
                MessageBox.Show(exception.Message, "EAExport CSV Export Failure");
            }
        }
    }
}
