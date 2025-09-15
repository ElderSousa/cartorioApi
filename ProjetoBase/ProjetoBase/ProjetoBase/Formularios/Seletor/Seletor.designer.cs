namespace ProjetoBase.Formularios
{
    partial class Seletor
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
            this.components = new System.ComponentModel.Container();
            this.btn_selecionar = new ProjetoBase.CustomControls.BotaoCC();
            this.lb_titulo = new System.Windows.Forms.Label();
            this.btn_cancelar = new ProjetoBase.CustomControls.BotaoCC();
            this.txt_filtro = new System.Windows.Forms.TextBox();
            this.btn_novo = new ProjetoBase.CustomControls.BotaoCC();
            this.dgv_seletor = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColunaDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPagePessoaJuridica = new System.Windows.Forms.TabPage();
            this.dgv_pessoa_juridica = new System.Windows.Forms.DataGridView();
            this.ColunaPJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColunaCodigoPJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPagePessoaFisica = new System.Windows.Forms.TabPage();
            this.dgv_pessoa_fisica = new System.Windows.Forms.DataGridView();
            this.ColunaPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColunaCodigoPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControlPessoa = new System.Windows.Forms.TabControl();
            this.timerEscrita = new System.Windows.Forms.Timer(this.components);
            this.seletorSecundario = new ProjetoBase.CustomControls.SeletorCC();
            this.panelTabela = new System.Windows.Forms.Panel();
            this.lbLegendaAnexosPessoa = new System.Windows.Forms.Label();
            this.cbMostrarRegistradas = new System.Windows.Forms.CheckBox();
            this.cbMostrarAnteriores = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_seletor)).BeginInit();
            this.tabPagePessoaJuridica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pessoa_juridica)).BeginInit();
            this.tabPagePessoaFisica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pessoa_fisica)).BeginInit();
            this.tabControlPessoa.SuspendLayout();
            this.panelTabela.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_selecionar
            // 
            this.btn_selecionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_selecionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_selecionar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_selecionar.ForeColor = System.Drawing.Color.DarkBlue;
            this.btn_selecionar.Location = new System.Drawing.Point(274, 318);
            this.btn_selecionar.Name = "btn_selecionar";
            this.btn_selecionar.NivelDeAcesso = null;
            this.btn_selecionar.Size = new System.Drawing.Size(160, 35);
            this.btn_selecionar.TabIndex = 2;
            this.btn_selecionar.Text = "Selecionar";
            this.btn_selecionar.TipoBotao = ProjetoBase.Enumeradores.TipoBotao.Selecionar;
            this.btn_selecionar.UseVisualStyleBackColor = true;
            this.btn_selecionar.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb_titulo
            // 
            this.lb_titulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_titulo.Location = new System.Drawing.Point(10, 2);
            this.lb_titulo.Name = "lb_titulo";
            this.lb_titulo.Size = new System.Drawing.Size(424, 26);
            this.lb_titulo.TabIndex = 0;
            this.lb_titulo.Text = "SELETOR";
            this.lb_titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_titulo.Click += new System.EventHandler(this.lb_titulo_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_cancelar.Location = new System.Drawing.Point(9, 318);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.NivelDeAcesso = null;
            this.btn_cancelar.Size = new System.Drawing.Size(120, 35);
            this.btn_cancelar.TabIndex = 4;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.TipoBotao = ProjetoBase.Enumeradores.TipoBotao.Cancelar;
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_filtro
            // 
            this.txt_filtro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_filtro.ForeColor = System.Drawing.Color.DarkGray;
            this.txt_filtro.Location = new System.Drawing.Point(9, 32);
            this.txt_filtro.Name = "txt_filtro";
            this.txt_filtro.Size = new System.Drawing.Size(424, 20);
            this.txt_filtro.TabIndex = 1;
            this.txt_filtro.Text = "PROCURAR";
            this.txt_filtro.TextChanged += new System.EventHandler(this.txt_filtro_TextChanged_2);
            this.txt_filtro.Enter += new System.EventHandler(this.txt_filtro_Enter);
            this.txt_filtro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_filtro_KeyPress);
            this.txt_filtro.Leave += new System.EventHandler(this.txt_filtro_Leave);
            // 
            // btn_novo
            // 
            this.btn_novo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_novo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_novo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_novo.ForeColor = System.Drawing.Color.DarkGreen;
            this.btn_novo.Location = new System.Drawing.Point(135, 318);
            this.btn_novo.Name = "btn_novo";
            this.btn_novo.NivelDeAcesso = null;
            this.btn_novo.Size = new System.Drawing.Size(133, 35);
            this.btn_novo.TabIndex = 3;
            this.btn_novo.Text = "Novo";
            this.btn_novo.TipoBotao = ProjetoBase.Enumeradores.TipoBotao.Novo;
            this.btn_novo.UseVisualStyleBackColor = true;
            this.btn_novo.Visible = false;
            this.btn_novo.Click += new System.EventHandler(this.btn_novo_Click);
            // 
            // dgv_seletor
            // 
            this.dgv_seletor.AllowUserToAddRows = false;
            this.dgv_seletor.AllowUserToDeleteRows = false;
            this.dgv_seletor.AllowUserToResizeColumns = false;
            this.dgv_seletor.AllowUserToResizeRows = false;
            this.dgv_seletor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_seletor.BackgroundColor = System.Drawing.Color.White;
            this.dgv_seletor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_seletor.ColumnHeadersVisible = false;
            this.dgv_seletor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Codigo,
            this.ColunaDescricao});
            this.dgv_seletor.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_seletor.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgv_seletor.Location = new System.Drawing.Point(0, 0);
            this.dgv_seletor.MultiSelect = false;
            this.dgv_seletor.Name = "dgv_seletor";
            this.dgv_seletor.RowHeadersVisible = false;
            this.dgv_seletor.RowHeadersWidth = 20;
            this.dgv_seletor.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_seletor.RowTemplate.Height = 17;
            this.dgv_seletor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_seletor.Size = new System.Drawing.Size(424, 253);
            this.dgv_seletor.TabIndex = 112;
            this.dgv_seletor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_seletor_CellDoubleClick);
            this.dgv_seletor.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_seletor_DataBindingComplete);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Proprio";
            this.Column1.HeaderText = "Entidade";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 70;
            // 
            // ColunaDescricao
            // 
            this.ColunaDescricao.DataPropertyName = "Descricao";
            this.ColunaDescricao.HeaderText = "Descrição";
            this.ColunaDescricao.Name = "ColunaDescricao";
            this.ColunaDescricao.Width = 350;
            // 
            // tabPagePessoaJuridica
            // 
            this.tabPagePessoaJuridica.Controls.Add(this.dgv_pessoa_juridica);
            this.tabPagePessoaJuridica.Location = new System.Drawing.Point(4, 22);
            this.tabPagePessoaJuridica.Name = "tabPagePessoaJuridica";
            this.tabPagePessoaJuridica.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePessoaJuridica.Size = new System.Drawing.Size(417, 227);
            this.tabPagePessoaJuridica.TabIndex = 1;
            this.tabPagePessoaJuridica.Text = "Pessoa Juridica";
            this.tabPagePessoaJuridica.UseVisualStyleBackColor = true;
            // 
            // dgv_pessoa_juridica
            // 
            this.dgv_pessoa_juridica.AllowUserToAddRows = false;
            this.dgv_pessoa_juridica.AllowUserToDeleteRows = false;
            this.dgv_pessoa_juridica.AllowUserToResizeColumns = false;
            this.dgv_pessoa_juridica.AllowUserToResizeRows = false;
            this.dgv_pessoa_juridica.BackgroundColor = System.Drawing.Color.White;
            this.dgv_pessoa_juridica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_pessoa_juridica.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColunaPJ,
            this.ColunaCodigoPJ,
            this.Column6,
            this.dataGridViewTextBoxColumn4,
            this.Column4});
            this.dgv_pessoa_juridica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_pessoa_juridica.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_pessoa_juridica.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgv_pessoa_juridica.Location = new System.Drawing.Point(3, 3);
            this.dgv_pessoa_juridica.MultiSelect = false;
            this.dgv_pessoa_juridica.Name = "dgv_pessoa_juridica";
            this.dgv_pessoa_juridica.RowHeadersVisible = false;
            this.dgv_pessoa_juridica.RowHeadersWidth = 20;
            this.dgv_pessoa_juridica.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_pessoa_juridica.RowTemplate.Height = 17;
            this.dgv_pessoa_juridica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_pessoa_juridica.Size = new System.Drawing.Size(411, 221);
            this.dgv_pessoa_juridica.TabIndex = 114;
            this.dgv_pessoa_juridica.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_pessoa_juridica_CellDoubleClick);
            this.dgv_pessoa_juridica.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_pessoa_juridica_DataBindingComplete);
            // 
            // ColunaPJ
            // 
            this.ColunaPJ.DataPropertyName = "Proprio";
            this.ColunaPJ.HeaderText = "Entidade";
            this.ColunaPJ.Name = "ColunaPJ";
            this.ColunaPJ.Visible = false;
            // 
            // ColunaCodigoPJ
            // 
            this.ColunaCodigoPJ.DataPropertyName = "Codigo";
            this.ColunaCodigoPJ.HeaderText = "Codigo";
            this.ColunaCodigoPJ.Name = "ColunaCodigoPJ";
            this.ColunaCodigoPJ.Width = 70;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "NumeroCartaoAutografo";
            this.Column6.HeaderText = "Cartão";
            this.Column6.Name = "Column6";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Descricao";
            this.dataGridViewTextBoxColumn4.HeaderText = "Nome";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 270;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DocumentoPessoa";
            this.Column4.HeaderText = "Documento";
            this.Column4.Name = "Column4";
            this.Column4.Width = 130;
            // 
            // tabPagePessoaFisica
            // 
            this.tabPagePessoaFisica.Controls.Add(this.dgv_pessoa_fisica);
            this.tabPagePessoaFisica.Location = new System.Drawing.Point(4, 22);
            this.tabPagePessoaFisica.Name = "tabPagePessoaFisica";
            this.tabPagePessoaFisica.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePessoaFisica.Size = new System.Drawing.Size(417, 227);
            this.tabPagePessoaFisica.TabIndex = 0;
            this.tabPagePessoaFisica.Text = "Pessoa Fisica";
            this.tabPagePessoaFisica.UseVisualStyleBackColor = true;
            // 
            // dgv_pessoa_fisica
            // 
            this.dgv_pessoa_fisica.AllowUserToAddRows = false;
            this.dgv_pessoa_fisica.AllowUserToDeleteRows = false;
            this.dgv_pessoa_fisica.AllowUserToResizeColumns = false;
            this.dgv_pessoa_fisica.AllowUserToResizeRows = false;
            this.dgv_pessoa_fisica.BackgroundColor = System.Drawing.Color.White;
            this.dgv_pessoa_fisica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_pessoa_fisica.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColunaPF,
            this.ColunaCodigoPF,
            this.Column5,
            this.dataGridViewTextBoxColumn2,
            this.Documento});
            this.dgv_pessoa_fisica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_pessoa_fisica.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_pessoa_fisica.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgv_pessoa_fisica.Location = new System.Drawing.Point(3, 3);
            this.dgv_pessoa_fisica.MultiSelect = false;
            this.dgv_pessoa_fisica.Name = "dgv_pessoa_fisica";
            this.dgv_pessoa_fisica.RowHeadersVisible = false;
            this.dgv_pessoa_fisica.RowHeadersWidth = 20;
            this.dgv_pessoa_fisica.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_pessoa_fisica.RowTemplate.Height = 17;
            this.dgv_pessoa_fisica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_pessoa_fisica.Size = new System.Drawing.Size(411, 221);
            this.dgv_pessoa_fisica.TabIndex = 113;
            this.dgv_pessoa_fisica.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_pessoa_fisica_CellDoubleClick);
            this.dgv_pessoa_fisica.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_pessoa_fisica_DataBindingComplete);
            // 
            // ColunaPF
            // 
            this.ColunaPF.DataPropertyName = "Proprio";
            this.ColunaPF.HeaderText = "Entidade";
            this.ColunaPF.Name = "ColunaPF";
            this.ColunaPF.Visible = false;
            // 
            // ColunaCodigoPF
            // 
            this.ColunaCodigoPF.DataPropertyName = "Codigo";
            this.ColunaCodigoPF.HeaderText = "Codigo";
            this.ColunaCodigoPF.Name = "ColunaCodigoPF";
            this.ColunaCodigoPF.Width = 70;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "NumeroCartaoAutografo";
            this.Column5.HeaderText = "Cartão";
            this.Column5.Name = "Column5";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Descricao";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nome";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 270;
            // 
            // Documento
            // 
            this.Documento.DataPropertyName = "DocumentoPessoa";
            this.Documento.HeaderText = "Documento";
            this.Documento.Name = "Documento";
            // 
            // tabControlPessoa
            // 
            this.tabControlPessoa.Controls.Add(this.tabPagePessoaFisica);
            this.tabControlPessoa.Controls.Add(this.tabPagePessoaJuridica);
            this.tabControlPessoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPessoa.Location = new System.Drawing.Point(0, 0);
            this.tabControlPessoa.Name = "tabControlPessoa";
            this.tabControlPessoa.SelectedIndex = 0;
            this.tabControlPessoa.Size = new System.Drawing.Size(425, 253);
            this.tabControlPessoa.TabIndex = 0;
            this.tabControlPessoa.Visible = false;
            this.tabControlPessoa.SelectedIndexChanged += new System.EventHandler(this.tabControlPessoa_SelectedIndexChanged);
            // 
            // timerEscrita
            // 
            this.timerEscrita.Interval = 1300;
            this.timerEscrita.Tick += new System.EventHandler(this.timerEscrita_Tick);
            // 
            // seletorSecundario
            // 
            this.seletorSecundario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seletorSecundario.CheckBoxRelacionado = null;
            this.seletorSecundario.codigo = null;
            this.seletorSecundario.codigoInt = null;
            this.seletorSecundario.CorLabel = System.Drawing.Color.Black;
            this.seletorSecundario.DisplaySomenteDescricao = false;
            this.seletorSecundario.Location = new System.Drawing.Point(9, 59);
            this.seletorSecundario.ModoEscrita = false;
            this.seletorSecundario.Name = "seletorSecundario";
            this.seletorSecundario.nome = null;
            this.seletorSecundario.NomeDisplay = "titulo";
            this.seletorSecundario.Obrigatorio = false;
            this.seletorSecundario.PermitirEdicaoComSenha = false;
            this.seletorSecundario.Seletor = null;
            this.seletorSecundario.Size = new System.Drawing.Size(448, 37);
            this.seletorSecundario.SomenteLeitura = false;
            this.seletorSecundario.TabIndex = 114;
            this.seletorSecundario.TextBoxRelacionado = null;
            this.seletorSecundario.Load += new System.EventHandler(this.seletorSecundario_Load);
            // 
            // panelTabela
            // 
            this.panelTabela.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTabela.Controls.Add(this.tabControlPessoa);
            this.panelTabela.Controls.Add(this.dgv_seletor);
            this.panelTabela.Location = new System.Drawing.Point(9, 59);
            this.panelTabela.Name = "panelTabela";
            this.panelTabela.Size = new System.Drawing.Size(425, 253);
            this.panelTabela.TabIndex = 115;
            // 
            // lbLegendaAnexosPessoa
            // 
            this.lbLegendaAnexosPessoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLegendaAnexosPessoa.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLegendaAnexosPessoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbLegendaAnexosPessoa.Location = new System.Drawing.Point(327, 8);
            this.lbLegendaAnexosPessoa.Name = "lbLegendaAnexosPessoa";
            this.lbLegendaAnexosPessoa.Size = new System.Drawing.Size(112, 17);
            this.lbLegendaAnexosPessoa.TabIndex = 116;
            this.lbLegendaAnexosPessoa.Text = "F6 - Visualizar Anexos";
            this.lbLegendaAnexosPessoa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLegendaAnexosPessoa.Visible = false;
            // 
            // cbMostrarRegistradas
            // 
            this.cbMostrarRegistradas.AutoSize = true;
            this.cbMostrarRegistradas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMostrarRegistradas.Location = new System.Drawing.Point(279, 55);
            this.cbMostrarRegistradas.Name = "cbMostrarRegistradas";
            this.cbMostrarRegistradas.Size = new System.Drawing.Size(156, 19);
            this.cbMostrarRegistradas.TabIndex = 117;
            this.cbMostrarRegistradas.Text = "Mostrar Registradas";
            this.cbMostrarRegistradas.UseVisualStyleBackColor = true;
            this.cbMostrarRegistradas.Visible = false;
            this.cbMostrarRegistradas.CheckedChanged += new System.EventHandler(this.cbMostrarRegistradas_CheckedChanged);
            // 
            // cbMostrarAnteriores
            // 
            this.cbMostrarAnteriores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMostrarAnteriores.AutoSize = true;
            this.cbMostrarAnteriores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMostrarAnteriores.Location = new System.Drawing.Point(309, -1);
            this.cbMostrarAnteriores.Name = "cbMostrarAnteriores";
            this.cbMostrarAnteriores.Size = new System.Drawing.Size(138, 19);
            this.cbMostrarAnteriores.TabIndex = 118;
            this.cbMostrarAnteriores.Text = "Mostrar Baixados";
            this.cbMostrarAnteriores.UseVisualStyleBackColor = true;
            this.cbMostrarAnteriores.Visible = false;
            this.cbMostrarAnteriores.CheckedChanged += new System.EventHandler(this.cbMostrarAnteriores_CheckedChanged);
            // 
            // Seletor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BotaoEscape = this.btn_cancelar;
            this.CancelButton = this.btn_cancelar;
            this.ClientSize = new System.Drawing.Size(443, 362);
            this.Controls.Add(this.cbMostrarAnteriores);
            this.Controls.Add(this.cbMostrarRegistradas);
            this.Controls.Add(this.lbLegendaAnexosPessoa);
            this.Controls.Add(this.btn_novo);
            this.Controls.Add(this.txt_filtro);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.lb_titulo);
            this.Controls.Add(this.btn_selecionar);
            this.Controls.Add(this.panelTabela);
            this.Controls.Add(this.seletorSecundario);
            this.Name = "Seletor";
            this.Nome_janela = "Seleção";
            this.Text = "Seletor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Seletor_FormClosing);
            this.Load += new System.EventHandler(this.Seletor_Load);
            this.Shown += new System.EventHandler(this.Seletor_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_seletor)).EndInit();
            this.tabPagePessoaJuridica.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pessoa_juridica)).EndInit();
            this.tabPagePessoaFisica.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pessoa_fisica)).EndInit();
            this.tabControlPessoa.ResumeLayout(false);
            this.panelTabela.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ProjetoBase.CustomControls.BotaoCC btn_selecionar;
        private System.Windows.Forms.Label lb_titulo;
        private ProjetoBase.CustomControls.BotaoCC btn_cancelar;
        private System.Windows.Forms.TextBox txt_filtro;
        private ProjetoBase.CustomControls.BotaoCC btn_novo;
        private System.Windows.Forms.DataGridView dgv_seletor;
        private System.Windows.Forms.TabPage tabPagePessoaJuridica;
        private System.Windows.Forms.DataGridView dgv_pessoa_juridica;
        private System.Windows.Forms.TabPage tabPagePessoaFisica;
        private System.Windows.Forms.DataGridView dgv_pessoa_fisica;
        private System.Windows.Forms.TabControl tabControlPessoa;
        private System.Windows.Forms.Timer timerEscrita;
        private CustomControls.SeletorCC seletorSecundario;
        private System.Windows.Forms.Panel panelTabela;
        private System.Windows.Forms.Label lbLegendaAnexosPessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColunaDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColunaPJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColunaCodigoPJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColunaPF;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColunaCodigoPF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.CheckBox cbMostrarRegistradas;
        private System.Windows.Forms.CheckBox cbMostrarAnteriores;
    }
}