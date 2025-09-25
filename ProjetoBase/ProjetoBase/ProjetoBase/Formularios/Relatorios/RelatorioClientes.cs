using NHibernate.Criterion;
using ProjetoBase.DataBase;
using ProjetoBase.DataBase.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoBase.Formularios.Relatorios
{
    public partial class RelatorioClientes : Form
    {
        public RelatorioClientes()
        {
            InitializeComponent();
        }

        private void RelatorioClientes_Load(object sender, EventArgs e)
        {
            // Popula o ComboBox com as opções de filtro
            cmbTipoFiltro.Items.Add("Todos");
            cmbTipoFiltro.Items.Add("Pessoa Física");
            cmbTipoFiltro.Items.Add("Pessoa Jurídica");
            cmbTipoFiltro.SelectedIndex = 0; // Deixa "Todos" selecionado por padrão
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var sessao = SessionFactory.Session();
                var query = sessao.QueryOver<Cliente>();

                // --- CONSTRUÇÃO DA CONSULTA DINÂMICA (SINTAXE CORRIGIDA) ---

                // Filtro por Nome/Razão Social
                if (!string.IsNullOrWhiteSpace(txtNomeFiltro.Text))
                {
                    // Cria uma disjunção (condição OR)
                    var nomeDisjunction = new Disjunction();
                    nomeDisjunction.Add(Restrictions.On<Cliente>(c => c.Nome).IsInsensitiveLike($"%{txtNomeFiltro.Text}%"));
                    nomeDisjunction.Add(Restrictions.On<Cliente>(c => c.RazaoSocial).IsInsensitiveLike($"%{txtNomeFiltro.Text}%"));
                    query.Where(nomeDisjunction);
                }

                // Filtro por Documento (CPF/CNPJ)
                if (!string.IsNullOrWhiteSpace(txtDocumentoFiltro.Text))
                {
                    var docDisjunction = new Disjunction();
                    docDisjunction.Add(Restrictions.On<Cliente>(c => c.Cpf).IsInsensitiveLike($"%{txtDocumentoFiltro.Text}%"));
                    docDisjunction.Add(Restrictions.On<Cliente>(c => c.Cnpj).IsInsensitiveLike($"%{txtDocumentoFiltro.Text}%"));
                    query.Where(docDisjunction);
                }

                // Filtro por Cidade
                if (!string.IsNullOrWhiteSpace(txtCidadeFiltro.Text))
                {
                    query.Where(Restrictions.On<Cliente>(c => c.Cidade).IsInsensitiveLike($"%{txtCidadeFiltro.Text}%"));
                }

                // Filtro por Tipo de Pessoa
                if (cmbTipoFiltro.SelectedItem.ToString() == "Pessoa Física")
                {
                    query.Where(c => c.Tipo == "PF");
                }
                else if (cmbTipoFiltro.SelectedItem.ToString() == "Pessoa Jurídica")
                {
                    query.Where(c => c.Tipo == "PJ");
                }

                // Executa a consulta no banco de dados
                IList<Cliente> resultados = query.List();

                // Chama o método para exibir os resultados na tela
                ExibirResultados(resultados);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao buscar os clientes: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExibirResultados(IList<Cliente> resultados)
        {
            // Prepara a tabela em memória para exibir os dados
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Tipo");
            dt.Columns.Add("Nome/Razão Social");
            dt.Columns.Add("CPF/CNPJ");
            dt.Columns.Add("Cidade");
            dt.Columns.Add("Email");

            foreach (var cliente in resultados)
            {
                if (cliente.Tipo == "PF")
                {
                    dt.Rows.Add(cliente.Id, "Física", cliente.Nome, cliente.Cpf, cliente.Cidade, cliente.Email);
                }
                else if (cliente.Tipo == "PJ")
                {
                    dt.Rows.Add(cliente.Id, "Jurídica", cliente.RazaoSocial, cliente.Cnpj, cliente.Cidade, cliente.Email);
                }
            }

            // Associa os dados à tabela na tela e configura as colunas
            dgvResultados.AutoGenerateColumns = false; // Garante que as colunas do designer sejam usadas
            dgvResultados.DataSource = dt;
        }
    }
}
