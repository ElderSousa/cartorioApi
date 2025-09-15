using NHibernate.Criterion;
using NHibernate.Transform;
using ProjetoBase.CustomControl.Form;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoBase.CustomControls;
using ProjetoBase.CustomControls.Validacao;
using ProjetoBase.DataBase;
using ProjetoBase.DataBase.Dominio;
using ProjetoBase.DataBase.Dominio.Funcionario;
using ProjetoBase.Exceptions;

namespace ProjetoBase.Formularios
{
    public partial class CargoMenu : MenuCC, InterfaceMenu
    {

        public CargoMenu()
        {
            InitializeComponent();

            //Eventos
            btn_cadastrar.Botao.Click += botao_cadastrar_Click;
            btn_alterar.Botao.Click += botao_alterar_Click;
            //Eventos

            backgroundWorkerUpdate.setMenu(this);
        }


        void botao_cadastrar_Click(object sender, EventArgs e)
        {
            if (ValidacaoNivelDeAcesso.acessoPermitido(btn_cadastrar.NivelDeAcesso))
            {
                CargoCadastro CargoCadastro = new CargoCadastro(null);
                CargoCadastro.ShowDialog();
                update();
            }
        }

        void botao_alterar_Click(object sender, EventArgs e)
        {
            if (ValidacaoNivelDeAcesso.acessoPermitido(btn_alterar.NivelDeAcesso))
            {
                if (dgv_cargo.SelectedRows.Count > 0)
                {
                    Cargo cargo = (Cargo)dgv_cargo.SelectedRows[0].Cells[0].Value;
                    if (cargo != null)
                    {
                        CargoCadastro CargoCadastro = new CargoCadastro(cargo);
                        CargoCadastro.ShowDialog();
                        update();
                    }
                }
            }
        }

        private void PessoaMenu_Load(object sender, EventArgs e)
        {
            BarraLateralBotoes.configurarBotoes();
            update();
        }

     
        //Detecta duplo clique na tabela
        private void dgv_pessoa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            botao_alterar_Click(btn_alterar, null);
        }
            

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private static IList<Cargo> procurarCargos()
        {
            IList<Cargo> cargos = null;

            cargos = SessionFactory.Session().QueryOver<Cargo>()
              .TransformUsing(Transformers.DistinctRootEntity)
              .OrderBy(c => c.Id).Asc
              .List<Cargo>();

            return cargos;
        }

        //Detecta o botão de pesquisa
        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            update();
        }

        private void dgv_pessoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void backgroundWorkerUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                IList<Cargo> cargos = procurarCargos();

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("ENTIDADE", typeof(Cargo));
                dataTable.Columns.Add("ID");
                dataTable.Columns.Add("NOME");

                for (int contadorPosicao = 0; contadorPosicao < cargos.Count; contadorPosicao++)
                {
                    if (backgroundWorkerUpdate.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    Cargo cargo = (Cargo)cargos[contadorPosicao];
                    dataTable.Rows.Add(cargo, cargo.Id, cargo.Nome);
                }
                this.dgv_cargo.BeginInvoke((MethodInvoker)delegate () { this.dgv_cargo.DataSource = dataTable; ; });
            }
            catch (Exception excecao)
            {
                ExceptionManager.tratarExcecao(excecao);
            }
        }

      
    }
}
