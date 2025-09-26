using ProjetoBase.CustomControl.Form;
using ProjetoBase.DataBase.Ferramentas;
using ProjetoBase.Enumeradores;
using ProjetoBase.Formularios.Clientes;
using ProjetoBase.Formularios.ConfigDataBase;
using ProjetoBase.Formularios.Funcionarios;
using ProjetoBase.Formularios.NiveisAcessoMenu;
using ProjetoBase.Formularios.PerfisAcesso;
using ProjetoBase.Formularios.Relatorios;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoBase.Formularios
{
    public partial class MenuInicial : MenuCC
    {
        public MenuInicial()
        {
            InitializeComponent();
        }

        private void MenuInicial_Shown(object sender, EventArgs e)
        {
            // Quando a tela estiver visível, constrói o menu com base nas permissões.
            ConstruirMenuDinamico();
        }

        /// <summary>
        /// Constrói dinamicamente toda a estrutura do menu principal
        /// com base nas permissões do utilizador logado.
        /// </summary>
        private void ConstruirMenuDinamico()
        {
            // Garante que o menu comece vazio
            this.menuStrip1.Items.Clear();

            // --- CRIAÇÃO DO MENU "CADASTRO" (SE HOUVER PERMISSÃO PARA ALGUM FILHO) ---
            var menuCadastro = new ToolStripMenuItem("Cadastro");
            menuCadastro.ForeColor = Color.White;
            bool adicionarMenuCadastro = false;

            // Adiciona o item "Clientes"
            if (SessaoSistema.VerificarPermissao(EnumNivelDeAcesso.AcessoTelaClientes))
            {
                var menuClientes = new ToolStripMenuItem("Clientes");
                // Define a ação de clique diretamente
                menuClientes.ForeColor = Color.White;
                menuClientes.Click += (s, ev) => { new ClienteMenu().Show(); };
                menuCadastro.DropDownItems.Add(menuClientes);
                adicionarMenuCadastro = true;
            }

            // --- CRIAÇÃO DO SUB-MENU "RH" (SE HOUVER PERMISSÃO PARA ALGUM FILHO) ---
            var menuRH = new ToolStripMenuItem("RH");
            menuRH.ForeColor = Color.White;
            bool adicionarMenuRH = false;

            if (SessaoSistema.VerificarPermissao(EnumNivelDeAcesso.AcessoTelaFuncionarios))
            {
                var menuFuncionarios = new ToolStripMenuItem("Funcionários");
                menuFuncionarios.ForeColor = Color.White;
                menuFuncionarios.Click += (s, ev) => { new FuncionarioCadastro().ShowDialog(); };
                menuRH.DropDownItems.Add(menuFuncionarios);
                adicionarMenuRH = true;
            }

            if (SessaoSistema.VerificarPermissao(EnumNivelDeAcesso.AcessoTelaCargo))
            {
                var menuCargo = new ToolStripMenuItem("Cargo");
                menuCargo.ForeColor = Color.White;
                menuCargo.Click += (s, ev) => { new CargoMenu().Show(); };
                menuRH.DropDownItems.Add(menuCargo);
                adicionarMenuRH = true;
            }

            if (SessaoSistema.VerificarPermissao(EnumNivelDeAcesso.AcessoTelaNiveisDeAcesso))
            {
                var menuNiveis = new ToolStripMenuItem("Níveis de Acesso");
                menuNiveis.ForeColor = Color.White;
                menuNiveis.Click += (s, ev) => { new NivelDeAcessoMenu().Show(); };
                menuRH.DropDownItems.Add(menuNiveis);
                adicionarMenuRH = true;
            }

            if (SessaoSistema.VerificarPermissao(EnumNivelDeAcesso.AcessoTelaPerfisDeAcesso))
            {
                var menuPerfis = new ToolStripMenuItem("Perfis de Acesso");
                menuPerfis.ForeColor = Color.White;
                menuPerfis.Click += (s, ev) => { new PerfilDeAcessoMenu().Show(); };
                menuRH.DropDownItems.Add(menuPerfis);
                adicionarMenuRH = true;
            }

            // Adiciona o menu RH ao menu Cadastro apenas se ele tiver itens
            if (adicionarMenuRH)
            {
                menuCadastro.DropDownItems.Add(menuRH);
                adicionarMenuCadastro = true;
            }

            // Adiciona o menu Cadastro à barra principal apenas se ele tiver itens
            if (adicionarMenuCadastro)
            {
                this.menuStrip1.Items.Add(menuCadastro);
            }

            // --- NOVA SEÇÃO: CRIAÇÃO DO MENU "RELATÓRIOS" ---
            var menuRelatorios = new ToolStripMenuItem("Relatórios");
            menuRelatorios.ForeColor = Color.White;
            bool adicionarMenuRelatorios = false;

            // Verifica a permissão para o relatório de clientes
            if (SessaoSistema.VerificarPermissao(EnumNivelDeAcesso.AcessoRelatorioClientes))
            {
                var menuRelatorioClientes = new ToolStripMenuItem("Relatório de Clientes");
                menuRelatorioClientes.ForeColor = Color.White;
                menuRelatorioClientes.Click += (s, ev) => { new RelatorioClientes().Show(); };
                menuRelatorios.DropDownItems.Add(menuRelatorioClientes);
                adicionarMenuRelatorios = true;
            }

            // Adiciona o menu "Relatórios" à barra principal apenas se ele tiver itens
            if (adicionarMenuRelatorios)
            {
                this.menuStrip1.Items.Add(menuRelatorios);
            }

            // --- NOVA SEÇÃO: CRIAÇÃO DO MENU "CONFIGURAÇÕES" ---
            // A verificação abaixo garante que apenas administradores vejam este menu.
            if (SessaoSistema.funcionario != null && SessaoSistema.funcionario.usuario.Administrador)
            {
                var menuConfiguracoes = new ToolStripMenuItem("Configurações");
                menuConfiguracoes.ForeColor = Color.White;

                var menuConexao = new ToolStripMenuItem("Conexão com Banco de Dados");
                menuConexao.ForeColor = Color.White;
                menuConexao.Click += (s, ev) => { new ConfiguracaoConexao().ShowDialog(); };
                menuConfiguracoes.DropDownItems.Add(menuConexao);

                // Adiciona o novo menu "Configurações" à barra de menu principal
                this.menuStrip1.Items.Add(menuConfiguracoes);
            }

        }

        private void MenuInicial_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            // Environment.Exit(0) é uma forma mais forçada de encerrar a aplicação,
            // garantindo que threads em background também sejam terminadas.
            Environment.Exit(0);
        }
    }
}

