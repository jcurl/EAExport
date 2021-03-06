﻿using System;
using System.Windows.Forms;

namespace EAExport
{
    public partial class frmSearch : Form
    {
        private string m_SearchString;

        public frmSearch()
        {
            InitializeComponent();
        }

        public static string Search(string label, IWin32Window parent)
        {
            frmSearch form = new frmSearch();
            form.lblSearch.Text = label;
            form.ShowDialog(parent);
            return form.m_SearchString;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            m_SearchString = txtSearch.Text;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_SearchString = null;
            Close();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27) {
                btnCancel_Click(sender, e);
                e.Handled = true;
            } else if (e.KeyChar == 13) {
                btnSearch_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
