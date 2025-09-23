using ProjetoBase.DataBase;
using ProjetoBase.DataBase.Dominio.Funcionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoBase.Formularios.PerfisAcesso
{
    public partial class PerfilDeAcessoCadastro : Form
    {
        private PerfilDeAcesso perfilAcesso;

        public PerfilDeAcessoCadastro()
        {
            InitializeComponent();
            this.perfilAcesso = new PerfilDeAcesso();
        }

        public PerfilDeAcessoCadastro(PerfilDeAcesso perfilParaEditar)
        {
            InitializeComponent();
            this.perfilAcesso = perfilParaEditar;
        }

        private void PerfilDeAcessoCadastro_Load(object sender, EventArgs e)
        {
            // 1. Carrega TODOS os Níveis de Acesso possíveis
            IList<NivelDeAcesso> todosOsNiveis = SessionFactory.Session().QueryOver<NivelDeAcesso>().List();
            clbNiveisAcesso.DataSource = todosOsNiveis;
            clbNiveisAcesso.DisplayMember = "Nome";

            // 2. Se estiver editando, preenche os campos
            if (this.perfilAcesso.Id != 0)
            {
                txtNome.Text = perfilAcesso.Nome;

                // Marca os checkboxes dos níveis que este perfil já possui
                for (int i = 0; i < clbNiveisAcesso.Items.Count; i++)
                {
                    var nivelDaLista = (NivelDeAcesso)clbNiveisAcesso.Items[i];
                    if (this.perfilAcesso.NivelDeAcesso.Any(n => n.Id == nivelDaLista.Id))
                    {
                        clbNiveisAcesso.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O campo 'Nome' é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                perfilAcesso.Nome = txtNome.Text;

                // Limpa a lista antiga e adiciona apenas os que foram marcados
                perfilAcesso.NivelDeAcesso.Clear();
                foreach (NivelDeAcesso nivelMarcado in clbNiveisAcesso.CheckedItems)
                {
                    perfilAcesso.NivelDeAcesso.Add(nivelMarcado);
                }

                var sessao = SessionFactory.Session();
                sessao.SaveOrUpdate(perfilAcesso);
                sessao.Flush();

                MessageBox.Show("Perfil de Acesso salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
