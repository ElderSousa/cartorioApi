using ProjetoBase.DataBase;
using ProjetoBase.DataBase.Dominio.Funcionario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ProjetoBase.Formularios.NiveisAcessoMenu
{
    public partial class NivelDeAcessoMenu : Form
    {
        public NivelDeAcessoMenu()
        {
            InitializeComponent();

            this.dgvNiveisAcesso.AutoGenerateColumns = false;
        }

        private void NivelDeAcessoMenu_Load(object sender, EventArgs e)
        {
            CarregarNiveisAcesso();
        }

        public void CarregarNiveisAcesso()
        {
            // Usamos o apelido 'NivelDeAcessoEntidade' para nos referirmos à classe
            IList<NivelDeAcesso> niveis = SessionFactory.Session().QueryOver<NivelDeAcesso>().List();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Nome");
            dt.Columns.Add("Objeto", typeof(NivelDeAcesso)); // Usamos o apelido aqui também

            foreach (var nivel in niveis)
            {
                dt.Rows.Add(nivel.Id, nivel.Nome, nivel);
            }

            dgvNiveisAcesso.DataSource = dt;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            NivelDeAcessoCadastro formCadastro = new NivelDeAcessoCadastro();
            formCadastro.ShowDialog();
            CarregarNiveisAcesso(); // Atualiza a lista
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dgvNiveisAcesso.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecione um item para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NivelDeAcesso nivelSelecionado = (NivelDeAcesso)dgvNiveisAcesso.SelectedRows[0].Cells["Objeto"].Value;
            NivelDeAcessoCadastro formCadastro = new NivelDeAcessoCadastro(nivelSelecionado);
            formCadastro.ShowDialog();
            CarregarNiveisAcesso();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvNiveisAcesso.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecione um item para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resposta = MessageBox.Show("Tem certeza que deseja excluir este Nível de Acesso?", "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                try
                {
                    NivelDeAcesso nivelParaExcluir = (NivelDeAcesso)dgvNiveisAcesso.SelectedRows[0].Cells["Objeto"].Value;
                    var sessao = SessionFactory.Session();
                    sessao.Delete(nivelParaExcluir);
                    sessao.Flush();
                    CarregarNiveisAcesso();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
