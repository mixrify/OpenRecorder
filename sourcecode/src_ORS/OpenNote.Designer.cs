
namespace OpenRecorder_Studio
{
    partial class OpenNote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenNote));
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UndoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tbNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.MenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.FormatToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(872, 25);
            this.MenuStrip1.TabIndex = 3;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Font = new System.Drawing.Font("Corbel", 10F);
            this.FileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(40, 21);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // NewToolStripMenuItem
            // 
            this.NewToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.NewToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            this.NewToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.NewToolStripMenuItem.Text = "New";
            this.NewToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.OpenToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.OpenToolStripMenuItem.Text = "Open";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.SaveToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.SaveToolStripMenuItem.Text = "Save";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ExitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UndoToolStripMenuItem,
            this.CutToolStripMenuItem,
            this.PasteToolStripMenuItem,
            this.SelectAllToolStripMenuItem});
            this.EditToolStripMenuItem.Font = new System.Drawing.Font("Corbel", 10F);
            this.EditToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.EditToolStripMenuItem.Text = "Edit";
            // 
            // UndoToolStripMenuItem
            // 
            this.UndoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.UndoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem";
            this.UndoToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.UndoToolStripMenuItem.Text = "Undo";
            this.UndoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
            // 
            // CutToolStripMenuItem
            // 
            this.CutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.CutToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.CutToolStripMenuItem.Name = "CutToolStripMenuItem";
            this.CutToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.CutToolStripMenuItem.Text = "Cut";
            this.CutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
            // 
            // PasteToolStripMenuItem
            // 
            this.PasteToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.PasteToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            this.PasteToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.PasteToolStripMenuItem.Text = "Paste";
            this.PasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // SelectAllToolStripMenuItem
            // 
            this.SelectAllToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.SelectAllToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem";
            this.SelectAllToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.SelectAllToolStripMenuItem.Text = "Select All";
            this.SelectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItem_Click);
            // 
            // FormatToolStripMenuItem
            // 
            this.FormatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FontToolStripMenuItem});
            this.FormatToolStripMenuItem.Font = new System.Drawing.Font("Corbel", 10F);
            this.FormatToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.FormatToolStripMenuItem.Name = "FormatToolStripMenuItem";
            this.FormatToolStripMenuItem.Size = new System.Drawing.Size(63, 21);
            this.FormatToolStripMenuItem.Text = "Format";
            // 
            // FontToolStripMenuItem
            // 
            this.FontToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.FontToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.FontToolStripMenuItem.Name = "FontToolStripMenuItem";
            this.FontToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.FontToolStripMenuItem.Text = "Font";
            this.FontToolStripMenuItem.Click += new System.EventHandler(this.FontToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Font = new System.Drawing.Font("Corbel", 10F);
            this.clearToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(50, 21);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.Filter = "Text files (*.txt)|";
            // 
            // SaveFileDialog1
            // 
            this.SaveFileDialog1.Filter = "Text file|*.txt";
            // 
            // tbNotes
            // 
            this.tbNotes.Animated = true;
            this.tbNotes.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tbNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbNotes.DefaultText = "";
            this.tbNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNotes.DisabledState.Parent = this.tbNotes;
            this.tbNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNotes.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tbNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNotes.FocusedState.Parent = this.tbNotes;
            this.tbNotes.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNotes.ForeColor = System.Drawing.Color.White;
            this.tbNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNotes.HoverState.Parent = this.tbNotes;
            this.tbNotes.Location = new System.Drawing.Point(0, 25);
            this.tbNotes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.PasswordChar = '\0';
            this.tbNotes.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.tbNotes.PlaceholderText = "Notes here...";
            this.tbNotes.SelectedText = "";
            this.tbNotes.ShadowDecoration.Parent = this.tbNotes;
            this.tbNotes.Size = new System.Drawing.Size(872, 472);
            this.tbNotes.TabIndex = 4;
            // 
            // OpenNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 497);
            this.Controls.Add(this.tbNotes);
            this.Controls.Add(this.MenuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OpenNote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OpenNote - Untitled";
            this.Load += new System.EventHandler(this.OpenNote_Load);
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem NewToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem UndoToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem CutToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem PasteToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem SelectAllToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem FormatToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem FontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        internal System.Windows.Forms.SaveFileDialog SaveFileDialog1;
        private Guna.UI2.WinForms.Guna2TextBox tbNotes;
    }
}