using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Notatnik
{
    public partial class frmNotatnik : Form
    {
        string plik = "";

        public frmNotatnik()
        {
            InitializeComponent();
        }

        private DialogResult czyzapisac()
        {
            DialogResult odp = MessageBox.Show("Chcesz zapisaæ zmiany?", "Notatnik",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            if (odp == DialogResult.Yes)
                zapiszToolStripMenuItem_Click(null, null);
            return odp;
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtTresc.Text != "")
            {
                DialogResult odp = czyzapisac();
                if (odp == DialogResult.Cancel)
                    return;
                plik = "";
                txtTresc.Clear();
            }
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Plik tekstowy (*.txt)|*.txt";
            dialog.Multiselect = false;
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                plik = dialog.FileName;
                StreamReader f = new StreamReader(plik);
                txtTresc.Text = f.ReadToEnd();
                f.Close();
            }
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (plik != "")
            {
                StreamWriter f = new StreamWriter(plik);
                f.Write(txtTresc.Text);
                f.Close();
            }
            else zapiszJakoToolStripMenuItem_Click(sender, e);
        }

        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Plik tekstowy (*.txt)|*.txt";
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                plik = dialog.FileName;
                StreamWriter f = new StreamWriter(plik);
                f.Write(txtTresc.Text);
                f.Close();
            }
        }

        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtTresc.Text != "")
            {
                DialogResult odp = czyzapisac();
                if (odp == DialogResult.Cancel)
                    return;
                plik = "";
                txtTresc.Clear();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtTresc.Text != "")
            {
                DialogResult odp = czyzapisac();
                if (odp == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }
    }
}