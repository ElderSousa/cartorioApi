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
            this.dgvClientes = new ProjetoBase.CustomControls.Input.DataGridViewCC();
            this.btnExcluir = new ProjetoBase.CustomControls.BotaoCC();
            this.btnAlterar = new ProjetoBase.CustomControls.BotaoCC();
            this.btnNovo = new ProjetoBase.CustomControls.BotaoCC();
            this.botaoCC3 = new ProjetoBase.CustomControls.BotaoCC();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomePrincipal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentoPrincipal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNPJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjetoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlAcoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAcoes
            // 
            this.pnlAcoes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAcoes.Controls.Add(this.btnExcluir);
            this.pnlAcoes.Controls.Add(this.btnAlterar);
            this.pnlAcoes.Controls.Add(this.btnNovo);
            this.pnlAcoes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAcoes.Location = new System.Drawing.Point(0, 0);
            this.pnlAcoes.Name = "pnlAcoes";
            this.pnlAcoes.Size = new System.Drawing.Size(800, 42);
            this.pnlAcoes.TabIndex = 1;
            // 
            // dgvClientes
            // 
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Tipo,
            this.NomePrincipal,
            this.CPF,
            this.DocumentoPrincipal,
            this.CNPJ,
            this.Email,
            this.ObjetoCliente});
            this.dgvClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClientes.Location = new System.Drawing.Point(0, 42);
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.NomeDisplay = null;
            this.dgvClientes.Obrigatorio = false;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(800, 408);
            this.dgvClientes.SomenteLeitura = false;
            this.dgvClientes.TabIndex = 0;
            // 
            // btnExcluir
            // 
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnExcluir.Location = new System.Drawing.Point(197, 3);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.NivelDeAcesso = null;
            this.btnExcluir.Size = new System.Drawing.Size(87, 30);
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
            this.btnAlterar.Location = new System.Drawing.Point(105, 3);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.NivelDeAcesso = null;
            this.btnAlterar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAlterar.Size = new System.Drawing.Size(86, 30);
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
            this.btnNovo.Location = new System.Drawing.Point(10, 3);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.NivelDeAcesso = null;
            this.btnNovo.Size = new System.Drawing.Size(89, 30);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Text = "Novo";
            this.btnNovo.TipoBotao = ProjetoBase.Enumeradores.TipoBotao.Default;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // botaoCC3
            // 
            this.botaoCC3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoCC3.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.botaoCC3.Location = new System.Drawing.Point(197, 3);
            this.botaoCC3.Name = "botaoCC3";
            this.botaoCC3.NivelDeAcesso = null;
            this.botaoCC3.Size = new System.Drawing.Size(89, 30);
            this.botaoCC3.TabIndex = 2;
            this.botaoCC3.Text = "botaoCC3";
            this.botaoCC3.TipoBotao = ProjetoBase.Enumeradores.TipoBotao.Default;
            this.botaoCC3.UseVisualStyleBackColor = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            // 
            // NomePrincipal
            // 
            this.NomePrincipal.DataPropertyName = "NomePrincipal";
            this.NomePrincipal.HeaderText = "NomePrincipal";
            this.NomePrincipal.Name = "NomePrincipal";
            // 
            // CPF
            // 
            this.CPF.DataPropertyName = "CPF";
            this.CPF.HeaderText = "CPF";
            this.CPF.Name = "CPF";
            // 
            // DocumentoPrincipal
            // 
            this.DocumentoPrincipal.DataPropertyName = "DocumentoPrincipal";
            this.DocumentoPrincipal.HeaderText = "DocumentoPrincipal";
            this.DocumentoPrincipal.Name = "DocumentoPrincipal";
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
            // ObjetoCliente
            // 
            this.ObjetoCliente.DataPropertyName = "ObjetoCliente";
            this.ObjetoCliente.HeaderText = "ObjetoCliente";
            this.ObjetoCliente.Name = "ObjetoCliente";
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
        private CustomControls.BotaoCC btnAlterar;
        private CustomControls.BotaoCC btnNovo;
        private CustomControls.BotaoCC botaoCC3;
        private CustomControls.BotaoCC btnExcluir;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomePrincipal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPF;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentoPrincipal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNPJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjetoCliente;
    }
}