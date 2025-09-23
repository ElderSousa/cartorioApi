using ProjetoBase.DataBase;
using ProjetoBase.DataBase.Dominio.Funcionario;
using ProjetoBase.Ferramentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoBase.Formularios
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            // 1. Pega os dados da tela
            string login = txtLogin.Text;
            string senha = txtSenha.Text;

            // 2. Validação básica
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Por favor, preencha o login e a senha.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var sessao = SessionFactory.Session();

                // 3. Busca o usuário pelo login no banco de dados
                Usuario usuario = sessao.QueryOver<Usuario>()
                                        .Where(u => u.Login == login)
                                        .SingleOrDefault();

                // 4. Verifica se o usuário existe E se a senha está correta
                if (usuario != null && usuario.VerificarSenha(senha))
                {
                    // 5. Autenticação bem-sucedida! Agora, busca o funcionário associado.
                    Funcionario funcionario = sessao.QueryOver<Funcionario>()
                                                    .Where(f => f.usuario.Id == usuario.Id)
                                                    .SingleOrDefault();

                    // 6. Armazena o funcionário logado na sessão do sistema (CRUCIAL)
                    SessaoSistema.funcionario = funcionario;

                    // 7. Libera o acesso ao sistema
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // Se o usuário não existe ou a senha está errada
                    MessageBox.Show("Usuário ou senha inválidos.", "Falha de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro durante o login: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
