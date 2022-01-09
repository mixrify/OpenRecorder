
namespace OpenRecorder_Studio
{
    partial class OpenPaint
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
            if (disposing && (components != null))
            {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenPaint));
            this.pnPaint = new Guna.UI2.WinForms.Guna2Panel();
            this.pnMenu = new Guna.UI2.WinForms.Guna2Panel();
            this.txtClearAll = new System.Windows.Forms.Label();
            this.pnColors = new Guna.UI2.WinForms.Guna2Panel();
            this.btnBlack = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnGrey = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnPink = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnBlue = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnAqua = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnGreen = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnYellow = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnOrange = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnRed = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.txtTiming = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.existToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnMenu.SuspendLayout();
            this.pnColors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBlack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGrey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAqua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnYellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOrange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRed)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnPaint
            // 
            this.pnPaint.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pnPaint.Location = new System.Drawing.Point(2, 96);
            this.pnPaint.Name = "pnPaint";
            this.pnPaint.ShadowDecoration.Parent = this.pnPaint;
            this.pnPaint.Size = new System.Drawing.Size(869, 430);
            this.pnPaint.TabIndex = 0;
            this.pnPaint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnPaint_MouseDown);
            this.pnPaint.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnPaint_MouseMove);
            this.pnPaint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnPaint_MouseUp);
            // 
            // pnMenu
            // 
            this.pnMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnMenu.Controls.Add(this.txtClearAll);
            this.pnMenu.Controls.Add(this.pnColors);
            this.pnMenu.Controls.Add(this.txtTiming);
            this.pnMenu.Controls.Add(this.menuStrip1);
            this.pnMenu.Location = new System.Drawing.Point(1, -2);
            this.pnMenu.Name = "pnMenu";
            this.pnMenu.ShadowDecoration.Parent = this.pnMenu;
            this.pnMenu.Size = new System.Drawing.Size(870, 98);
            this.pnMenu.TabIndex = 1;
            // 
            // txtClearAll
            // 
            this.txtClearAll.AutoSize = true;
            this.txtClearAll.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtClearAll.Font = new System.Drawing.Font("Ebrima", 13F);
            this.txtClearAll.ForeColor = System.Drawing.Color.Black;
            this.txtClearAll.Location = new System.Drawing.Point(383, 58);
            this.txtClearAll.Name = "txtClearAll";
            this.txtClearAll.Size = new System.Drawing.Size(76, 25);
            this.txtClearAll.TabIndex = 9;
            this.txtClearAll.Text = "Clear All";
            this.txtClearAll.Click += new System.EventHandler(this.txtClearAll_Click);
            // 
            // pnColors
            // 
            this.pnColors.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnColors.BorderColor = System.Drawing.Color.LightGray;
            this.pnColors.BorderRadius = 4;
            this.pnColors.BorderThickness = 1;
            this.pnColors.Controls.Add(this.btnBlack);
            this.pnColors.Controls.Add(this.btnGrey);
            this.pnColors.Controls.Add(this.btnPink);
            this.pnColors.Controls.Add(this.btnBlue);
            this.pnColors.Controls.Add(this.btnAqua);
            this.pnColors.Controls.Add(this.btnGreen);
            this.pnColors.Controls.Add(this.btnYellow);
            this.pnColors.Controls.Add(this.btnOrange);
            this.pnColors.Controls.Add(this.btnRed);
            this.pnColors.FillColor = System.Drawing.Color.LightGray;
            this.pnColors.Location = new System.Drawing.Point(9, 52);
            this.pnColors.Name = "pnColors";
            this.pnColors.ShadowDecoration.Parent = this.pnColors;
            this.pnColors.Size = new System.Drawing.Size(372, 40);
            this.pnColors.TabIndex = 8;
            // 
            // btnBlack
            // 
            this.btnBlack.BackColor = System.Drawing.Color.LightGray;
            this.btnBlack.FillColor = System.Drawing.Color.Black;
            this.btnBlack.ImageRotate = 0F;
            this.btnBlack.Location = new System.Drawing.Point(327, 4);
            this.btnBlack.Name = "btnBlack";
            this.btnBlack.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnBlack.ShadowDecoration.Parent = this.btnBlack;
            this.btnBlack.Size = new System.Drawing.Size(34, 32);
            this.btnBlack.TabIndex = 15;
            this.btnBlack.TabStop = false;
            this.btnBlack.Click += new System.EventHandler(this.btnBlack_Click);
            // 
            // btnGrey
            // 
            this.btnGrey.BackColor = System.Drawing.Color.LightGray;
            this.btnGrey.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGrey.ImageRotate = 0F;
            this.btnGrey.Location = new System.Drawing.Point(287, 4);
            this.btnGrey.Name = "btnGrey";
            this.btnGrey.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnGrey.ShadowDecoration.Parent = this.btnGrey;
            this.btnGrey.Size = new System.Drawing.Size(34, 32);
            this.btnGrey.TabIndex = 14;
            this.btnGrey.TabStop = false;
            this.btnGrey.Click += new System.EventHandler(this.btnGrey_Click);
            // 
            // btnPink
            // 
            this.btnPink.BackColor = System.Drawing.Color.LightGray;
            this.btnPink.FillColor = System.Drawing.Color.Fuchsia;
            this.btnPink.ImageRotate = 0F;
            this.btnPink.Location = new System.Drawing.Point(247, 4);
            this.btnPink.Name = "btnPink";
            this.btnPink.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnPink.ShadowDecoration.Parent = this.btnPink;
            this.btnPink.Size = new System.Drawing.Size(34, 32);
            this.btnPink.TabIndex = 13;
            this.btnPink.TabStop = false;
            this.btnPink.Click += new System.EventHandler(this.btnPink_Click);
            // 
            // btnBlue
            // 
            this.btnBlue.BackColor = System.Drawing.Color.LightGray;
            this.btnBlue.FillColor = System.Drawing.Color.Blue;
            this.btnBlue.ImageRotate = 0F;
            this.btnBlue.Location = new System.Drawing.Point(207, 4);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnBlue.ShadowDecoration.Parent = this.btnBlue;
            this.btnBlue.Size = new System.Drawing.Size(34, 32);
            this.btnBlue.TabIndex = 12;
            this.btnBlue.TabStop = false;
            this.btnBlue.Click += new System.EventHandler(this.btnBlue_Click);
            // 
            // btnAqua
            // 
            this.btnAqua.BackColor = System.Drawing.Color.LightGray;
            this.btnAqua.FillColor = System.Drawing.Color.Aqua;
            this.btnAqua.ImageRotate = 0F;
            this.btnAqua.Location = new System.Drawing.Point(167, 4);
            this.btnAqua.Name = "btnAqua";
            this.btnAqua.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnAqua.ShadowDecoration.Parent = this.btnAqua;
            this.btnAqua.Size = new System.Drawing.Size(34, 32);
            this.btnAqua.TabIndex = 11;
            this.btnAqua.TabStop = false;
            this.btnAqua.Click += new System.EventHandler(this.btnAqua_Click);
            // 
            // btnGreen
            // 
            this.btnGreen.BackColor = System.Drawing.Color.LightGray;
            this.btnGreen.FillColor = System.Drawing.Color.Lime;
            this.btnGreen.ImageRotate = 0F;
            this.btnGreen.Location = new System.Drawing.Point(127, 4);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnGreen.ShadowDecoration.Parent = this.btnGreen;
            this.btnGreen.Size = new System.Drawing.Size(34, 32);
            this.btnGreen.TabIndex = 10;
            this.btnGreen.TabStop = false;
            this.btnGreen.Click += new System.EventHandler(this.btnGreen_Click);
            // 
            // btnYellow
            // 
            this.btnYellow.BackColor = System.Drawing.Color.LightGray;
            this.btnYellow.FillColor = System.Drawing.Color.Yellow;
            this.btnYellow.ImageRotate = 0F;
            this.btnYellow.Location = new System.Drawing.Point(87, 4);
            this.btnYellow.Name = "btnYellow";
            this.btnYellow.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnYellow.ShadowDecoration.Parent = this.btnYellow;
            this.btnYellow.Size = new System.Drawing.Size(34, 32);
            this.btnYellow.TabIndex = 9;
            this.btnYellow.TabStop = false;
            this.btnYellow.Click += new System.EventHandler(this.btnYellow_Click);
            // 
            // btnOrange
            // 
            this.btnOrange.BackColor = System.Drawing.Color.LightGray;
            this.btnOrange.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnOrange.ImageRotate = 0F;
            this.btnOrange.Location = new System.Drawing.Point(47, 4);
            this.btnOrange.Name = "btnOrange";
            this.btnOrange.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnOrange.ShadowDecoration.Parent = this.btnOrange;
            this.btnOrange.Size = new System.Drawing.Size(34, 32);
            this.btnOrange.TabIndex = 8;
            this.btnOrange.TabStop = false;
            this.btnOrange.Click += new System.EventHandler(this.btnOrange_Click);
            // 
            // btnRed
            // 
            this.btnRed.BackColor = System.Drawing.Color.LightGray;
            this.btnRed.FillColor = System.Drawing.Color.Red;
            this.btnRed.ImageRotate = 0F;
            this.btnRed.Location = new System.Drawing.Point(7, 4);
            this.btnRed.Name = "btnRed";
            this.btnRed.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnRed.ShadowDecoration.Parent = this.btnRed;
            this.btnRed.Size = new System.Drawing.Size(34, 32);
            this.btnRed.TabIndex = 7;
            this.btnRed.TabStop = false;
            this.btnRed.Click += new System.EventHandler(this.btnRed_Click);
            // 
            // txtTiming
            // 
            this.txtTiming.AutoSize = true;
            this.txtTiming.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTiming.Font = new System.Drawing.Font("Ebrima", 13F, System.Drawing.FontStyle.Bold);
            this.txtTiming.ForeColor = System.Drawing.Color.Black;
            this.txtTiming.Location = new System.Drawing.Point(4, 25);
            this.txtTiming.Name = "txtTiming";
            this.txtTiming.Size = new System.Drawing.Size(65, 25);
            this.txtTiming.TabIndex = 6;
            this.txtTiming.Text = "Colors";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(870, 25);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveToolStripMenuItem1,
            this.existToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Corbel", 10F);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "New";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // existToolStripMenuItem
            // 
            this.existToolStripMenuItem.Name = "existToolStripMenuItem";
            this.existToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.existToolStripMenuItem.Text = "Exit";
            this.existToolStripMenuItem.Click += new System.EventHandler(this.existToolStripMenuItem_Click);
            // 
            // OpenPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(872, 526);
            this.Controls.Add(this.pnMenu);
            this.Controls.Add(this.pnPaint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "OpenPaint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OpenPaint - Untitled";
            this.pnMenu.ResumeLayout(false);
            this.pnMenu.PerformLayout();
            this.pnColors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnBlack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGrey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAqua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnYellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOrange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRed)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnPaint;
        private Guna.UI2.WinForms.Guna2Panel pnMenu;
        private Guna.UI2.WinForms.Guna2Panel pnColors;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnBlack;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnGrey;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnPink;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnBlue;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnAqua;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnGreen;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnYellow;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnOrange;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnRed;
        public System.Windows.Forms.Label txtTiming;
        public System.Windows.Forms.Label txtClearAll;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem existToolStripMenuItem;
    }
}