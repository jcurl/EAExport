﻿using System;
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
            treXmiStructure.ShowLines = true;
            treXmiStructure.ExplorerStyle = true;

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
            txtCreateTime.Width = m_Text1WidthOnLoad + (newWidth - m_FormWidthOnLoad) / 2;
            txtVersion.Width = m_Text2WidthOnLoad + (newWidth - m_FormWidthOnLoad) / 2;
            txtVersion.Left = m_Text2LeftOnLoad + (newWidth - m_FormWidthOnLoad) / 2;
            txtStatus.Width = m_Text2WidthOnLoad + (newWidth - m_FormWidthOnLoad) / 2;
            txtStatus.Left = m_Text2LeftOnLoad + (newWidth - m_FormWidthOnLoad) / 2;
            txtModifiedTime.Width = m_Text2WidthOnLoad + (newWidth - m_FormWidthOnLoad) / 2;
            txtModifiedTime.Left = m_Text2LeftOnLoad + (newWidth - m_FormWidthOnLoad) / 2;
            lblVersion.Left = m_Label2LeftOnLoad + (newWidth - m_FormWidthOnLoad) / 2;
            lblStatus.Left = m_Label2LeftOnLoad + (newWidth - m_FormWidthOnLoad) / 2;
            lblModifyTime.Left = m_Label2LeftOnLoad + (newWidth - m_FormWidthOnLoad) / 2;
        }

        private void mnuFileOpenXmi_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog {
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "xml",
                Filter = "XMI (*.xml)|*.xml",
                Multiselect = false,
                ShowReadOnly = true,
                ReadOnlyChecked = true,
                Title = "Open XMI File"
            };
            openDialog.ShowDialog();
            string fileName = openDialog.FileName;
            if (string.IsNullOrWhiteSpace(fileName)) return;

            try {
                Model.EAModel loadModel = Model.EAModel.LoadXmi(fileName);
                mnuFileExport.Enabled = true;
                mnuEditSearch.Enabled = true;
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

            TreeStatistics stats = new TreeStatistics();
            BuildTree(null, eaModel.Root, stats);

            lblElementCount.Text = string.Format("Nodes: {0}", stats.Nodes);
            lblMaxAlias.Text = string.Format("Last Alias: {0}", stats.MaxAlias);
            treXmiStructure.EndUpdate();
        }

        private class TreeStatistics
        {
            public int Nodes { get; set; }

            public string MaxAlias { get; set; }
        }

        private void BuildTree(TreeNode parent, Model.EATree element, TreeStatistics statistics)
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

            node = new TreeNode(heading.ToString()) {
                Tag = element
            };
            if (parent == null) {
                treXmiStructure.Nodes.Add(node);
            } else {
                parent.Nodes.Add(node);
            }
            statistics.Nodes++;
            if (string.Compare(element.Alias, statistics.MaxAlias) > 0) {
                statistics.MaxAlias = element.Alias;
            }

            if (element.Id.StartsWith("MX_EAID_")) {
                node.ImageKey = "Model";
            } else if (element.Id.StartsWith("EAPK")) {
                node.ImageKey = "Specification";
            } else if (element.Status != null) {
                if (element.Status.Equals("Approved", StringComparison.InvariantCultureIgnoreCase)) {
                    node.ImageKey = "RequirementApproved";
                } else if (element.Status.Equals("Implemented", StringComparison.InvariantCultureIgnoreCase)) {
                    node.ImageKey = "RequirementImplemented";
                } else if (element.Status.Equals("Mandatory", StringComparison.InvariantCultureIgnoreCase)) {
                    node.ImageKey = "RequirementMandatory";
                } else if (element.Status.Equals("Proposed", StringComparison.InvariantCultureIgnoreCase)) {
                    node.ImageKey = "RequirementProposed";
                } else if (element.Status.Equals("Validated", StringComparison.InvariantCultureIgnoreCase)) {
                    node.ImageKey = "RequirementValidated";
                } else {
                    node.ImageKey = "Requirement";
                }
            } else {
                node.ImageKey = "Requirement";
            }
            node.SelectedImageKey = node.ImageKey;

            foreach (Model.EATree child in element.Children) {
                BuildTree(node, child, statistics);
            }
        }

        private void treXmiStructure_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!(e.Node.Tag is Model.EATree element)) return;

            txtHeading.Text = element.Heading;
            txtIdentifier.Text = element.Id;
            htmlNotes.Text = element.Text;
            txtAlias.Text = element.Alias;
            txtAuthor.Text = element.Author;
            txtStatus.Text = element.Status ?? "";
            txtStereotype.Text = element.Stereotype;
            txtVersion.Text = element.Version;
            txtCreateTime.Text = element.CreateTime.Ticks == 0 ? string.Empty : element.CreateTime.ToString("g");
            txtModifiedTime.Text = element.ModifiedTime.Ticks == 0 ? string.Empty : element.ModifiedTime.ToString("g");
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuFileExportCsv_Click(object sender, EventArgs e)
        {
            Model.EATree element = GetElement();
            if (element == null) return;

            string fileName = GetFileName("csv", "CSV (*.csv)|*.csv", "Save As CSV File");
            if (fileName == null) return;

            try {
                using (Model.ITreeExport exportFormat = new Model.CsvDoorsTreeExport(fileName)) {
                    exportFormat.ExportTree(element, false);
                }
            } catch (System.Exception exception) {
                EATrace.XmiImport(System.Diagnostics.TraceEventType.Warning, "EAExport CSV Export Failure: {0}", exception.Message);
                MessageBox.Show(exception.Message, "EAExport CSV Export Failure");
            }
        }

        private void mnuFileExportCsvPlain_Click(object sender, EventArgs e)
        {
            Model.EATree element = GetElement();
            if (element == null) return;

            string fileName = GetFileName("csv", "CSV (*.csv)|*.csv", "Save As CSV Plain Text File");
            if (fileName == null) return;

            try {
                using (Model.ITreeExport exportFormat = new Model.CsvDoorsTreePlainExport(fileName)) {
                    exportFormat.ExportTree(element, false);
                }
            } catch (System.Exception exception) {
                EATrace.XmiImport(System.Diagnostics.TraceEventType.Warning, "EAExport CSV Export Failure: {0}", exception.Message);
                MessageBox.Show(exception.Message, "EAExport CSV Export Failure");
            }
        }

        private void mnuFileExportDB45Chapters_Click(object sender, EventArgs e)
        {
            Model.EATree element = GetElement();
            if (element == null) return;

            string fileName = GetFileName("xml", "DocBook 4.5 (*.xml)|*.xml", "Save As DocBook 4.5 with Chapters");
            if (fileName == null) return;

            try {
                using (Model.ITreeExport exportFormat = new Model.DocBook45ChapterExport(fileName)) {
                    exportFormat.ExportTree(element, false);
                }
            } catch (System.Exception exception) {
                EATrace.XmiImport(System.Diagnostics.TraceEventType.Warning, "EAExport DocBook 4.5 Chapter Export Failure: {0}", exception.Message);
                MessageBox.Show(exception.Message, "EAExport DocBook 4.5 Chapter Export Failure");
            }
        }

        private Model.EATree GetElement()
        {
            Model.EATree element;
            if (treXmiStructure.SelectedNode == null) {
                element = eaModel.Root;
            } else {
                element = treXmiStructure.SelectedNode.Tag as Model.EATree;
            }
            return element;
        }

        private string GetFileName(string defaultExtension, string filter, string title)
        {
            SaveFileDialog saveDialog = new SaveFileDialog {
                CheckPathExists = true,
                DefaultExt = defaultExtension,
                Filter = filter,
                Title = title
            };
            saveDialog.ShowDialog();
            string fileName = saveDialog.FileName;
            if (string.IsNullOrWhiteSpace(fileName)) return null;
            return fileName;
        }

        private void mnuEditSearchAlias_Click(object sender, EventArgs e)
        {
            string search = frmSearch.Search("Search Alias", this);
            if (search == null) return;

            // Now iterate through the tree
            TreeNode node = SearchTreeAlias(treXmiStructure.Nodes, search);
            if (node == null) {
                MessageBox.Show("Didn't find search term: " + search);
                return;
            }
            treXmiStructure.SelectedNode = node;
            node.EnsureVisible();
        }

        private TreeNode SearchTreeAlias(TreeNodeCollection nodes, string alias)
        {
            foreach (TreeNode node in nodes) {
                if (node.Tag is Model.EATree element) {
                    if (element.Alias != null && element.Alias.Equals(alias, StringComparison.CurrentCultureIgnoreCase)) {
                        return node;
                    }
                    if (node.Nodes.Count > 0) {
                        TreeNode subNode = SearchTreeAlias(node.Nodes, alias);
                        if (subNode != null) return subNode;
                    }
                }
            }
            return null;
        }
    }
}
