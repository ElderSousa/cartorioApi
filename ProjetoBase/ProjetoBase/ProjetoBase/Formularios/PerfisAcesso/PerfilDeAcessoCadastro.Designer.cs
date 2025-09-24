namespace ProjetoBase.Formularios.PerfisAcesso
{
    partial class PerfilDeAcessoCadastro
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clbNiveisAcesso = new System.Windows.Forms.CheckedListBox();
            this.btnSalvar = new ProjetoBase.CustomControls.BotaoCC();
            this.btnCancelar = new ProjetoBase.CustomControls.BotaoCC();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome do Perfil:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(97, 30);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(100, 20);
            this.txtNome.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Permissões (Níveis de Acesso):";
            // 
            // clbNiveisAcesso
            // 
            this.clbNiveisAcesso.FormattingEnabled = true;
            this.clbNiveisAcesso.Location = new System.Drawing.Point(174, 64);
            this.clbNiveisAcesso.Name = "clbNiveisAcesso";
            this.clbNiveisAcesso.Size = new System.Drawing.Size(197, 19);
            this.clbNiveisAcesso.TabIndex = 3;
            // 
            // btnSalvar
            // 
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnSalvar.Location = new System.Drawing.Point(12, 90);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.NivelDeAcesso = null;
            this.btnSalvar.Size = new System.Drawing.Size(91, 25);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TipoBotao = ProjetoBase.Enumeradores.TipoBotao.Default;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.Location = new System.Drawing.Point(109, 90);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.NivelDeAcesso = null;
            this.btnCancelar.Size = new System.Drawing.Size(88, 25);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TipoBotao = ProjetoBase.Enumeradores.TipoBotao.Default;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // PerfilDeAcessoCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.clbNiveisAcesso);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label1);
            this.Name = "PerfilDeAcessoCadastro";
            this.Text = "PerfilDeAcessoCadastro";
            this.Load += new System.EventHandler(this.PerfilDeAcessoCadastro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox clbNiveisAcesso;
        private CustomControls.BotaoCC btnSalvar;
        private CustomControls.BotaoCC btnCancelar;
    }
}