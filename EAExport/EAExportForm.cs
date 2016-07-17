using System;
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

            int nodes = BuildTree(null, eaModel.Root);

            lblElementCount.Text = string.Format("Nodes: {0}", nodes);
            treXmiStructure.EndUpdate();
        }

        private int BuildTree(TreeNode parent, Model.EATree element)
        {
            int nodes = 0;
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
            nodes++;

            if (element.Id.StartsWith("MX_EAID_")) {
                node.ImageKey = "Model";
            } else if (element.Id.StartsWith("EAPK")) {
                node.ImageKey = "Specification";
            } else {
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
            }
            node.SelectedImageKey = node.ImageKey;

            foreach (Model.EATree child in element.Children) {
                nodes += BuildTree(node, child);
            }
            return nodes;
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
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.CheckPathExists = true;
            saveDialog.DefaultExt = defaultExtension;
            saveDialog.Filter = filter;
            saveDialog.Title = title;
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
                Model.EATree element = node.Tag as Model.EATree;
                if (element != null) {
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
