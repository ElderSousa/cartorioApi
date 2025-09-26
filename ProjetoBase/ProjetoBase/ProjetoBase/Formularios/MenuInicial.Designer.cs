namespace ProjetoBase.Formularios
{
    partial class MenuInicial
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
            this.SuspendLayout();
            // 
            // MenuInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 462);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "MenuInicial";
            this.Text = "MenuInicial";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuInicial_FormClosing_1);
            this.Shown += new System.EventHandler(this.MenuInicial_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}