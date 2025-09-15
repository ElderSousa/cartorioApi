namespace ProjetoBase.CustomControls
{
    partial class ListaSeletorModoEscrita
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_seletor = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_seletor)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_seletor
            // 
            this.dgv_seletor.AllowUserToAddRows = false;
            this.dgv_seletor.AllowUserToDeleteRows = false;
            this.dgv_seletor.AllowUserToResizeColumns = false;
            this.dgv_seletor.AllowUserToResizeRows = false;
            this.dgv_seletor.BackgroundColor = System.Drawing.Color.White;
            this.dgv_seletor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_seletor.ColumnHeadersVisible = false;
            this.dgv_seletor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Codigo,
            this.colunaDescricao});
            this.dgv_seletor.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.dgv_seletor.Size = new System.Drawing.Size(206, 121);
            this.dgv_seletor.TabIndex = 113;
            this.dgv_seletor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_seletor_CellContentClick);
            this.dgv_seletor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_seletor_CellDoubleClick);
            this.dgv_seletor.SizeChanged += new System.EventHandler(this.dgv_seletor_SizeChanged);
            this.dgv_seletor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_seletor_KeyDown);
            this.dgv_seletor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgv_seletor_KeyPress);
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
            this.Codigo.Width = 30;
            // 
            // colunaDescricao
            // 
            this.colunaDescricao.DataPropertyName = "Descricao";
            this.colunaDescricao.HeaderText = "Descrição";
            this.colunaDescricao.Name = "colunaDescricao";
            this.colunaDescricao.Width = 170;
            // 
            // ListaSeletorModoEscrita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_seletor);
            this.Name = "ListaSeletorModoEscrita";
            this.Size = new System.Drawing.Size(206, 121);
            this.SizeChanged += new System.EventHandler(this.ListaSeletorModoEscrita_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_seletor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_seletor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaDescricao;
    }
}
