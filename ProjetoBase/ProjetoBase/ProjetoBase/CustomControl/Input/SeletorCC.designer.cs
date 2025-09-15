namespace ProjetoBase.CustomControls
{
    partial class SeletorCC
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
            this.components = new System.ComponentModel.Container();
            this.btn_remover = new System.Windows.Forms.Button();
            this.btn_editar = new System.Windows.Forms.Button();
            this.lb_titulo = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.timerHideCaret = new System.Windows.Forms.Timer(this.components);
            this.timerListaClose = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btn_remover
            // 
            this.btn_remover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_remover.BackgroundImage = global::ProjetoBase.Properties.Resources.btn_x;
            this.btn_remover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_remover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_remover.Location = new System.Drawing.Point(229, 15);
            this.btn_remover.Name = "btn_remover";
            this.btn_remover.Size = new System.Drawing.Size(20, 20);
            this.btn_remover.TabIndex = 3;
            this.btn_remover.UseVisualStyleBackColor = true;
            this.btn_remover.Click += new System.EventHandler(this.btn_remover_Click);
            this.btn_remover.Enter += new System.EventHandler(this.btn_remover_Enter);
            this.btn_remover.MouseEnter += new System.EventHandler(this.btn_remover_MouseEnter);
            this.btn_remover.MouseLeave += new System.EventHandler(this.btn_remover_MouseLeave);
            // 
            // btn_editar
            // 
            this.btn_editar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_editar.BackgroundImage = global::ProjetoBase.Properties.Resources.icon_btn_edit;
            this.btn_editar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editar.Location = new System.Drawing.Point(206, 15);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(20, 20);
            this.btn_editar.TabIndex = 2;
            this.btn_editar.UseVisualStyleBackColor = true;
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            this.btn_editar.Enter += new System.EventHandler(this.btn_editar_Enter);
            // 
            // lb_titulo
            // 
            this.lb_titulo.AutoSize = true;
            this.lb_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_titulo.Location = new System.Drawing.Point(-3, -3);
            this.lb_titulo.Name = "lb_titulo";
            this.lb_titulo.Size = new System.Drawing.Size(39, 15);
            this.lb_titulo.TabIndex = 0;
            this.lb_titulo.Text = "titulo";
            this.lb_titulo.Click += new System.EventHandler(this.lb_titulo_Click);
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.BackColor = System.Drawing.Color.White;
            this.textBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox.ForeColor = System.Drawing.Color.Gray;
            this.textBox.Location = new System.Drawing.Point(0, 15);
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.Size = new System.Drawing.Size(206, 20);
            this.textBox.TabIndex = 1;
            this.textBox.Text = "CLIQUE PARA SELECIONAR";
            this.textBox.Click += new System.EventHandler(this.textBox_Click);
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBox.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.textBox.MouseEnter += new System.EventHandler(this.textBox_MouseEnter);
            this.textBox.MouseLeave += new System.EventHandler(this.textBox_MouseLeave);
            // 
            // timerHideCaret
            // 
            this.timerHideCaret.Enabled = true;
            this.timerHideCaret.Tick += new System.EventHandler(this.timerHideCaret_Tick);
            // 
            // timerListaClose
            // 
            this.timerListaClose.Interval = 50;
            this.timerListaClose.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SeletorCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.lb_titulo);
            this.Controls.Add(this.btn_editar);
            this.Controls.Add(this.btn_remover);
            this.Name = "SeletorCC";
            this.Size = new System.Drawing.Size(249, 37);
            this.Load += new System.EventHandler(this.SeletorCC_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_remover;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Label lb_titulo;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Timer timerHideCaret;
        private System.Windows.Forms.Timer timerListaClose;
    }
}
