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

            node = new TreeNode(element.Heading);
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
