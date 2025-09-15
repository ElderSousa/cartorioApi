using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjetoBase.DataBase.Dominio;
using ProjetoBase.DataBase.Dominio.Interface;
using ProjetoBase.Enumeradores;
using ProjetoBase.Formularios;
using ProjetoBase.DataBase.Dominio.Funcionario;


namespace ProjetoBase.CustomControls
{
    public partial class ListaSeletorModoEscrita : UserControl
    {
        public List<Entidade> ListaPreSetada = null;

    
        private TipoSeletor? tipoSeletorSecundario = null;
        private Entidade entidadeSecundaria = null;

        Button btn_novo = new Button();


        public delegate void ItemSelecionadoHandler(Entidade entidade);
        public event ItemSelecionadoHandler Selecionado;


        public ListaSeletorModoEscrita()
        {
            InitializeComponent();

        }

        public void setTitulo(String valor)
        {

        }

        public void carregarSeletor(String filtro, TipoSeletor? tipoSeletor)
        {
            if (filtro == "PROCURAR")
            {
                filtro = "";
            }

            dgv_seletor.AutoGenerateColumns = false;

            if (ListaPreSetada == null)
            {
                switch (tipoSeletor)
                {
                 
                    case TipoSeletor.Cargo:
                        btn_novo.Visible = true;
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

            if (dgv_seletor.SelectedRows.Count > 0)
            {
                dgv_seletor.SelectedRows[0].Selected = false;
            }

            //configurarSeletorSecundario();
        }

        internal bool focado()
        {
            return dgv_seletor.Focused;
        }

        internal void focar()
        {
            if (dgv_seletor.Rows.Count > 0)
            {
                dgv_seletor.Focus();
                dgv_seletor.Rows[0].Selected = true;
            }
        }

        private void dgv_seletor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_seletor.Rows.Count > 0)
            {
                var entidade = (Entidade)dgv_seletor.SelectedRows[0].Cells[0].Value;
                Selecionado?.Invoke(entidade);
                this.Hide();
            }
        }


        private void dgv_seletor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    if (dgv_seletor.SelectedRows[0].Index < dgv_seletor.Rows.Count)
            //    {
            //        dgv_seletor.Rows[dgv_seletor.SelectedRows[0].Index - 1].Selected = true;
            //    }
            //}
            //catch
            //{

            //}

            //if (e.KeyChar == (char)13)
            //{
            //    if (dgv_seletor.Rows.Count > 0)
            //    {
            //        var entidade = (Entidade)dgv_seletor.SelectedRows[0].Cells[0].Value;
            //        Selecionado?.Invoke(entidade);
            //        this.Hide();
            //    }
            //}
        }

        private void dgv_seletor_SizeChanged(object sender, EventArgs e)
        {

        }

        private void dgv_seletor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            colunaDescricao.Width = dgv_seletor.Width - 36;
        }

        private void ListaSeletorModoEscrita_SizeChanged(object sender, EventArgs e)
        {
            colunaDescricao.Width = dgv_seletor.Width - 42;

        }

        private void dgv_seletor_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData & Keys.KeyCode) == Keys.Enter)
            {
                if (dgv_seletor.Rows.Count > 0)
                {
                    var entidade = (Entidade)dgv_seletor.SelectedRows[0].Cells[0].Value;
                    Selecionado?.Invoke(entidade);
                    this.Hide();
                }

                return;
            }
            else
                base.OnKeyDown(e);
        }
    }
}
