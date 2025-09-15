namespace ProjetoBase.Formularios.Ferramentas
{
    partial class ValidacaoAcao
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
            this.txt_login = new ProjetoBase.CustomControls.TextboxLabelCC();
            this.txt_senha = new ProjetoBase.CustomControls.TextboxLabelCC();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ok = new ProjetoBase.CustomControls.BotaoCC();
            this.btn_sair = new ProjetoBase.CustomControls.BotaoCC();
            this.btn_configurar_autorizacao = new ProjetoBase.CustomControls.BotaoCC();
            this.SuspendLayout();
            // 
            // txt_login
            // 
            this.txt_login.Caixa = System.Windows.Forms.CharacterCasing.Normal;
            this.txt_login.CorLabel = System.Drawing.Color.Black;
            this.txt_login.Location = new System.Drawing.Point(12, 39);
            this.txt_login.MultiLinha = false;
            this.txt_login.Name = "txt_login";
            this.txt_login.NomeDisplay = "Login";
            this.txt_login.Obrigatorio = false;
            this.txt_login.PedirSenhaAlterarSomenteLeitura = true;
            this.txt_login.PermitirAlterarSomenteLeitura = false;
            this.txt_login.PermitirValorNegativo = false;
            this.txt_login.Senha = false;
            this.txt_login.Size = new System.Drawing.Size(184, 38);
            this.txt_login.SomenteLeitura = false;
            this.txt_login.TabIndex = 0;
            this.txt_login.TamanhoMaximo = 255;
            this.txt_login.TamanhoTextBox = ProjetoBase.Enumeradores.EnumTamanhoTextBox.Pequeno;
            this.txt_login.Texto = null;
            this.txt_login.TipoTextBox = ProjetoBase.Enumeradores.TipoTextBox.Texto;
            // 
            // txt_senha
            // 
            this.txt_senha.Caixa = System.Windows.Forms.CharacterCasing.Normal;
            this.txt_senha.CorLabel = System.Drawing.Color.Black;
            this.txt_senha.Location = new System.Drawing.Point(12, 83);
            this.txt_senha.MultiLinha = false;
            this.txt_senha.Name = "txt_senha";
            this.txt_senha.NomeDisplay = "Senha";
            this.txt_senha.Obrigatorio = false;
            this.txt_senha.PedirSenhaAlterarSomenteLeitura = true;
            this.txt_senha.PermitirAlterarSomenteLeitura = false;
            this.txt_senha.PermitirValorNegativo = false;
            this.txt_senha.Senha = true;
            this.txt_senha.Size = new System.Drawing.Size(184, 38);
            this.txt_senha.SomenteLeitura = false;
            this.txt_senha.TabIndex = 1;
            this.txt_senha.TamanhoMaximo = 255;
            this.txt_senha.TamanhoTextBox = ProjetoBase.Enumeradores.EnumTamanhoTextBox.Pequeno;
            this.txt_senha.Texto = null;
            this.txt_senha.TipoTextBox = ProjetoBase.Enumeradores.TipoTextBox.Texto;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "AUTORIZAR";
            // 
            // btn_ok
            // 
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btn_ok.ForeColor = System.Drawing.Color.DarkBlue;
            this.btn_ok.Location = new System.Drawing.Point(114, 130);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.NivelDeAcesso = null;
            this.btn_ok.Size = new System.Drawing.Size(82, 35);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "OK";
            this.btn_ok.TipoBotao = ProjetoBase.Enumeradores.TipoBotao.OK;
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_sair
            // 
            this.btn_sair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sair.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btn_sair.ForeColor = System.Drawing.Color.Black;
            this.btn_sair.Location = new System.Drawing.Point(12, 130);
            this.btn_sair.Name = "btn_sair";
            this.btn_sair.NivelDeAcesso = null;
            this.btn_sair.Size = new System.Drawing.Size(82, 35);
            this.btn_sair.TabIndex = 4;
            this.btn_sair.Text = "Sair";
            this.btn_sair.TipoBotao = ProjetoBase.Enumeradores.TipoBotao.Sair;
            this.btn_sair.UseVisualStyleBackColor = true;
            this.btn_sair.Click += new System.EventHandler(this.btn_sair_Click);
            // 
            // btn_configurar_autorizacao
            // 
            this.btn_configurar_autorizacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_configurar_autorizacao.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_configurar_autorizacao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_configurar_autorizacao.Location = new System.Drawing.Point(12, 174);
            this.btn_configurar_autorizacao.Name = "btn_configurar_autorizacao";
            this.btn_configurar_autorizacao.NivelDeAcesso = null;
            this.btn_configurar_autorizacao.Size = new System.Drawing.Size(184, 29);
            this.btn_configurar_autorizacao.TabIndex = 5;
            this.btn_configurar_autorizacao.Text = "Configurar Autorização";
            this.btn_configurar_autorizacao.TipoBotao = ProjetoBase.Enumeradores.TipoBotao.BotaoGenerico;
            this.btn_configurar_autorizacao.UseVisualStyleBackColor = true;
            this.btn_configurar_autorizacao.Click += new System.EventHandler(this.btn_configurar_autorizacao_Click);
            // 
            // ValidacaoAcao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BotaoEnter = this.btn_ok;
            this.BotaoEscape = this.btn_sair;
            this.ClientSize = new System.Drawing.Size(208, 174);
            this.Controls.Add(this.btn_configurar_autorizacao);
            this.Controls.Add(this.btn_sair);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_senha);
            this.Controls.Add(this.txt_login);
            this.Name = "ValidacaoAcao";
            this.Nome_janela = "Validar Ação";
            this.Text = "ValidacaoAcao";
            this.Load += new System.EventHandler(this.ValidacaoAcao_Load);
            this.Shown += new System.EventHandler(this.ValidacaoAcao_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.TextboxLabelCC txt_login;
        private CustomControls.TextboxLabelCC txt_senha;
        private System.Windows.Forms.Label label1;
        private CustomControls.BotaoCC btn_ok;
        private CustomControls.BotaoCC btn_sair;
        private CustomControls.BotaoCC btn_configurar_autorizacao;
    }
}