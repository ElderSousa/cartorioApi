using ProjetoBase.Config;
using ProjetoBase.Enumeradores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TecnoCart.CustomControls.Input.BotaoNavegacao
{
    public class BotaoAcaoCC : Control
    {
        PictureBoxButtonCC botao;
        EnumTipoBotaoAcao? tipoBotao;
        private EnumNivelDeAcesso? nivelAcesso = null;
        private Size? tamanho;

        public delegate void ClicadoHandler(BotaoAcaoCC botao);
        public event ClicadoHandler OnClicado;

        public BotaoAcaoCC()
        {
        }

        public void PerformClick()
        {
            botao.PerformClick();
        }

        private void Botao_Click(object sender, EventArgs e)
        {
            OnClicado?.Invoke(this);
        }

        [Description("PictureBox do botão"), Category("Definição")]
        public PictureBoxButtonCC Botao
        {
            get { return botao; }
        }

        [Description("Tipo do botão"), Category("Definição")]
        public EnumTipoBotaoAcao? TipoBotao
        {
            get { return tipoBotao; }
            set { tipoBotao = value; setBotao(); }
        }

        [Description("Nivel de acesso do botão"), Category("Definição")]
        public EnumNivelDeAcesso? NivelDeAcesso
        {
            get { return nivelAcesso; }
            set { nivelAcesso = value; }
        }

        [Description("Tamanho do botão"), Category("Definição")]
        public Size? Tamanho
        {
            get { return tamanho; }
            set
            {
                tamanho = value;
                if (botao != null)
                {
                    botao.Size = tamanho ?? new Size(95, 95);
                }
            }
        }
        public PictureBoxButtonCC setBotao()
        {
            if (tipoBotao != null)
            {
                if (botao == null)
                {
                    botao = new PictureBoxButtonCC();
                }
                botao.Size = tamanho ?? new Size(95, 95);
                switch (tipoBotao)
                {
                    case EnumTipoBotaoAcao.Cadastrar:
                        botao.Image = LayoutManager.ImageBotaoCadastrar;
                        break;

                    case EnumTipoBotaoAcao.Alterar:
                        botao.Image = LayoutManager.ImageBotaoEditar;
                        break;

                    case EnumTipoBotaoAcao.Deletar:
                        botao.Image = LayoutManager.ImageBotaoDeletar;
                        break;

                    
                }
                botao.Click += Botao_Click;
            }
            return botao;
        }


        public void setBotaoMenuAtual()
        {
            botao.setMenuAtual();
        }

    }
}
