using ProjetoBase.Config;
using System.Linq;

namespace ProjetoBase.Ferramentas
{
    /// <summary>
    /// Classe estática para gerir as configurações da aplicação.
    /// Agora lê e salva os dados de conexão de forma segura.
    /// </summary>
    public static class ConfigManager
    {
        public static decimal MemoriaMaxima = 1;
        public static Config.Config config = null;

        public static Config.Config getConfig()
        {
            if (config == null)
            {
                config = new Config.Config();
                config = (Config.Config)Serializacao.Deserializar(config, "Config");

                if (config != null)
                {
                    MemoriaMaxima = config.MemoriaMaxima;
                }
            }
            return config;
        }

        /// <summary>
        /// Salva o objeto de configuração, criptografando a senha antes de gravar.
        /// </summary>
        public static void salvarConfig(Config.Config configParaSalvar)
        {
            // Cria uma cópia profunda para não alterar o objeto em memória
            Config.Config copiaSegura = configParaSalvar.Clone();

            foreach (var instancia in copiaSegura.Instancias)
            {
                // --- CORREÇÃO APLICADA AQUI ---
                // Apenas a senha é criptografada antes de ser salva.
                instancia.Senha = CriptografiaHelper.Criptografar(instancia.Senha);
            }

            Serializacao.Serializar(copiaSegura, "Config");
            config = configParaSalvar; // Atualiza a configuração em memória
        }

        /// <summary>
        /// Monta a string de conexão, descriptografando a senha lida do arquivo.
        /// </summary>
        public static string getConnectionString()
        {
            Config.Config config = getConfig();
            if (config?.Instancias == null || !config.Instancias.Any())
            {
                // Retorna nulo ou lança uma exceção se nenhuma configuração for encontrada
                return null;
            }

            InstanciaServidor instancia = config.Instancias.FirstOrDefault(x => x.UltimaInstanciaUsada);
            if (instancia == null)
            {
                instancia = config.Instancias.FirstOrDefault();
            }
            if (instancia == null)
            {
                return null;
            }

            // --- CORREÇÃO APLICADA AQUI ---
            // O servidor e o utilizador são lidos como texto puro.
            string servidor = instancia.Servidor;
            string usuario = instancia.Usuario;
            // Apenas a senha é descriptografada.
            string senha = CriptografiaHelper.Descriptografar(instancia.Senha);

            // Monta a string de conexão com os dados corretos.
            return $"Server={servidor};Database=PROJETO_BASE;User Id={usuario};Password={senha};Connection Timeout=0;";
        }

        public static void setConfig(Config.Config configExistente)
        {
            config = configExistente;
        }
    }
}