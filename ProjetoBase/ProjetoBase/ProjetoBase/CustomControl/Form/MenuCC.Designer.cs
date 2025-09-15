using ProjetoBase.CustomControls;

namespace ProjetoBase.CustomControl.Form
{
    partial class MenuCC
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
            this.menuStrip1 = new ProjetoBase.CustomControls.MenuStripCC();
            this.cadastroToolStripMenuItem = new ProjetoBase.CustomControls.ToolStripMenuItemCC();
            this.rHToolStripMenuItem = new ProjetoBase.CustomControls.ToolStripMenuItemCC();
            this.cargoToolStripMenuItem = new ProjetoBase.CustomControls.ToolStripMenuItemCC();
            this.backgroundWorkerUpdate = new ProjetoBase.CustomControls.BackgroundWorkerCC();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(46)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(817, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastroToolStripMenuItem
            // 
            this.cadastroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rHToolStripMenuItem});
            this.cadastroToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.cadastroToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
            this.cadastroToolStripMenuItem.NivelDeAcesso = null;
            this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.cadastroToolStripMenuItem.Text = "Cadastro";
            // 
            // rHToolStripMenuItem
            // 
            this.rHToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlText;
            this.rHToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargoToolStripMenuItem});
            this.rHToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.rHToolStripMenuItem.Name = "rHToolStripMenuItem";
            this.rHToolStripMenuItem.NivelDeAcesso = null;
            this.rHToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rHToolStripMenuItem.Text = "RH";
            // 
            // cargoToolStripMenuItem
            // 
            this.cargoToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlText;
            this.cargoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.cargoToolStripMenuItem.Name = "cargoToolStripMenuItem";
            this.cargoToolStripMenuItem.NivelDeAcesso = null;
            this.cargoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cargoToolStripMenuItem.Text = "Cargo";
            this.cargoToolStripMenuItem.Click += new System.EventHandler(this.cargoToolStripMenuItem_Click);
            // 
            // MenuCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(817, 505);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = true;
            this.Name = "MenuCC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuCC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MenuCC_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStripCC menuStrip1;
        private ToolStripMenuItemCC cadastroToolStripMenuItem;
        private ToolStripMenuItemCC rHToolStripMenuItem;
        private ToolStripMenuItemCC cargoToolStripMenuItem;
        public BackgroundWorkerCC backgroundWorkerUpdate;
    }
}