using ProjetoBase.DataBase;
using ProjetoBase.DataBase.Dominio;
using System;
using System.Windows.Forms;

namespace ProjetoBase.Formularios.Clientes
{
    public partial class ClienteCadastro : Form
    {
        private Cliente cliente;
        public ClienteCadastro()
        {
            InitializeComponent();
            this.cliente = null;
        }

        public ClienteCadastro(Cliente clienteParaEditar)
        {
            InitializeComponent();
            this.cliente = clienteParaEditar;
        }

        private void ClienteCadastro_Load(object sender, EventArgs e)
        {
            cmbTipoCliente.Items.Add("Pessoa Física");
            cmbTipoCliente.Items.Add("Pessoa Jurídica");

            // Se this.cliente não for nulo, significa que estamos editando.
            if (this.cliente != null)
            {
                Text = "Editando Cliente"; // Muda o título da janela
                PreencherCampos();
            }
            else // Se for nulo, é um novo cadastro.
            {
                Text = "Novo Cliente";
                cmbTipoCliente.SelectedIndex = 0;
            }
        }

        private void PreencherCampos()
        {
            // Preenche a tela com os dados do cliente existente
            if (cliente.Tipo == "PF")
            {
                cmbTipoCliente.SelectedItem = "Pessoa Física";
                textNome.Text = cliente.Nome;
                textCPF.Text = cliente.Cpf;
                // ... aqui você preencheria os outros campos de PF e os comuns ...
            }
            else
            {
                cmbTipoCliente.SelectedItem = "Pessoa Jurídica";
                textRazaoSocial.Text = cliente.RazaoSocial;
                textCNPJ.Text = cliente.Cnpj;
                // ... aqui você preencheria os outros campos de PJ e os comuns ...
            }
            // ... aqui você preencheria os campos comuns (Endereço, Email, etc.) ...

            cmbTipoCliente.Enabled = false; // Impede a troca de tipo durante a edição
        }

        private void cmbTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoCliente.SelectedItem.ToString() == "Pessoa Física")
            {
                pnlPessoaFisica.Visible = true;
                pnlPessoaJuridica.Visible = false;
            }
            else
            {
                pnlPessoaFisica.Visible = false;
                pnlPessoaJuridica.Visible = true;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. PREPARAR O OBJETO
                // Se for um cliente novo, cria a instância
                if (this.cliente == null)
                {
                    this.cliente = new Cliente();
                }

                // 2. PEGAR OS DADOS DA TELA
                // (Aqui entraria a validação para campos obrigatórios)
                cliente.Tipo = (cmbTipoCliente.SelectedItem.ToString() == "Pessoa Física") ? "PF" : "PJ";

                if (cliente.Tipo == "PF")
                {
                    cliente.Nome = textNome.Text;
                    cliente.Cpf = textCPF.Text;
                }
                else
                {
                    cliente.RazaoSocial = textRazaoSocial.Text;
                    cliente.Cnpj = textCNPJ.Text;
                }
                // ... pegar dados dos campos comuns (endereço, etc.) ...

                // 3. SALVAR NO BANCO
                var sessao = SessionFactory.Session();
                sessao.SaveOrUpdate(cliente); // NHibernate decide se faz INSERT ou UPDATE
                sessao.Flush();

                MessageBox.Show("Cliente salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Fecha a tela de cadastro
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao salvar o cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
