using ProjetoBase.DataBase;
using ProjetoBase.DataBase.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoBase.Formularios.Clientes
{
    public partial class ClienteMenu : Form
    {
        public ClienteMenu()
        {
            InitializeComponent();

            this.dgvClientes.AutoGenerateColumns = false;
        }

        private void ClienteMenu_Load(object sender, EventArgs e)
        { 
            CarregarClientes();
        }

        public void CarregarClientes()
        {
            // Busca a lista de Clientes
            IList<Cliente> clientes = SessionFactory.Session().QueryOver<Cliente>().List();

            // Prepara a tabela em memória para exibir os dados
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tipo");
            dt.Columns.Add("NomePrincipal");
            dt.Columns.Add("DocumentoPrincipal");
            dt.Columns.Add("CPF");
            dt.Columns.Add("CNPJ");
            dt.Columns.Add("Email");
            dt.Columns.Add("ObjetoCliente", typeof(Cliente));

            // Itera sobre a lista e adiciona na DataTable
            foreach (var cliente in clientes)
            {
                if (cliente.Tipo == "PF")
                {
                    dt.Rows.Add(
                    cliente.Id,
                    "Física",
                    cliente.Nome,
                    cliente.Cpf,
                    cliente.Email,
                    cliente
                    );
                }
                else if (cliente.Tipo == "PJ")
                {
                    dt.Rows.Add(
                    cliente.Id,
                    "Jurídica",
                    cliente.RazaoSocial,
                    cliente.Cnpj,
                    cliente.Email,
                    cliente
                    );
                }
            }

            // Associa os dados à tabela na tela
            dgvClientes.DataSource = dt;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            ClienteCadastro formCadastro = new ClienteCadastro();
            formCadastro.ShowDialog();
            CarregarClientes();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecione um cliente para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente clienteSelecionado = (Cliente)dgvClientes.SelectedRows[0].Cells["ObjetoCliente"].Value;

            ClienteCadastro formCadastro = new ClienteCadastro(clienteSelecionado);
            formCadastro.ShowDialog();

            CarregarClientes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecione um cliente para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resposta = MessageBox.Show("Tem certeza que deseja excluir este cliente? Esta ação não pode ser desfeita.", "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                try
                {
                    Cliente clienteParaExcluir = (Cliente)dgvClientes.SelectedRows[0].Cells["ObjetoCliente"].Value;

                    var sessao = SessionFactory.Session();
                    sessao.Delete(clienteParaExcluir);
                    sessao.Flush();

                    MessageBox.Show("Cliente excluído com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CarregarClientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao excluir o cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
