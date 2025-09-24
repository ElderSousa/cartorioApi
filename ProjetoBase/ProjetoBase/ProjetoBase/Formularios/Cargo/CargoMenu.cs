using NHibernate.Transform;
using ProjetoBase.CustomControl.Form;
using ProjetoBase.CustomControls;
using ProjetoBase.DataBase;
using ProjetoBase.DataBase.Dominio.Funcionario;
using ProjetoBase.DataBase.Ferramentas;
using ProjetoBase.Enumeradores;
using ProjetoBase.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

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
            // 1. Pega o valor da Tag e o converte (faz um "cast") para o tipo Enum
            var permissaoNecessaria = (EnumNivelDeAcesso)btn_cadastrar.Tag;

            // 2. Usa a permissão na nossa verificação
            if (SessaoSistema.VerificarPermissao(permissaoNecessaria))
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
            else
            {
                MessageBox.Show("Você não tem permissão para alterar cargos.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        void botao_alterar_Click(object sender, EventArgs e)
        {
            // 1. Pega o valor da Tag e o converte (faz um "cast") para o tipo Enum
            var permissaoNecessaria = (EnumNivelDeAcesso)btn_alterar.Tag;

            // 2. Usa a permissão na nossa verificação
            if (SessaoSistema.VerificarPermissao(permissaoNecessaria))
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
            else
            {
                MessageBox.Show("Você não tem permissão para alterar cargos.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void PessoaMenu_Load(object sender, EventArgs e)
        {
            BarraLateralBotoes.configurarBotoes();

            btn_cadastrar.Tag = EnumNivelDeAcesso.AcaoCargoCadastrar;
            btn_alterar.Tag = EnumNivelDeAcesso.AcaoCargoAlterar;

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
