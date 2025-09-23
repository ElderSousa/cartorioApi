namespace ProjetoBase.Formularios.NiveisAcessoMenu
{
    partial class NivelDeAcessoMenu
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
            this.pnlNivelAcesso = new System.Windows.Forms.Panel();
            this.btnNovo = new ProjetoBase.CustomControls.BotaoCC();
            this.btnAlterar = new ProjetoBase.CustomControls.BotaoCC();
            this.btnExcluir = new ProjetoBase.CustomControls.BotaoCC();
            this.dgvNiveisAcesso = new ProjetoBase.CustomControls.Input.DataGridViewCC();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Objeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlNivelAcesso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNiveisAcesso)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlNivelAcesso
            // 
            this.pnlNivelAcesso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlNivelAcesso.Controls.Add(this.btnExcluir);
            this.pnlNivelAcesso.Controls.Add(this.btnAlterar);
            this.pnlNivelAcesso.Controls.Add(this.btnNovo);
            this.pnlNivelAcesso.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNivelAcesso.Location = new System.Drawing.Point(0, 0);
            this.pnlNivelAcesso.Name = "pnlNivelAcesso";
            this.pnlNivelAcesso.Size = new System.Drawing.Size(800, 40);
            this.pnlNivelAcesso.TabIndex = 0;
            // 
            // btnNovo
            // 
            this.btnNovo.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnNovo.Location = new System.Drawing.Point(10, 3);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.NivelDeAcesso = null;
            this.btnNovo.Size = new System.Drawing.Size(94, 30);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Text = "Novo";
            this.btnNovo.TipoBotao = ProjetoBase.Enumeradores.TipoBotao.Default;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnAlterar.Location = new System.Drawing.Point(110, 3);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.NivelDeAcesso = null;
            this.btnAlterar.Size = new System.Drawing.Size(94, 30);
            this.btnAlterar.TabIndex = 1;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.TipoBotao = ProjetoBase.Enumeradores.TipoBotao.Default;
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnExcluir.Location = new System.Drawing.Point(210, 3);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.NivelDeAcesso = null;
            this.btnExcluir.Size = new System.Drawing.Size(87, 30);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.TipoBotao = ProjetoBase.Enumeradores.TipoBotao.Default;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // dgvNiveisAcesso
            // 
            this.dgvNiveisAcesso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNiveisAcesso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nome,
            this.Objeto});
            this.dgvNiveisAcesso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNiveisAcesso.Location = new System.Drawing.Point(0, 40);
            this.dgvNiveisAcesso.MultiSelect = false;
            this.dgvNiveisAcesso.Name = "dgvNiveisAcesso";
            this.dgvNiveisAcesso.NomeDisplay = null;
            this.dgvNiveisAcesso.Obrigatorio = false;
            this.dgvNiveisAcesso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNiveisAcesso.Size = new System.Drawing.Size(800, 410);
            this.dgvNiveisAcesso.SomenteLeitura = false;
            this.dgvNiveisAcesso.TabIndex = 1;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Nome
            // 
            this.Nome.DataPropertyName = "Nome";
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            // 
            // Objeto
            // 
            this.Objeto.DataPropertyName = "Objeto";
            this.Objeto.HeaderText = "Objeto";
            this.Objeto.Name = "Objeto";
            this.Objeto.Visible = false;
            // 
            // NivelDeAcessoMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvNiveisAcesso);
            this.Controls.Add(this.pnlNivelAcesso);
            this.Name = "NivelDeAcessoMenu";
            this.Text = "NivelDeAcessoMenu";
            this.Load += new System.EventHandler(this.NivelDeAcessoMenu_Load);
            this.pnlNivelAcesso.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNiveisAcesso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNivelAcesso;
        private CustomControls.BotaoCC btnExcluir;
        private CustomControls.BotaoCC btnAlterar;
        private CustomControls.BotaoCC btnNovo;
        private CustomControls.Input.DataGridViewCC dgvNiveisAcesso;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Objeto;
    }
}