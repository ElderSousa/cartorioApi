using ProjetoBase.DataBase;
using ProjetoBase.DataBase.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ProjetoBase.Formularios
{
    public partial class ClienteMenu : Form // ou a classe que ele herda
    {
        public ClienteMenu()
        {
            InitializeComponent();
        }

        private void ClienteMenu_Load(object sender, EventArgs e)
        {
            CarregarClientes();
        }

        public void CarregarClientes()
        {
            IList<Cliente> clientes = SessionFactory.Session().QueryOver<Cliente>().List();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tipo");
            dt.Columns.Add("Nome/Razão Social");
            dt.Columns.Add("CPF/CNPJ");
            dt.Columns.Add("Email");
            // Adicionamos o objeto Cliente inteiro, mas o deixamos invisível.
            // Isso facilitará a edição e exclusão depois.
            dt.Columns.Add("ObjetoCliente", typeof(Cliente));

            // --- LÓGICA ATUALIZADA AQUI ---
            // Agora, em vez de verificar o tipo da classe, verificamos a propriedade 'Tipo'
            foreach (var cliente in clientes)
            {
                if (cliente.Tipo == "PF")
                {
                    dt.Rows.Add(cliente.Id, "Física", cliente.Nome, cliente.Cpf, cliente.Email, cliente);
                }
                else if (cliente.Tipo == "PJ")
                {
                    dt.Rows.Add(cliente.Id, "Jurídica", cliente.RazaoSocial, cliente.Cnpj, cliente.Email, cliente);
                }
            }

            dgvClientes.DataSource = dt;

            // Oculta a coluna que guarda o objeto para não poluir a tela
            dgvClientes.Columns["ObjetoCliente"].Visible = false;
            dgvClientes.Columns["Nome/Razão Social"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        // Métodos dos botões virão aqui
    }
}