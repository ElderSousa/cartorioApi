using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoBase.CustomControls;
using ProjetoBase.DataBase.Dominio;
using ProjetoBase.DataBase.Dominio.Funcionario;
using ProjetoBase.DataBase.Dominio.Interface;

using ProjetoBase.DataBase.Ferramentas;
using ProjetoBase.Enumeradores;
using ProjetoBase.Formularios.Ferramentas;

namespace ProjetoBase.Formularios
{
    public partial class Seletor : FormCC
    {
        public TipoSeletor tipoSeletor;



        public delegate void ItemSelecionadoHandler(Entidade entidade);
        public event ItemSelecionadoHandler Selecionado;

        public delegate void ItemSelecionadoPersistidoHandler(Boolean fisica);
        public event ItemSelecionadoPersistidoHandler SelecionadoPersistido;

        public Boolean AutoSelecionarSeUnico = false;

        public List<Entidade> ListaPreSetada = null;

        private TipoSeletor? tipoSeletorSecundario = null;

        private Entidade entidadeSecundaria = null;

        public Boolean selecaoObrigatoria = false;

        public Boolean bindingComplete = false;



        public Seletor(TipoSeletor tipoSeletor)
        {
            //533
            InitializeComponent();
            this.tipoSeletor = tipoSeletor;
            if (tipoSeletor == TipoSeletor.Pessoa)
            {
                tabControlPessoa.Visible = true;
                lbLegendaAnexosPessoa.Visible = true;
                dgv_seletor.Visible = false;
                this.Size = new Size(620, 401);
            }
            else if (tipoSeletor == TipoSeletor.PessoaFisica)
            {
                tabControlPessoa.Visible = true;
                lbLegendaAnexosPessoa.Visible = true;
                tabControlPessoa.TabPages.Remove(tabPagePessoaJuridica);
                dgv_seletor.Visible = false;
                this.Size = new Size(620, 401);
            }
            else if (tipoSeletor == TipoSeletor.PessoaJuridica)
            {
                tabControlPessoa.Visible = true;
                lbLegendaAnexosPessoa.Visible = true;
                tabControlPessoa.TabPages.Remove(tabPagePessoaFisica);
                dgv_seletor.Visible = false;
                this.Size = new Size(620, 401);
            }
            carregarSeletor();
        }

        public Seletor()
        {
            InitializeComponent();
        }


        public bool SeletorPessoaPersistida;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Enter && timerEscrita.Enabled == false)
            {
                if (btn_selecionar != null)
                {
                    if (btn_selecionar.Focused == false)
                    {
                        btn_selecionar.Focus();
                    }
                    else
                    {
                        btn_selecionar.PerformClick();
                    }
                    return true;
                }
                else
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }


        public void SetLista<T>(ISet<T> lista, String titulo)
        {
            ListaPreSetada = lista.Cast<Entidade>().ToList();
            dgv_seletor.AutoGenerateColumns = false;
            dgv_seletor.DataSource = ListaPreSetada;
            setTitulo(titulo);
            dgv_seletor.Visible = true;
        }


        //public void addPessoa(PessoaPersistida pessoa, AtividadeFicha ato)
        //{
        //    if (dgv_seletor.Columns.Count == 3)
        //    {
        //        dgv_seletor.Columns.Add("ATO", "Ato");
        //        ColunaDescricao.Width = 200;
        //    }

        //    dgv_seletor.Rows.Add(pessoa, pessoa.Codigo, pessoa.getNomePessoa(), ato.Descricao);
        //}

        public void setTamanho1()
        {
            dgv_seletor.Columns.Clear();

            this.Size = new Size(1050, 500);
            dgv_seletor.Columns.Add("Entidade", "Entidade");
            dgv_seletor.Columns.Add("Codigo", "Codigo");
            dgv_seletor.Columns.Add("Descricao", "Descricao");
            dgv_seletor.Columns[0].Visible = false;
            dgv_seletor.Columns[0].DataPropertyName = "Proprio";
            dgv_seletor.Columns[1].Width = 70;
            dgv_seletor.Columns[1].DataPropertyName = "Codigo";
            dgv_seletor.Columns[2].Width = 900;
            dgv_seletor.Columns[2].DataPropertyName = "Descricao";
        }

        public void carregarSeletor()
        {
            String filtro = txt_filtro.Text;
            if (filtro == "PROCURAR")
            {
                filtro = "";
            }

            dgv_seletor.AutoGenerateColumns = false;
            dgv_pessoa_fisica.AutoGenerateColumns = false;
            dgv_pessoa_juridica.AutoGenerateColumns = false;

            if (ListaPreSetada == null)
            {
                switch (tipoSeletor)
                {


                    case TipoSeletor.Cargo:
                        setTitulo("Cargo");
                        IList<Cargo> listaCargo = ListarSeletores.getListaCargo(filtro);
                        dgv_seletor.DataSource = listaCargo;
                        break;


                }
            }
            else
            {
                if (filtro != null)
                {
                    IList<Entidade> listaFiltrada = ListaPreSetada.Where(x => x.Codigo.Contains(filtro) || x.Descricao.Contains(filtro)).ToList();
                    dgv_seletor.DataSource = listaFiltrada;
                }
                else
                {
                    dgv_seletor.DataSource = ListaPreSetada;
                }
            }

            configurarSeletorSecundario();
        }

        private void Dgv_seletor_RegimeBens_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgv_seletor.AutoResizeColumn(1);
            dgv_seletor.AutoResizeRow(dgv_seletor.RowCount - 1);

            //if ((int)dgv_seletor.Rows[e.RowIndex].Cells[0].Value >= 2006 && (int)dgv_seletor.Rows[e.RowIndex].Cells[0].Value <= 2011)
            //{
            //    dgv_seletor.Rows[e.RowIndex].Height = 80;
            //    dgv_seletor.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //}
            //else
            //{
            //    dgv_seletor.Rows[e.RowIndex].Height = 17;
            //}
        }

        private void configurarSeletorServentia()
        {
            dgv_seletor.Columns.Clear();

            dgv_seletor.Columns.Add("Entidade", "Entidade");
            dgv_seletor.Columns.Add("CNS", "CNS");
            dgv_seletor.Columns.Add("CodigoServentia", "Cod. TJ");
            dgv_seletor.Columns.Add("NomeFantasia", "Nome Fantasia");
            dgv_seletor.Columns.Add("NomeOficial", "Nome Oficial");
            dgv_seletor.Columns.Add("NomeCidade", "Municipio");

            dgv_seletor.Columns[0].Visible = false;
            dgv_seletor.Columns[0].DataPropertyName = "Proprio";
            dgv_seletor.Columns[1].Width = 70;
            dgv_seletor.Columns[1].DataPropertyName = "CNS";
            dgv_seletor.Columns[2].Width = 70;
            dgv_seletor.Columns[2].DataPropertyName = "CodigoServentia";
            dgv_seletor.Columns[3].Width = 230;
            dgv_seletor.Columns[3].DataPropertyName = "NomeFantasia";
            dgv_seletor.Columns[4].Width = 230;
            dgv_seletor.Columns[4].DataPropertyName = "NomeOficial";
            dgv_seletor.Columns[5].Width = 230;
            dgv_seletor.Columns[5].DataPropertyName = "NomeCidade";

            dgv_seletor.ColumnHeadersVisible = true;
            this.Size = new Size(900, 400);
        }

        private void setLayoutTabela1()
        {
            dgv_seletor.Columns.Clear();
            dgv_seletor.Columns.Add("Entidade", "Entidade");
            dgv_seletor.Columns.Add("Descricao", "Descricao");
            dgv_seletor.Columns[0].Visible = false;
            dgv_seletor.Columns[0].DataPropertyName = "Proprio";
            dgv_seletor.Columns[1].Width = 350;
            dgv_seletor.Columns[1].DataPropertyName = "Descricao";
        }

        //Configura o seletor secundario
        public void configurarSeletorSecundario()
        {
            if (tipoSeletorSecundario != null)
            {
                seletorSecundario.Seletor = tipoSeletorSecundario;
                switch (tipoSeletorSecundario)
                {
                    case TipoSeletor.Pessoa:
                        seletorSecundario.NomeDisplay = "Pessoa";
                        break;
                    case TipoSeletor.Municipio:
                        seletorSecundario.NomeDisplay = "Municipio";
                        break;

                }
                panelTabela.Location = new Point(9, 101);
                panelTabela.Size = new Size(panelTabela.Size.Width, 211);
            }
        }

        private void Seletor_Load(object sender, EventArgs e)
        {

        }

        public void setTitulo(String titulo)
        {
            this.Text = titulo;
            lb_titulo.Text = titulo;
        }

        private void lb_titulo_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            selecionar();
        }

        //Seleciona o objeto escolhido no datagridview
        public void selecionar()
        {
            String cod = null;
            String nome = null;
            Entidade entidade = null;

            Boolean objetoValido = true;

            if (dgv_seletor.SelectedRows != null && dgv_seletor.SelectedRows.Count > 0)
            {            
                                
                    int index = dgv_seletor.SelectedRows[0].Index;
                    entidade = (Entidade)dgv_seletor.Rows[index].Cells[0].Value;                

            }

            if (entidade != null && objetoValido)
            {
                Selecionado?.Invoke(entidade);
                selecaoObrigatoria = false;
                this.DialogResult = DialogResult.Yes;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }


        private void txt_filtro_TextChanged(object sender, EventArgs e)
        {
            carregarSeletor();
        }


        private void txt_filtro_Enter(object sender, EventArgs e)
        {
            if (txt_filtro.Text == "PROCURAR")
            {
                txt_filtro.Text = "";
                txt_filtro.ForeColor = Color.Black;
            }
        }

        private void txt_filtro_Leave(object sender, EventArgs e)
        {
            if (txt_filtro.Text == "")
            {
                txt_filtro.Text = "PROCURAR";
                txt_filtro.ForeColor = Color.DarkGray;
            }
        }

        private void txt_filtro_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void txt_filtro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                timerEscrita.Stop();
                carregarSeletor();
            }
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {


            switch (tipoSeletor)
            {
               
          
                //case TipoSeletor.Cargo:
                //    CargoCadastro CargoCadastro = new CargoCadastro(null);
                //    CargoCadastro.OnSalvo += eventoEntidadeCadastrada;
                //    CargoCadastro.ShowDialog();
                //    break;


               
            }

        }

    
        private void eventoEntidadeCadastrada(Entidade entidade)
        {
            Selecionado?.Invoke(entidade);
            this.DialogResult = DialogResult.Yes;
        }

        private void txt_filtro_TextChanged_2(object sender, EventArgs e)
        {
            //carregarSeletor();
            timerEscrita.Stop();
            timerEscrita.Start();
            timerEscrita.Enabled = true;
        }

        private void dgv_seletor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingComplete)
            {
                btn_selecionar.PerformClick();
            }
        }

        private void tabControlPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregarSeletor();
        }

        private void dgv_pessoa_fisica_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_selecionar.PerformClick();
        }

        private void dgv_pessoa_juridica_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_selecionar.PerformClick();
        }

        private void timerEscrita_Tick(object sender, EventArgs e)
        {
            timerEscrita.Enabled = false;
            if (txt_filtro.Text != "PROCURAR" && txt_filtro.Text != "")
            {
                carregarSeletor();
            }
        }

        private void dgv_seletor_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            bindingComplete = true;
            if (AutoSelecionarSeUnico)
            {
                if (dgv_seletor.Rows.Count == 1)
                {
                    dgv_seletor.Rows[0].Selected = true;
                    btn_selecionar.PerformClick();
                }
            }
        }

  
        private void Seletor_Shown(object sender, EventArgs e)
        {
           
            
        }

        internal void setSelecaoObrigatoria()
        {
            selecaoObrigatoria = true;
            btn_cancelar.Visible = false;
        }

        private void Seletor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (selecaoObrigatoria)
            {
                e.Cancel = true;
            }
        }

        private void dgv_pessoa_fisica_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
          
        }

        private void dgv_pessoa_juridica_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
           
        }

        private void seletorSecundario_Load(object sender, EventArgs e)
        {

        }

        private void cbMostrarRegistradas_CheckedChanged(object sender, EventArgs e)
        {
            carregarSeletor();
        }

        private void cbMostrarAnteriores_CheckedChanged(object sender, EventArgs e)
        {
           

        }
    }
}
