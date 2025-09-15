using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.AdoNet;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoBase.DataBase.Dominio;
using ProjetoBase.DataBase.Dominio.Funcionario;
using ProjetoBase.DataBase.Ferramentas;
using ProjetoBase.DataBase.Mapeamento;
using ProjetoBase.Ferramentas;
using ProjetoBase.Formularios.Ferramentas;

namespace ProjetoBase.DataBase
{
    public static class SessionFactory
    {
        static ISessionFactory isessionFactory = null;
        static ISession sessao = null;

        public static String caminhoCFG = "nh.cfg";

        //Retorna uma sessão
        public static ISession Session()
        {
            return getSession(true);
        }

        public static ISession UnflushedSession()
        {
            return getSession(false);
        }


        private static ISession getSession(Boolean flushed)
        {
            //--------------------------------GERAR CONEXAO-----------------------------------
            try
            {
                if (isessionFactory == null)
                {

                    isessionFactory = Fluently.Configure(getConfigPorCacheOuGerar()).BuildSessionFactory();
                    //ProcessoLogin.processando = "Configurando Sessão";
                }


                if (sessao == null || sessao.IsOpen == false)
                {
                    sessao = isessionFactory.OpenSession();
                  //  ProcessoLogin.processando = "Abrindo Sessão";
                }

                if (flushed)
                {
                    sessao?.Clear();
                    sessao?.Flush();
                }

            }
            catch
            {

            }

            //-----------------------------TESTAR CONEXAO---------------------------------
            try
            {
                sessao.CreateSQLQuery("SELECT 1").UniqueResult();
            }
            catch
            {
                if (ReconectarBanco.reconectar() == false && ReconectarBanco.janelaAberta() == false)
                {
                    Application.Exit();
                }
            }

            return sessao;
        }

        public static ISession newDetachedSession()
        {
            //--------------------------------GERAR CONEXAO-----------------------------------
            try
            {
                if (isessionFactory == null)
                {

                    isessionFactory = Fluently.Configure(getConfigPorCacheOuGerar()).BuildSessionFactory();
                }
                var sessaoNova = isessionFactory.OpenSession();
                return sessaoNova;
            }
            catch
            {
                return null;
            }         

        }

        //Procurar uma configuração existente, caso não exista uma nova configuração será gerada
        private static Configuration getConfigPorCacheOuGerar()
        {
            Configuration nhConfigurationCache;

            var nhCfgCache = new ConfigurationFileCache(Assembly.Load("ProjetoBase"), caminhoCFG);
             var cachedCfg = nhCfgCache.LoadConfigurationFromFile();
            if (cachedCfg == null)
            {
               // ProcessoLogin.processando = "Configurando Sistema... Aguarde";
                nhConfigurationCache = Fluently.Configure()
                                   .Database(
                                         MsSqlConfiguration.MsSql2012.ConnectionString(ConfigManager.getConnectionString()))
                                         .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CargoMap>())
                                         .ExposeConfiguration(cfg =>
                                         {
                                             cfg.SetProperty("command_timeout", "300");

                                             new SchemaUpdate(cfg).Execute(true, true);
                                             cfg.DataBaseIntegration(prop => { prop.BatchSize = 20; prop.Driver<SqlClientDriver>(); });

                                             //cfg.SetInterceptor(new SqlStatementInterceptor());  
                                         }
                                         )

                                         .BuildConfiguration();

                nhCfgCache.SaveConfigurationToFile(nhConfigurationCache);
            }
            else
            {

                //ProcessoLogin.processando = "Inicializando Conexão";
                nhConfigurationCache = cachedCfg;
            }
            return nhConfigurationCache;
        }

    }
}
