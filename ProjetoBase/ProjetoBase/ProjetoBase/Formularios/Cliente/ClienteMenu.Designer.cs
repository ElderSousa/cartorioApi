namespace ProjetoBase.Formularios
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
            this.dgvClientes = new ProjetoBase.CustomControls.Input.DataGridViewCC();
            this.pnlAcoes = new System.Windows.Forms.Panel();
            this.btnExcluirCliente = new ProjetoBase.CustomControls.BotaoCC();
            this.btnAlterarCliente = new ProjetoBase.CustomControls.BotaoCC();
            this.btnNovoCliente = new ProjetoBase.CustomControls.BotaoCC();
            this.listaSeletorModoEscrita1 = new ProjetoBase.CustomControls.ListaSeletorModoEscrita();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.pnlAcoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvClientes
            // 
            this.dgvClientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClientes.Location = new System.Drawing.Point(0, 0);
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.NomeDisplay = null;
            this.dgvClientes.Obrigatorio = false;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(800, 450);
            this.dgvClientes.SomenteLeitura = false;
            this.dgvClientes.TabIndex = 0;
            // 
            // pnlAcoes
            // 
            this.pnlAcoes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAcoes.Controls.Add(this.btnExcluirCliente);
            this.pnlAcoes.Controls.Add(this.btnAlterarCliente);
            this.pnlAcoes.Controls.Add(this.btnNovoCliente);
            this.pnlAcoes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAcoes.Location = new System.Drawing.Point(0, 0);
            this.pnlAcoes.Name = "pnlAcoes";
            this.pnlAcoes.Size = new System.Drawing.Size(800, 35);
            this.pnlAcoes.TabIndex = 1;
            // 
            // btnExcluirCliente
            // 
            this.btnExcluirCliente.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnExcluirCliente.Location = new System.Drawing.Point(188, 5);
            this.btnExcluirCliente.Name = "btnExcluirCliente";
            this.btnExcluirCliente.NivelDeAcesso = null;
            this.btnExcluirCliente.Size = new System.Drawing.Size(74, 23);
            this.btnExcluirCliente.TabIndex = 2;
            this.btnExcluirCliente.Text = "Excluir";
            this.btnExcluirCliente.UseVisualStyleBackColor = true;
            // 
            // btnAlterarCliente
            // 
            this.btnAlterarCliente.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnAlterarCliente.Location = new System.Drawing.Point(107, 5);
            this.btnAlterarCliente.Name = "btnAlterarCliente";
            this.btnAlterarCliente.NivelDeAcesso = null;
            this.btnAlterarCliente.Size = new System.Drawing.Size(75, 23);
            this.btnAlterarCliente.TabIndex = 1;
            this.btnAlterarCliente.Text = "Alterar";
            this.btnAlterarCliente.UseVisualStyleBackColor = true;
            // 
            // btnNovoCliente
            // 
            this.btnNovoCliente.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnNovoCliente.Location = new System.Drawing.Point(21, 5);
            this.btnNovoCliente.Name = "btnNovoCliente";
            this.btnNovoCliente.NivelDeAcesso = null;
            this.btnNovoCliente.Size = new System.Drawing.Size(80, 23);
            this.btnNovoCliente.TabIndex = 0;
            this.btnNovoCliente.Text = "Novo";
            this.btnNovoCliente.UseVisualStyleBackColor = true;
            // 
            // listaSeletorModoEscrita1
            // 
            this.listaSeletorModoEscrita1.Location = new System.Drawing.Point(165, 0);
            this.listaSeletorModoEscrita1.Name = "listaSeletorModoEscrita1";
            this.listaSeletorModoEscrita1.Size = new System.Drawing.Size(8, 8);
            this.listaSeletorModoEscrita1.TabIndex = 2;
            // 
            // ClienteMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listaSeletorModoEscrita1);
            this.Controls.Add(this.pnlAcoes);
            this.Controls.Add(this.dgvClientes);
            this.Name = "ClienteMenu";
            this.Text = "ClienteMenu";
            this.Load += new System.EventHandler(this.ClienteMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.pnlAcoes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.Input.DataGridViewCC dgvClientes;
        private System.Windows.Forms.Panel pnlAcoes;
        private CustomControls.BotaoCC btnExcluirCliente;
        private CustomControls.BotaoCC btnAlterarCliente;
        private CustomControls.BotaoCC btnNovoCliente;
        private CustomControls.ListaSeletorModoEscrita listaSeletorModoEscrita1;
    }
}