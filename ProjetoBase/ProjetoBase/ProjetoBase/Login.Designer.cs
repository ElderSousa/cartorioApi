namespace ProjetoBase
{
    partial class Login
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
            this.btn_logar = new ProjetoBase.CustomControls.BotaoCC();
            this.SuspendLayout();
            // 
            // btn_logar
            // 
            this.btn_logar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_logar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btn_logar.ForeColor = System.Drawing.Color.OrangeRed;
            this.btn_logar.Location = new System.Drawing.Point(83, 99);
            this.btn_logar.Name = "btn_logar";
            this.btn_logar.NivelDeAcesso = null;
            this.btn_logar.Size = new System.Drawing.Size(120, 35);
            this.btn_logar.TabIndex = 0;
            this.btn_logar.Text = "LOGIN";
            this.btn_logar.TipoBotao = ProjetoBase.Enumeradores.TipoBotao.BotaoGenerico;
            this.btn_logar.UseVisualStyleBackColor = true;
            this.btn_logar.Click += new System.EventHandler(this.btn_logar_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 254);
            this.Controls.Add(this.btn_logar);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ProjetoBase.CustomControls.BotaoCC btn_logar;
    }
}