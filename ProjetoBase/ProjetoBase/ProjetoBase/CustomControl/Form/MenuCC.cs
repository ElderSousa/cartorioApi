using ProjetoBase.CustomControls;
using ProjetoBase.CustomControls.Input;
using ProjetoBase.Formularios;
using ProjetoBase.Formularios.Clientes;
using ProjetoBase.Formularios.Funcionarios;
using ProjetoBase.Formularios.NiveisAcessoMenu;
using ProjetoBase.Formularios.PerfisAcesso;
using ProjetoBase.Renderers;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ProjetoBase.CustomControl.Form
{
    public partial class MenuCC : FormCC
    {
        public DataGridViewCC tabela;
        int? indexLinhaSelecionada = null;
        int? posicaoScroll = null;
        int? qtdLinhasTabela = null;

        public MenuCC()
        {
            InitializeComponent();

            this.menuStrip1.Renderer = new ToolStripProfessionalRenderer(new MenuColorTable());
        }

        public void fecharMenu()
        {
            if (backgroundWorkerUpdate.IsBusy == false)
            {
                //limparComponentes();
                this.Dispose();
            }
            else
            {
                this.Hide();
                backgroundWorkerUpdate.RunWorkerCompleted += BackgroundWorkerUpdate_RunWorkerCompleted1;
            }
        }

        private void BackgroundWorkerUpdate_RunWorkerCompleted1(object sender, RunWorkerCompletedEventArgs e)
        {
            if (tabela != null && tabela.Rows.Count > 0 && tabela.Rows.Count == qtdLinhasTabela && posicaoScroll != null && indexLinhaSelecionada != null)
            {
                tabela.Rows[(int)indexLinhaSelecionada].Selected = true;
                tabela.FirstDisplayedScrollingRowIndex = (int)posicaoScroll;
            }

            qtdLinhasTabela = tabela?.Rows.Count;

  
        }

        public void update()
        {
          

            if (tabela != null)
            {
                tabela.Enabled = false;
            }

            if (backgroundWorkerUpdate.IsBusy)
            {
                backgroundWorkerUpdate.CancelAsync();
                backgroundWorkerUpdate.setAtualizacaoPendente();
            }
            else
            {
                if (tabela?.SelectedRows?.Count > 0)
                {
                    indexLinhaSelecionada = tabela.SelectedRows[0].Index;
                    posicaoScroll = tabela.FirstDisplayedScrollingRowIndex;
                }

                qtdLinhasTabela = tabela?.Rows.Count;

                backgroundWorkerUpdate.RunWorkerAsync();
            }
        }

    }
}
