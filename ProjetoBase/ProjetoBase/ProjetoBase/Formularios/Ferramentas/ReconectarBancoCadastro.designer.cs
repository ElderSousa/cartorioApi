namespace ProjetoBase.Formularios.Ferramentas
{
    partial class ReconectarBancoCadastro
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
            this.label1 = new System.Windows.Forms.Label();
            this.lb_status = new System.Windows.Forms.Label();
            this.timerAnimacaoStatus = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Não foi possivel conectar ao banco de dados!";
            // 
            // lb_status
            // 
            this.lb_status.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_status.Location = new System.Drawing.Point(12, 35);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(356, 19);
            this.lb_status.TabIndex = 4;
            this.lb_status.Text = "Reconectando";
            this.lb_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerAnimacaoStatus
            // 
            this.timerAnimacaoStatus.Enabled = true;
            this.timerAnimacaoStatus.Interval = 1000;
            this.timerAnimacaoStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // ReconectarBancoCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 61);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.label1);
            this.Name = "ReconectarBancoCadastro";
            this.Nome_janela = "Perda de Conexão";
            this.Text = "ValidacaoAcao";
            this.Load += new System.EventHandler(this.ValidacaoAcao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_status;
        private System.Windows.Forms.Timer timerAnimacaoStatus;
    }
}