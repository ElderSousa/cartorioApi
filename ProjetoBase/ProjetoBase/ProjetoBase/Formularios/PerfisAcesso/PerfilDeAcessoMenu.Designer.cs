namespace ProjetoBase.Formularios.PerfisAcesso
{
    partial class PerfilDeAcessoMenu
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
            this.pnlPerfilAcesso = new System.Windows.Forms.Panel();
            this.btnNovo = new ProjetoBase.CustomControls.BotaoCC();
            this.btnAlterar = new ProjetoBase.CustomControls.BotaoCC();
            this.btnExcluir = new ProjetoBase.CustomControls.BotaoCC();
            this.dgvPerfisAcesso = new ProjetoBase.CustomControls.Input.DataGridViewCC();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Objeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPerfilAcesso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerfisAcesso)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPerfilAcesso
            // 
            this.pnlPerfilAcesso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPerfilAcesso.Controls.Add(this.btnExcluir);
            this.pnlPerfilAcesso.Controls.Add(this.btnAlterar);
            this.pnlPerfilAcesso.Controls.Add(this.btnNovo);
            this.pnlPerfilAcesso.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPerfilAcesso.Location = new System.Drawing.Point(0, 0);
            this.pnlPerfilAcesso.Name = "pnlPerfilAcesso";
            this.pnlPerfilAcesso.Size = new System.Drawing.Size(800, 40);
            this.pnlPerfilAcesso.TabIndex = 0;
            // 
            // btnNovo
            // 
            this.btnNovo.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnNovo.Location = new System.Drawing.Point(3, 10);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.NivelDeAcesso = null;
            this.btnNovo.Size = new System.Drawing.Size(96, 23);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Text = "Novo";
            this.btnNovo.TipoBotao = ProjetoBase.Enumeradores.TipoBotao.Default;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnAlterar.Location = new System.Drawing.Point(105, 10);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.NivelDeAcesso = null;
            this.btnAlterar.Size = new System.Drawing.Size(90, 23);
            this.btnAlterar.TabIndex = 1;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.TipoBotao = ProjetoBase.Enumeradores.TipoBotao.Default;
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnExcluir.Location = new System.Drawing.Point(201, 10);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.NivelDeAcesso = null;
            this.btnExcluir.Size = new System.Drawing.Size(88, 23);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.TipoBotao = ProjetoBase.Enumeradores.TipoBotao.Default;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // dgvPerfisAcesso
            // 
            this.dgvPerfisAcesso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerfisAcesso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nome,
            this.Objeto});
            this.dgvPerfisAcesso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPerfisAcesso.Location = new System.Drawing.Point(0, 40);
            this.dgvPerfisAcesso.MultiSelect = false;
            this.dgvPerfisAcesso.Name = "dgvPerfisAcesso";
            this.dgvPerfisAcesso.NomeDisplay = null;
            this.dgvPerfisAcesso.Obrigatorio = false;
            this.dgvPerfisAcesso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPerfisAcesso.Size = new System.Drawing.Size(800, 410);
            this.dgvPerfisAcesso.SomenteLeitura = false;
            this.dgvPerfisAcesso.TabIndex = 1;
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
            // PerfilDeAcessoMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvPerfisAcesso);
            this.Controls.Add(this.pnlPerfilAcesso);
            this.Name = "PerfilDeAcessoMenu";
            this.Text = "PerfilDeAcessoMenu";
            this.Load += new System.EventHandler(this.PerfilDeAcessoMenu_Load);
            this.pnlPerfilAcesso.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerfisAcesso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPerfilAcesso;
        private CustomControls.BotaoCC btnExcluir;
        private CustomControls.BotaoCC btnAlterar;
        private CustomControls.BotaoCC btnNovo;
        private CustomControls.Input.DataGridViewCC dgvPerfisAcesso;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Objeto;
    }
}