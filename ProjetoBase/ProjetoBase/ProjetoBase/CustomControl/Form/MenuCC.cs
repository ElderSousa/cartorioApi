using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjetoBase.CustomControls;
using ProjetoBase.CustomControls.Input;
using ProjetoBase.CustomControls.Validacao;
using ProjetoBase.Enumeradores;
using ProjetoBase.Formularios;

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
        }

        private void MenuCC_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void cargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // if (ValidacaoNivelDeAcesso.acessoPermitido(EnumNivelDeAcesso.Cargo, (ToolStripMenuItemCC)sender))
           // {
                // limparBackgrounWorker();
                // salvarTamanhoDataGridView();
                CargoMenu CargoMenu = new CargoMenu();
                CargoMenu.Show();
                fecharMenu();
            //}
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
