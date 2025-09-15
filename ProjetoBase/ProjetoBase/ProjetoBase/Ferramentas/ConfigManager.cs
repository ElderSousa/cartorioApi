using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg.Db;
using System.Windows.Forms;
using ProjetoBase.Config;

namespace ProjetoBase.Ferramentas
{
    public static class ConfigManager
    {
        public static Decimal MemoriaMaxima = 1;

        public static Config.Config config = null;


        //Retorna um objeto de configuração
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
        public static Config.Config getConfig(String caminhoConfig)
        {

            Config.Config config = new Config.Config();
            config = (Config.Config)Serializacao.Deserializar(config, caminhoConfig);

            return config;
        }

        //Salva o objeto de configuração
        public static void salvarConfig(Config.Config config)
        {
            Serializacao.Serializar(config, "Config");
        }

        public static String getConnectionString()
        {
            String stringConexao = null;

            Config.Config config = getConfig();

            InstanciaServidor instancia = config?.Instancias?.Where(x => x.UltimaInstanciaUsada).SingleOrDefault();
            stringConexao = "Server=" + instancia?.Servidor + ";Database=PROJETO_BASE;User=" + (instancia?.Usuario) + ";Password=" + instancia?.Senha + ";Connection Timeout=0;";

            return stringConexao;
        }


        public static void setConfig(Config.Config configExistente)
        {
            config = configExistente;
        }
    }
}
