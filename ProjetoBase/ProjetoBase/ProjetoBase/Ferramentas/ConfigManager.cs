using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg.Db;
using System.Windows.Forms;
// Importa o namespace que contém a classe 'Config', que modela as configurações.
using ProjetoBase.Config;

namespace ProjetoBase.Ferramentas
{
    // Classe estática para gerenciar as configurações da aplicação.
    public static class ConfigManager
    {
        // Variável estática para guardar o limite de memória. O valor '1' é um padrão.
        // Pode ser acessada de qualquer lugar (ex: ConfigManager.MemoriaMaxima).
        public static Decimal MemoriaMaxima = 1;

        // Esta é a variável estática que vai guardar o objeto de configuração depois de carregado.
        // Começa como 'null' e só é carregada do arquivo uma vez (padrão Singleton).
        public static Config.Config config = null;


        // Método principal para obter o objeto de configuração.
        public static Config.Config getConfig()
        {
            // Verifica se a configuração ainda não foi carregada para a memória.
            if (config == null)
            {
                // Se for nula, cria uma nova instância vazia do objeto de configuração.
                config = new Config.Config();
                
                // A "mágica" acontece aqui. Chama uma outra classe, 'Serializacao', para
                // ler um arquivo (provavelmente chamado "Config.xml" ou "Config.json") e
                // preencher o objeto 'config' com os dados salvos. Isso é "Deserialização".
                config = (Config.Config)Serializacao.Deserializar(config, "Config");

                // Se a deserialização funcionou e o objeto 'config' foi carregado com sucesso...
                if (config != null)
                {
                    // ...atualiza a variável estática 'MemoriaMaxima' com o valor que veio do arquivo.
                    MemoriaMaxima = config.MemoriaMaxima;
                }
            }

            // Retorna o objeto de configuração (seja o que acabou de ser carregado ou o que já estava em memória).
            return config;
        }

        // Uma sobrecarga do método anterior. Este permite carregar uma configuração de um arquivo específico,
        // em vez de usar o padrão "Config". Útil para testes ou cenários especiais.
        public static Config.Config getConfig(String caminhoConfig)
        {
            Config.Config config = new Config.Config();
            config = (Config.Config)Serializacao.Deserializar(config, caminhoConfig);
            return config;
        }

        // Método para salvar o objeto de configuração de volta para o arquivo.
        public static void salvarConfig(Config.Config config)
        {
            // Usa a classe 'Serializacao' para converter o objeto 'config' em texto
            // e salvá-lo no arquivo "Config". Isso é "Serialização".
            Serializacao.Serializar(config, "Config");
        }

        // Este método é o que vimos na nossa conversa anterior!
        // Ele constrói a string de conexão com o banco de dados.
        public static String getConnectionString()
        {
            String stringConexao = null;

            // Garante que as configurações estejam carregadas na memória.
            Config.Config config = getConfig();

            // Procura na lista de instâncias de servidor salvas no arquivo de configuração
            // aquela que está marcada como a "última usada". Isso permite que o sistema
            // "lembre" do último servidor ao qual se conectou.
            InstanciaServidor instancia = config?.Instancias?.Where(x => x.UltimaInstanciaUsada).SingleOrDefault();
            
            // Monta a string de conexão dinamicamente com os dados encontrados (servidor, usuário, senha).
            stringConexao = "Server=" + instancia?.Servidor + ";Database=PROJETO_BASE;User=" + (instancia?.Usuario) + ";Password=" + instancia?.Senha + ";Connection Timeout=0;";

            // Retorna a string de conexão pronta para ser usada pelo NHibernate.
            return stringConexao;
        }

        // Um método "setter" que permite substituir o objeto de configuração em memória
        // por um outro objeto já existente.
        public static void setConfig(Config.Config configExistente)
        {
            config = configExistente;
        }
    }
}