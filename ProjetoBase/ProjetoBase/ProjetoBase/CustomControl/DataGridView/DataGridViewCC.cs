using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoBase.CustomControls.Input
{
    public class DataGridViewCC : DataGridView, CustomControl
    {

        private String nomeDisplay;
        private Boolean obrigatorio = false;
        private Boolean somenteLeitura = false;
        private int indexLinhaSelecionada = 0;
        private int indexPrimeiraLinhaVisivel = 0;
        private int posicaoBarraRolagem = 0;

        Thread ThreadColoracaoLinhas;

        public delegate void LinhasColoridasHandler();
        public event LinhasColoridasHandler OnLinhasColoridas;


        public DataGridViewCC()
        {
            SelectionChanged += DataGridViewCC_SelectionChanged;
            DataSourceChanged += DataGridViewCC_DataSourceChanged;
            Scroll += DataGridViewCC_Scroll;

            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.MultiSelect = false;
        }
      
        public void disparaEventoLinhasColoridas()
        {
            if (OnLinhasColoridas == null) return;
            OnLinhasColoridas();
        }

        private void DataGridViewCC_Scroll(object sender, ScrollEventArgs e)
        {
            posicaoBarraRolagem = VerticalScrollBar.Value;
            indexPrimeiraLinhaVisivel = FirstDisplayedScrollingRowIndex;
        }

        private void DataGridViewCC_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
                if (RowCount - 1 >= indexLinhaSelecionada)
                {
                    SetSelectedRowCore(indexLinhaSelecionada, true);
                    SetSelectedRowCore(0, false);
                    if (posicaoBarraRolagem >= VerticalScrollBar.Minimum && posicaoBarraRolagem <= VerticalScrollBar.Maximum)
                    {
                        VerticalScrollBar.Value = posicaoBarraRolagem;
                        FirstDisplayedScrollingRowIndex = indexPrimeiraLinhaVisivel;
                    }
                }
                colorirLinhas();
            }
            catch { }
        }

        private void DataGridViewCC_SelectionChanged(object sender, EventArgs e)
        {
            if (SelectedRows != null && SelectedRows.Count > 0 && SelectedRows[0].Index > 0)
            {
                indexLinhaSelecionada = SelectedRows[0].Index;
            }
        }



        public void colorirLinhas()
        {
            ThreadColoracaoLinhas = new Thread(threadColoracaoLinhas);
            ThreadColoracaoLinhas.Start();
        }

        public void threadColoracaoLinhas()
        {
            try
            {
                Boolean branco = true;
                foreach (DataGridViewRow linha in Rows)
                {
                    if (branco)
                    {
                        linha.DefaultCellStyle.BackColor = Color.White;
                        branco = false;
                    }
                    else
                    {
                        linha.DefaultCellStyle.BackColor = Color.LightGray;
                        branco = true;
                    }
                }
                this.BeginInvoke((MethodInvoker)delegate () { this.disparaEventoLinhasColoridas(); ; });
            }
            catch
            {

            }
        }

        Boolean CustomControl.Valido()
        {
            if (obrigatorio == true && this.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        [Description("Nome a ser exibido ao usuario"), Category("Definição")]
        public String NomeDisplay
        {
            get { return nomeDisplay; }
            set { nomeDisplay = value; }
        }

        [Description("Define se o campo é obrigatorio"), Category("Definição")]
        public Boolean Obrigatorio
        {
            get { return obrigatorio; }
            set { obrigatorio = value; }
        }

        [Description("Define se o campo é somente leitura"), Category("Definição")]
        public Boolean SomenteLeitura
        {
            get { return somenteLeitura; }
            set
            {
                somenteLeitura = value;
                if (somenteLeitura)
                {
                    this.Enabled = false;
                }
                else
                {
                    this.Enabled = true;
                }
            }
        }

        public void Clear()
        {
            this.Rows.Clear();
        }
    }
}
