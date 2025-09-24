using ProjetoBase.CustomControl.Form;
using ProjetoBase.DataBase.Ferramentas;
using ProjetoBase.Enumeradores;
using ProjetoBase.Formularios.Clientes;
using ProjetoBase.Formularios.Funcionarios;
using ProjetoBase.Formularios.NiveisAcessoMenu;
using ProjetoBase.Formularios.PerfisAcesso;
using System;
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
            bool adicionarMenuCadastro = false;

            // Adiciona o item "Clientes"
            if (SessaoSistema.VerificarPermissao(EnumNivelDeAcesso.AcessoTelaClientes))
            {
                var menuClientes = new ToolStripMenuItem("Clientes");
                // Define a ação de clique diretamente
                menuClientes.Click += (s, ev) => { new ClienteMenu().Show(); };
                menuCadastro.DropDownItems.Add(menuClientes);
                adicionarMenuCadastro = true;
            }

            // --- CRIAÇÃO DO SUB-MENU "RH" (SE HOUVER PERMISSÃO PARA ALGUM FILHO) ---
            var menuRH = new ToolStripMenuItem("RH");
            bool adicionarMenuRH = false;

            if (SessaoSistema.VerificarPermissao(EnumNivelDeAcesso.AcessoTelaFuncionarios))
            {
                var menuFuncionarios = new ToolStripMenuItem("Funcionários");
                menuFuncionarios.Click += (s, ev) => { new FuncionarioCadastro().ShowDialog(); };
                menuRH.DropDownItems.Add(menuFuncionarios);
                adicionarMenuRH = true;
            }

            if (SessaoSistema.VerificarPermissao(EnumNivelDeAcesso.AcessoTelaCargo))
            {
                var menuCargo = new ToolStripMenuItem("Cargo");
                menuCargo.Click += (s, ev) => { new CargoMenu().Show(); };
                menuRH.DropDownItems.Add(menuCargo);
                adicionarMenuRH = true;
            }

            if (SessaoSistema.VerificarPermissao(EnumNivelDeAcesso.AcessoTelaNiveisDeAcesso))
            {
                var menuNiveis = new ToolStripMenuItem("Níveis de Acesso");
                menuNiveis.Click += (s, ev) => { new NivelDeAcessoMenu().Show(); };
                menuRH.DropDownItems.Add(menuNiveis);
                adicionarMenuRH = true;
            }

            if (SessaoSistema.VerificarPermissao(EnumNivelDeAcesso.AcessoTelaPerfisDeAcesso))
            {
                var menuPerfis = new ToolStripMenuItem("Perfis de Acesso");
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

            // (Adicionar outros menus de nível superior, como "Relatórios", seguiria o mesmo padrão aqui)
        }
    }
}

