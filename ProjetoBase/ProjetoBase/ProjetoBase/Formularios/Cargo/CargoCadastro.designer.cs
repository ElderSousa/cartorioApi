namespace ProjetoBase.Formularios
{
    partial class CargoCadastro
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageDados = new System.Windows.Forms.TabPage();
            this.panel_cargo = new System.Windows.Forms.Panel();
            this.txt_codigo = new ProjetoBase.CustomControls.TextboxLabelCC();
            this.txt_nome = new ProjetoBase.CustomControls.TextboxLabelCC();
            this.btn_cancelar = new ProjetoBase.CustomControls.BotaoCC();
            this.btn_cadastrar = new ProjetoBase.CustomControls.BotaoCC();
            this.tabControl1.SuspendLayout();
            this.tabPageDados.SuspendLayout();
            this.panel_cargo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageDados);
            this.tabControl1.Location = new System.Drawing.Point(12, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(321, 114);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageDados
            // 
            this.tabPageDados.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageDados.Controls.Add(this.panel_cargo);
            this.tabPageDados.Location = new System.Drawing.Point(4, 22);
            this.tabPageDados.Name = "tabPageDados";
            this.tabPageDados.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDados.Size = new System.Drawing.Size(313, 88);
            this.tabPageDados.TabIndex = 0;
            this.tabPageDados.Text = "Cargo";
            // 
            // panel_cargo
            // 
            this.panel_cargo.Controls.Add(this.txt_codigo);
            this.panel_cargo.Controls.Add(this.txt_nome);
            this.panel_cargo.Location = new System.Drawing.Point(4, 2);
            this.panel_cargo.Name = "panel_cargo";
            this.panel_cargo.Size = new System.Drawing.Size(303, 86);
            this.panel_cargo.TabIndex = 0;
            // 
            // txt_codigo
            // 
            this.txt_codigo.Location = new System.Drawing.Point(3, 3);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.NomeDisplay = "Codigo";
            this.txt_codigo.Obrigatorio = false;
            this.txt_codigo.Senha = false;
            this.txt_codigo.Size = new System.Drawing.Size(129, 35);
            this.txt_codigo.SomenteLeitura = true;
            this.txt_codigo.TabIndex = 0;
            this.txt_codigo.TamanhoTextBox = null;
            this.txt_codigo.Texto = null;
            this.txt_codigo.TipoTextBox = ProjetoBase.Enumeradores.TipoTextBox.Texto;
            // 
            // txt_nome
            // 
            this.txt_nome.Location = new System.Drawing.Point(3, 44);
            this.txt_nome.Name = "txt_nome";
            this.txt_nome.NomeDisplay = "Nome";
            this.txt_nome.Obrigatorio = true;
            this.txt_nome.Senha = false;
            this.txt_nome.Size = new System.Drawing.Size(289, 35);
            this.txt_nome.SomenteLeitura = false;
            this.txt_nome.TabIndex = 3;
            this.txt_nome.TamanhoTextBox = null;
            this.txt_nome.Texto = null;
            this.txt_nome.TipoTextBox = ProjetoBase.Enumeradores.TipoTextBox.Texto;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btn_cancelar.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_cancelar.Location = new System.Drawing.Point(12, 130);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.NivelDeAcesso = null;
            this.btn_cancelar.Size = new System.Drawing.Size(120, 35);
            this.btn_cancelar.TabIndex = 2;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.TipoBotao = ProjetoBase.Enumeradores.TipoBotao.Cancelar;
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_cadastrar
            // 
            this.btn_cadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadastrar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btn_cadastrar.ForeColor = System.Drawing.Color.Blue;
            this.btn_cadastrar.Location = new System.Drawing.Point(212, 130);
            this.btn_cadastrar.Name = "btn_cadastrar";
            this.btn_cadastrar.NivelDeAcesso = null;
            this.btn_cadastrar.Size = new System.Drawing.Size(120, 35);
            this.btn_cadastrar.TabIndex = 1;
            this.btn_cadastrar.Text = "Cadastrar";
            this.btn_cadastrar.TipoBotao = ProjetoBase.Enumeradores.TipoBotao.Cadastrar;
            this.btn_cadastrar.UseVisualStyleBackColor = true;
            this.btn_cadastrar.Click += new System.EventHandler(this.btn_cadastrar_Click);
            // 
            // CargoCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BotaoEnter = this.btn_cadastrar;
            this.BotaoEscape = this.btn_cancelar;
            this.ClientSize = new System.Drawing.Size(342, 174);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_cadastrar);
            this.Controls.Add(this.tabControl1);
            this.Name = "CargoCadastro";
            this.Nome_janela = "Cargo";
            this.Text = "Cargo";
            this.Load += new System.EventHandler(this.PessoaNovo_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageDados.ResumeLayout(false);
            this.panel_cargo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageDados;
        private CustomControls.TextboxLabelCC txt_codigo;
        private CustomControls.BotaoCC btn_cadastrar;
        private CustomControls.BotaoCC btn_cancelar;
        private System.Windows.Forms.Panel panel_cargo;
        private CustomControls.TextboxLabelCC txt_nome;



    }
}