using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OpenRecorder_Studio
{
    public partial class OpenNote : Form
    {
        public OpenNote()
        {
            InitializeComponent();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult d = MessageBox.Show("Are you sure you want to create a new text file? You will lose all info stored.", "New file", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
            {
                tbNotes.Clear();
            }
            else if (d == DialogResult.No)
            {

            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog1.ShowDialog();
            try
            {
                tbNotes.Text = File.ReadAllText(OpenFileDialog1.FileName);
            }
            catch (Exception ex)
            {

            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbNotes.Clear();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog1.ShowDialog();
        try
            {
                File.WriteAllText(SaveFileDialog1.FileName, tbNotes.Text);
            }
        catch (Exception ex) 
            {

            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbNotes.Undo();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbNotes.Cut();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbNotes.Paste();
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbNotes.SelectAll();
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var dlg = new FontDialog();
                dlg.Font = tbNotes.Font;
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    tbNotes.Font = dlg.Font;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void OpenNote_Load(object sender, EventArgs e)
        {

        }
    }
}
