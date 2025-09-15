using NHibernate.Transform;
using ProjetoBase.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TecnoCart.CustomControls.Input.BotaoNavegacao;


namespace TecnoCart.CustomControls.Input
{
    public class FlowLayoutPanelBotoesCC : FlowLayoutPanel
    {
        private BotaoAcaoCC[] botoesAcao;
        private Boolean configurarAtalho;



        public FlowLayoutPanelBotoesCC()
        {
            this.BackColor = LayoutManager.corBotaoMouseLeave;
            configurarBotoes();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.BackColor = LayoutManager.corItemMenuStrip;
        }


        [Description("Botões de ação"), Category("Definição")]
        public BotaoAcaoCC[] BotoesAcao
        {
            get { return botoesAcao; }
            set { botoesAcao = value; configurarBotoes(); }
        }


        [Description("Define se é feita a validação dos atalhos no panel"), Category("Definição")]
        public Boolean ConfigurarAtalho
        {
            get { return configurarAtalho; }
            set { configurarAtalho = value; }
        }


        public void configurarBotoes()
        {
            if (botoesAcao != null)
            {
                foreach (BotaoAcaoCC botao in botoesAcao)
                {
                    this.Controls.Add(botao.Botao);
                }
            }

            
        }

    }
}
