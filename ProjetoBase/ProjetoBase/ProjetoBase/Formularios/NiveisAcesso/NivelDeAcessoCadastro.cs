using ProjetoBase.DataBase;
using ProjetoBase.DataBase.Dominio.Funcionario;
using System;
using System.Windows.Forms;

namespace ProjetoBase.Formularios.NiveisAcessoMenu
{
    public partial class NivelDeAcessoCadastro : Form
    {

        private NivelDeAcesso nivelAcesso;

        public NivelDeAcessoCadastro()
        {
            InitializeComponent();
            this.nivelAcesso = new NivelDeAcesso();
        }

        public NivelDeAcessoCadastro(NivelDeAcesso nivelParaEditar)
        {
            InitializeComponent();
            this.nivelAcesso = nivelParaEditar;
        }

        private void NivelDeAcessoCadastro_Load(object sender, EventArgs e)
        {
            if (this.nivelAcesso.Id != 0)
            {
                txtNome.Text = nivelAcesso.Nome;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O campo 'Nome' é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                nivelAcesso.Nome = txtNome.Text;
                var sessao = SessionFactory.Session();
                sessao.SaveOrUpdate(nivelAcesso);
                sessao.Flush();

                MessageBox.Show("Nível de Acesso salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Sinaliza sucesso
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
