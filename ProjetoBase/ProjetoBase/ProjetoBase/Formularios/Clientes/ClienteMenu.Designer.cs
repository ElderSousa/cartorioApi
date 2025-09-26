namespace ProjetoBase.Formularios.Clientes
{
    partial class ClienteMenu
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
            this.pnlAcoes = new System.Windows.Forms.Panel();
            this.btnExcluir = new ProjetoBase.CustomControls.BotaoCC();
            this.btnAlterar = new ProjetoBase.CustomControls.BotaoCC();
            this.btnNovo = new ProjetoBase.CustomControls.BotaoCC();
            this.dgvClientes = new ProjetoBase.CustomControls.Input.DataGridViewCC();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDePessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomePessoaFisica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomePessoaJuridica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNPJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObjetoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlAcoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAcoes
            // 
            this.pnlAcoes.Controls.Add(this.btnExcluir);
            this.pnlAcoes.Controls.Add(this.btnAlterar);
            this.pnlAcoes.Controls.Add(this.btnNovo);
            this.pnlAcoes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAcoes.Location = new System.Drawing.Point(0, 0);
            this.pnlAcoes.Name = "pnlAcoes";
            this.pnlAcoes.Size = new System.Drawing.Size(800, 40);
            this.pnlAcoes.TabIndex = 1;
            // 
            // btnExcluir
            // 
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnExcluir.Location = new System.Drawing.Point(199, 7);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.NivelDeAcesso = null;
            this.btnExcluir.Size = new System.Drawing.Size(91, 25);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.TipoBotao = ProjetoBase.Enumeradores.TipoBotao.Default;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlterar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnAlterar.Location = new System.Drawing.Point(107, 7);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.NivelDeAcesso = null;
            this.btnAlterar.Size = new System.Drawing.Size(86, 25);
            this.btnAlterar.TabIndex = 1;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.TipoBotao = ProjetoBase.Enumeradores.TipoBotao.Default;
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnNovo.Location = new System.Drawing.Point(12, 7);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.NivelDeAcesso = null;
            this.btnNovo.Size = new System.Drawing.Size(89, 25);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Text = "Novo";
            this.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNovo.TipoBotao = ProjetoBase.Enumeradores.TipoBotao.Default;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // dgvClientes
            // 
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TipoDePessoa,
            this.NomePessoaFisica,
            this.CPF,
            this.NomePessoaJuridica,
            this.CNPJ,
            this.Email,
            this.colObjetoCliente});
            this.dgvClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClientes.Location = new System.Drawing.Point(0, 40);
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.NomeDisplay = null;
            this.dgvClientes.Obrigatorio = false;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(800, 410);
            this.dgvClientes.SomenteLeitura = false;
            this.dgvClientes.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // TipoDePessoa
            // 
            this.TipoDePessoa.DataPropertyName = "TipoDePessoa";
            this.TipoDePessoa.HeaderText = "TipoDePessoa";
            this.TipoDePessoa.Name = "TipoDePessoa";
            // 
            // NomePessoaFisica
            // 
            this.NomePessoaFisica.DataPropertyName = "NomePessoaFisica";
            this.NomePessoaFisica.HeaderText = "NomePessoaFisica";
            this.NomePessoaFisica.Name = "NomePessoaFisica";
            // 
            // CPF
            // 
            this.CPF.DataPropertyName = "CPF";
            this.CPF.HeaderText = "CPF";
            this.CPF.Name = "CPF";
            // 
            // NomePessoaJuridica
            // 
            this.NomePessoaJuridica.DataPropertyName = "NomePessoaJuridica";
            this.NomePessoaJuridica.HeaderText = "NomePessoaJuridica";
            this.NomePessoaJuridica.Name = "NomePessoaJuridica";
            // 
            // CNPJ
            // 
            this.CNPJ.DataPropertyName = "CNPJ";
            this.CNPJ.HeaderText = "CNPJ";
            this.CNPJ.Name = "CNPJ";
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // colObjetoCliente
            // 
            this.colObjetoCliente.DataPropertyName = "ObjetoCliente";
            this.colObjetoCliente.HeaderText = "ObjetoCliente";
            this.colObjetoCliente.Name = "colObjetoCliente";
            // 
            // ClienteMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.pnlAcoes);
            this.Name = "ClienteMenu";
            this.Text = "ClienteMenu";
            this.Load += new System.EventHandler(this.ClienteMenu_Load);
            this.pnlAcoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.Input.DataGridViewCC dgvClientes;
        private System.Windows.Forms.Panel pnlAcoes;
        private CustomControls.BotaoCC btnExcluir;
        private CustomControls.BotaoCC btnAlterar;
        private CustomControls.BotaoCC btnNovo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDePessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomePessoaFisica;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPF;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomePessoaJuridica;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNPJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObjetoCliente;
    }
}