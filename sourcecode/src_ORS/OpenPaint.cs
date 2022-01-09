using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenRecorder_Studio
{
    public partial class OpenPaint : Form
    {
        Graphics g;
        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen;
        public OpenPaint()
        {
            InitializeComponent();
            g = pnPaint.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 5);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void pnPaint_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
        }

        private void pnPaint_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;
        }

        private void pnPaint_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && x!=-1 && y != -1)
            {
                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }
        private void btnRed_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen = new Pen(Color.Red, 5);
        }

        private void btnOrange_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen = new Pen(Color.Orange, 5);
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen = new Pen(Color.Yellow, 5);
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen = new Pen(Color.Green, 5);
        }

        private void btnAqua_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen = new Pen(Color.Aqua, 5);
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen = new Pen(Color.Blue, 5);
        }

        private void btnPink_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen = new Pen(Color.Pink, 5);
        }

        private void btnGrey_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen = new Pen(Color.Gray, 5);
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen = new Pen(Color.Black, 5);
        }

        private void txtClearAll_Click(object sender, EventArgs e)
        {   
            pnPaint.Refresh();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnPaint.Refresh();
        }

        private void existToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
