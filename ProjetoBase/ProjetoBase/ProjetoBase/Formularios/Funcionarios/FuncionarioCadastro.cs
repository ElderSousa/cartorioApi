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

namespace ProjetoBase.Formularios.Funcionarios
{
    public partial class FuncionarioCadastro : Form
    {
        public FuncionarioCadastro()
        {
            InitializeComponent();
        }

        private void FuncionarioCadastro_Load(object sender, EventArgs e)
        {
            CarregarCargos();
            CarregarNiveisDeAcesso();
            CarregarPerfisDeAcesso();
        }

        private void CarregarCargos()
        {
            // Busca todos os cargos do banco de dados
            IList<Cargo> cargos = SessionFactory.Session().QueryOver<Cargo>().OrderBy(c => c.Nome).Asc.List();

            // Configura o ComboBox de Cargos
            cmbCargo.DataSource = cargos;
            cmbCargo.DisplayMember = "Nome"; // A propriedade do objeto Cargo que será exibida na lista
            cmbCargo.ValueMember = "Id";   // A propriedade que será usada como valor interno
        }

        private void CarregarPerfisDeAcesso()
        {
            // Busca todos os perfis de acesso do banco
            IList<PerfilDeAcesso> perfis = SessionFactory.Session().QueryOver<PerfilDeAcesso>().OrderBy(p => p.Nome).Asc.List();

            cmbPerfilAcesso.DataSource = perfis;
            cmbPerfilAcesso.DisplayMember = "Nome";
            cmbPerfilAcesso.ValueMember = "Id";
        }

        private void CarregarNiveisDeAcesso()
        {
            // Busca todos os níveis de acesso do banco
            IList<NivelDeAcesso> niveis = SessionFactory.Session().QueryOver<NivelDeAcesso>().OrderBy(n => n.Nome).Asc.List();

            // Configura o CheckedListBox
            clbNiveisAcesso.DataSource = niveis;
            clbNiveisAcesso.DisplayMember = "Nome";
            clbNiveisAcesso.ValueMember = "Id";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O campo 'Nome' é obrigatório.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("O campo 'Login' é obrigatório.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("O campo 'Senha' é obrigatório.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtSenha.Text != txtConfirmarSenha.Text)
            {
                MessageBox.Show("As senhas não conferem.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // (Você pode adicionar outras validações aqui, como para o CPF, etc.)

            try
            {
                // --- ETAPA DE PREPARAÇÃO DOS OBJETOS ---
                var sessao = SessionFactory.Session();

                // 1. Cria e popula o objeto Usuario
                var usuario = new Usuario();
                usuario.Login = txtLogin.Text;
                usuario.DefinirSenha(txtSenha.Text); // Usa nosso método seguro que já criptografa a senha
                usuario.PerfilDeAcesso = (PerfilDeAcesso)cmbPerfilAcesso.SelectedItem;

                // Adiciona os Níveis de Acesso que foram marcados na lista
                foreach (NivelDeAcesso nivel in clbNiveisAcesso.CheckedItems)
                {
                    usuario.NivelDeAcesso.Add(nivel);
                }

                // 2. Cria e popula o objeto Funcionario
                var funcionario = new Funcionario();
                funcionario.Nome = txtNome.Text;
                funcionario.Cpf = mtbCpf.Text;
                funcionario.Rg = txtRg.Text;
                funcionario.DataNascimento = dtpNascimento.Value;
                funcionario.Email = txtEmail.Text;
                funcionario.Cargo = (Cargo)cmbCargo.SelectedItem;

                // 3. Associa o Usuario ao Funcionario (a "ligação" principal)
                funcionario.usuario = usuario;

                // --- ETAPA DE SALVAMENTO ---
                using (var transacao = sessao.BeginTransaction())
                {
                    // Como o mapeamento do Funcionario tem Cascade.All() para o Usuario,
                    // basta salvar o funcionário que o NHibernate salva o usuário e as permissões junto.
                    sessao.Save(funcionario);
                    transacao.Commit();
                }

                MessageBox.Show("Funcionário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Fecha a tela de cadastro
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao salvar o funcionário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Define o resultado da caixa de diálogo como "Cancelado".
            // Isso é uma boa prática caso o formulário que o chamou precise saber
            // se a operação foi salva ou cancelada.
            this.DialogResult = DialogResult.Cancel;

            // Fecha o formulário, descartando quaisquer dados não salvos.
            this.Close();
        }
    }
}
