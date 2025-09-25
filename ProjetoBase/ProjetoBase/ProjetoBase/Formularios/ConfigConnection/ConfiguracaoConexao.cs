using ProjetoBase.Config;
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

namespace ProjetoBase.Formularios.ConfigDataBase
{
    public partial class ConfiguracaoConexao : Form
    {
        public ConfiguracaoConexao()
        {
            InitializeComponent();
        }

        private void ConfiguracaoConexao_Load(object sender, EventArgs e)
        {
            CarregarConfiguracaoAtual();
        }

        private void CarregarConfiguracaoAtual()
        {
            var config = ConfigManager.getConfig();
            if (config?.Instancias != null && config.Instancias.Any())
            {
                // Pega a primeira instância da lista (ou a marcada como 'UltimaInstanciaUsada')
                var instancia = config.Instancias.FirstOrDefault();
                if (instancia != null)
                {
                    // Descriptografa os dados para exibi-los nos campos de texto
                    txtServidor.Text = CriptografiaHelper.Descriptografar(instancia.Servidor);
                    txtUsuario.Text = CriptografiaHelper.Descriptografar(instancia.Usuario);
                    txtSenha.Text = CriptografiaHelper.Descriptografar(instancia.Senha);
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // Pega a configuração atual para não perder outros dados como MemoriaMaxima
                var configAtual = ConfigManager.getConfig() ?? new Config.Config();

                // Pega a primeira instância ou cria uma nova se não existir
                var instancia = configAtual.Instancias.FirstOrDefault();
                if (instancia == null)
                {
                    instancia = new InstanciaServidor();
                    configAtual.Instancias.Add(instancia);
                }

                // Preenche o objeto com os dados da tela (em texto puro)
                instancia.Servidor = txtServidor.Text;
                instancia.Usuario = txtUsuario.Text;
                instancia.Senha = txtSenha.Text;
                instancia.NomeInstancia = "PRODUCAO"; // Valor padrão
                instancia.UltimaInstanciaUsada = true;

                // Chama o nosso método 'salvarConfig' que já sabe como criptografar
                ConfigManager.salvarConfig(configAtual);

                MessageBox.Show("Configurações salvas com sucesso!\n\nA aplicação será reiniciada para usar a nova conexão.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Força a reinicialização da aplicação para que o SessionFactory
                // use os novos dados de conexão.
                Application.Restart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao salvar as configurações: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
