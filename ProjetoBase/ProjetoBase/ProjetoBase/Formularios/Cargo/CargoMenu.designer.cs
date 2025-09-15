using ProjetoBase.Config;
using TecnoCart.CustomControls.Input;
using TecnoCart.CustomControls.Input.BotaoNavegacao;

namespace ProjetoBase.Formularios
{
    partial class CargoMenu
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
            this.dgv_cargo = new ProjetoBase.CustomControls.Input.DataGridViewCC();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarraLateralBotoes = new TecnoCart.CustomControls.Input.FlowLayoutPanelBotoesCC();
            this.btn_cadastrar = new TecnoCart.CustomControls.Input.BotaoNavegacao.BotaoAcaoCC();
            this.btn_alterar = new TecnoCart.CustomControls.Input.BotaoNavegacao.BotaoAcaoCC();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cargo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_cargo
            // 
            this.dgv_cargo.AllowUserToAddRows = false;
            this.dgv_cargo.AllowUserToResizeRows = false;
            this.dgv_cargo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_cargo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column2});
            this.dgv_cargo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_cargo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_cargo.Location = new System.Drawing.Point(90, 24);
            this.dgv_cargo.MultiSelect = false;
            this.dgv_cargo.Name = "dgv_cargo";
            this.dgv_cargo.NomeDisplay = null;
            this.dgv_cargo.Obrigatorio = false;
            this.dgv_cargo.RowHeadersVisible = false;
            this.dgv_cargo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_cargo.Size = new System.Drawing.Size(1814, 1018);
            this.dgv_cargo.SomenteLeitura = false;
            this.dgv_cargo.TabIndex = 4;
            this.dgv_cargo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_pessoa_CellContentClick);
            this.dgv_cargo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_pessoa_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ENTIDADE";
            this.Column1.HeaderText = "ENTIDADE";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ID";
            this.Column4.HeaderText = "Codigo";
            this.Column4.Name = "Column4";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "NOME";
            this.Column2.HeaderText = "Nome";
            this.Column2.Name = "Column2";
            this.Column2.Width = 600;
            // 
            // BarraLateralBotoes
            // 
            this.BarraLateralBotoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(44)))), ((int)(((byte)(46)))));
            this.BarraLateralBotoes.BotoesAcao = new TecnoCart.CustomControls.Input.BotaoNavegacao.BotaoAcaoCC[] {
        this.btn_cadastrar,
        this.btn_alterar};
            this.BarraLateralBotoes.ConfigurarAtalho = false;
            this.BarraLateralBotoes.Dock = System.Windows.Forms.DockStyle.Left;
            this.BarraLateralBotoes.Location = new System.Drawing.Point(0, 24);
            this.BarraLateralBotoes.Name = "BarraLateralBotoes";
            this.BarraLateralBotoes.Size = new System.Drawing.Size(90, 1018);
            this.BarraLateralBotoes.TabIndex = 10;
            // 
            // btn_cadastrar
            // 
            this.btn_cadastrar.Location = new System.Drawing.Point(0, 0);
            this.btn_cadastrar.Name = "btn_cadastrar";
            this.btn_cadastrar.NivelDeAcesso = null;
            this.btn_cadastrar.Size = new System.Drawing.Size(0, 0);
            this.btn_cadastrar.TabIndex = 0;
            this.btn_cadastrar.Tamanho = null;
            this.btn_cadastrar.Text = "botaoNavegacaoCC1";
            this.btn_cadastrar.TipoBotao = ProjetoBase.Enumeradores.EnumTipoBotaoAcao.Cadastrar;
            // 
            // btn_alterar
            // 
            this.btn_alterar.Location = new System.Drawing.Point(0, 0);
            this.btn_alterar.Name = "btn_alterar";
            this.btn_alterar.NivelDeAcesso = null;
            this.btn_alterar.Size = new System.Drawing.Size(0, 0);
            this.btn_alterar.TabIndex = 0;
            this.btn_alterar.Tamanho = null;
            this.btn_alterar.Text = "botaoNavegacaoCC2";
            this.btn_alterar.TipoBotao = ProjetoBase.Enumeradores.EnumTipoBotaoAcao.Alterar;
            // 
            // CargoMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1042);
            this.Controls.Add(this.dgv_cargo);
            this.Controls.Add(this.BarraLateralBotoes);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "CargoMenu";
            this.Nome_janela = "Cargo";
            this.Text = "Cargo";
            this.Load += new System.EventHandler(this.PessoaMenu_Load);
            this.Controls.SetChildIndex(this.BarraLateralBotoes, 0);
            this.Controls.SetChildIndex(this.dgv_cargo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cargo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.Input.DataGridViewCC dgv_cargo;
        private FlowLayoutPanelBotoesCC BarraLateralBotoes;
        private BotaoAcaoCC btn_cadastrar;
        private BotaoAcaoCC btn_alterar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}