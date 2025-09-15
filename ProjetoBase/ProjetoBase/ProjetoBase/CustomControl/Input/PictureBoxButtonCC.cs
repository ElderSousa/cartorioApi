using ProjetoBase.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TecnoCart.CustomControls.Input
{
    public class PictureBoxButtonCC : PictureBox
    {
        private Image imagemBotao = null;
        private Boolean botaoDeMenuAtual = false;
        private Size? tamanho;


        public PictureBoxButtonCC()
        {
            this.BackColor = LayoutManager.corBotaoMouseLeave;            
            this.Size = tamanho ?? new Size(95, 95);
            this.SizeMode = PictureBoxSizeMode.Zoom;
            this.Margin = new Padding(0, 0, 0, 0);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.BackColor = LayoutManager.corBotaoMouseEnter;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.BackColor = LayoutManager.corBotaoMouseLeave;
            if (botaoDeMenuAtual)
            {
                this.BackColor = LayoutManager.corBotaoMenuAtual;
            }
        }

        public void setMenuAtual()
        {
            this.BackColor = LayoutManager.corBotaoMenuAtual;
            botaoDeMenuAtual = true;
        }

        public void limparSelecao()
        {
            this.BackColor = LayoutManager.corBotaoMouseLeave;
            botaoDeMenuAtual = false;
        }

        [Description("Imagem do Botão"), Category("Definição")]
        public Image ImagemBotao
        {
            get { return imagemBotao; }
            set { imagemBotao = value; this.Image = imagemBotao; }
        }

        [Description("Tamanho do botão"), Category("Definição")]
        public Size? Tamanho
        {
            get { return tamanho; }
            set { tamanho = value; }
        }

        internal void PerformClick()
        {
            OnClick(new EventArgs());
        }
    }
}
