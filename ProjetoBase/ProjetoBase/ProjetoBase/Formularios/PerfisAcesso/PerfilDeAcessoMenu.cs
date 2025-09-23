using NHibernate.Transform;
using ProjetoBase.DataBase;
using ProjetoBase.DataBase.Dominio.Funcionario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoBase.Formularios.PerfisAcesso
{
    public partial class PerfilDeAcessoMenu : Form
    {
        public PerfilDeAcessoMenu()
        {
            InitializeComponent();

            this.dgvPerfisAcesso.AutoGenerateColumns = false;
        }

        private void PerfilDeAcessoMenu_Load(object sender, EventArgs e)
        {
            CarregarPerfisAcesso();
        }

        public void CarregarPerfisAcesso()
        {
            // 1. Declare uma variável de "alias" (apelido) para a coleção
            NivelDeAcesso nivelAcessoAlias = null;

            IList<PerfilDeAcesso> perfis = SessionFactory.Session()
                .QueryOver<PerfilDeAcesso>()
                .Left.JoinAlias(p => p.NivelDeAcesso, () => nivelAcessoAlias)
                .TransformUsing(Transformers.DistinctRootEntity) // Essencial para evitar perfis duplicados
                .List();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Nome");
            dt.Columns.Add("Objeto", typeof(PerfilDeAcesso));

            foreach (var perfil in perfis)
            {
                dt.Rows.Add(perfil.Id, perfil.Nome, perfil);
            }

            dgvPerfisAcesso.DataSource = dt;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            PerfilDeAcessoCadastro formCadastro = new PerfilDeAcessoCadastro();
            formCadastro.ShowDialog();
            CarregarPerfisAcesso();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dgvPerfisAcesso.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecione um perfil para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PerfilDeAcesso perfilSelecionado = (PerfilDeAcesso)dgvPerfisAcesso.SelectedRows[0].Cells["Objeto"].Value;
            PerfilDeAcessoCadastro formCadastro = new PerfilDeAcessoCadastro(perfilSelecionado);
            formCadastro.ShowDialog();
            CarregarPerfisAcesso();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvPerfisAcesso.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecione um perfil para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resposta = MessageBox.Show("Tem certeza que deseja excluir este Perfil de Acesso?", "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                // A lógica de exclusão agora está dentro do 'try-catch'
                try
                {
                    PerfilDeAcesso perfilParaExcluir = (PerfilDeAcesso)dgvPerfisAcesso.SelectedRows[0].Cells["Objeto"].Value;
                    var sessao = SessionFactory.Session();
                    sessao.Delete(perfilParaExcluir);
                    sessao.Flush();
                    CarregarPerfisAcesso();
                }
                catch (Exception ex)
                {
                    // Se ocorrer um erro (como uma violação de chave estrangeira), ele será capturado aqui
                    MessageBox.Show("Não foi possível excluir o Perfil de Acesso. Verifique se ele não está sendo utilizado por algum usuário.\n\nErro original: " + ex.Message, "Erro de Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
