namespace ProjetoBase.Formularios.Clientes
{
    partial class ClienteCadastro
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
            this.cmbTipoCliente = new System.Windows.Forms.ComboBox();
            this.pnlPessoaFisica = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textCPF = new System.Windows.Forms.TextBox();
            this.textNome = new System.Windows.Forms.TextBox();
            this.pnlPessoaJuridica = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textCNPJ = new System.Windows.Forms.TextBox();
            this.textRazaoSocial = new System.Windows.Forms.TextBox();
            this.btnCancelar = new ProjetoBase.CustomControls.BotaoCC();
            this.btnSalvar = new ProjetoBase.CustomControls.BotaoCC();
            this.pnlPessoaFisica.SuspendLayout();
            this.pnlPessoaJuridica.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbTipoCliente
            // 
            this.cmbTipoCliente.FormattingEnabled = true;
            this.cmbTipoCliente.Location = new System.Drawing.Point(12, 2);
            this.cmbTipoCliente.Name = "cmbTipoCliente";
            this.cmbTipoCliente.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoCliente.TabIndex = 0;
            this.cmbTipoCliente.SelectedIndexChanged += new System.EventHandler(this.cmbTipoCliente_SelectedIndexChanged);
            // 
            // pnlPessoaFisica
            // 
            this.pnlPessoaFisica.Controls.Add(this.label2);
            this.pnlPessoaFisica.Controls.Add(this.label1);
            this.pnlPessoaFisica.Controls.Add(this.textCPF);
            this.pnlPessoaFisica.Controls.Add(this.textNome);
            this.pnlPessoaFisica.Location = new System.Drawing.Point(12, 72);
            this.pnlPessoaFisica.Name = "pnlPessoaFisica";
            this.pnlPessoaFisica.Size = new System.Drawing.Size(200, 100);
            this.pnlPessoaFisica.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "CPF";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nome";
            // 
            // textCPF
            // 
            this.textCPF.Location = new System.Drawing.Point(83, 52);
            this.textCPF.Name = "textCPF";
            this.textCPF.Size = new System.Drawing.Size(100, 20);
            this.textCPF.TabIndex = 1;
            // 
            // textNome
            // 
            this.textNome.Location = new System.Drawing.Point(83, 26);
            this.textNome.Name = "textNome";
            this.textNome.Size = new System.Drawing.Size(100, 20);
            this.textNome.TabIndex = 0;
            // 
            // pnlPessoaJuridica
            // 
            this.pnlPessoaJuridica.Controls.Add(this.label4);
            this.pnlPessoaJuridica.Controls.Add(this.label3);
            this.pnlPessoaJuridica.Controls.Add(this.textCNPJ);
            this.pnlPessoaJuridica.Controls.Add(this.textRazaoSocial);
            this.pnlPessoaJuridica.Location = new System.Drawing.Point(12, 197);
            this.pnlPessoaJuridica.Name = "pnlPessoaJuridica";
            this.pnlPessoaJuridica.Size = new System.Drawing.Size(200, 100);
            this.pnlPessoaJuridica.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "CNPJ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Razão Social";
            // 
            // textCNPJ
            // 
            this.textCNPJ.Location = new System.Drawing.Point(83, 58);
            this.textCNPJ.Name = "textCNPJ";
            this.textCNPJ.Size = new System.Drawing.Size(100, 20);
            this.textCNPJ.TabIndex = 1;
            // 
            // textRazaoSocial
            // 
            this.textRazaoSocial.Location = new System.Drawing.Point(83, 32);
            this.textRazaoSocial.Name = "textRazaoSocial";
            this.textRazaoSocial.Size = new System.Drawing.Size(100, 20);
            this.textRazaoSocial.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCancelar.Location = new System.Drawing.Point(138, 348);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.NivelDeAcesso = null;
            this.btnCancelar.Size = new System.Drawing.Size(120, 35);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TipoBotao = ProjetoBase.Enumeradores.TipoBotao.Cancelar;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnSalvar.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnSalvar.Location = new System.Drawing.Point(12, 348);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.NivelDeAcesso = null;
            this.btnSalvar.Size = new System.Drawing.Size(120, 35);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TipoBotao = ProjetoBase.Enumeradores.TipoBotao.Salvar;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // ClienteCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.pnlPessoaJuridica);
            this.Controls.Add(this.pnlPessoaFisica);
            this.Controls.Add(this.cmbTipoCliente);
            this.Name = "ClienteCadastro";
            this.Text = "ClienteCadastro";
            this.Load += new System.EventHandler(this.ClienteCadastro_Load);
            this.pnlPessoaFisica.ResumeLayout(false);
            this.pnlPessoaFisica.PerformLayout();
            this.pnlPessoaJuridica.ResumeLayout(false);
            this.pnlPessoaJuridica.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTipoCliente;
        private System.Windows.Forms.Panel pnlPessoaFisica;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textCPF;
        private System.Windows.Forms.TextBox textNome;
        private System.Windows.Forms.Panel pnlPessoaJuridica;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textCNPJ;
        private System.Windows.Forms.TextBox textRazaoSocial;
        private CustomControls.BotaoCC btnSalvar;
        private CustomControls.BotaoCC btnCancelar;
    }
}