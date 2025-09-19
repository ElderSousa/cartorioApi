// Importa todas as bibliotecas (dependências) necessárias para o funcionamento da classe.
// FluentNHibernate é usado para configurar o NHibernate usando código C# de forma fluente.
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
// NHibernate é o ORM (Object-Relational Mapper) principal.
using NHibernate;
using NHibernate.AdoNet;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Driver;
// hbm2ddl é a ferramenta para manipular o esquema do banco de dados (criar/atualizar tabelas).
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
// Dependência para interagir com a interface gráfica (ex: Application.Exit()).
using System.Windows.Forms;
// Importa as classes de domínio (entidades) e outras ferramentas do próprio projeto.
using ProjetoBase.DataBase.Dominio;
using ProjetoBase.DataBase.Dominio.Funcionario;
using ProjetoBase.DataBase.Ferramentas;
using ProjetoBase.DataBase.Mapeamento;
using ProjetoBase.Ferramentas;
using ProjetoBase.Formularios.Ferramentas;

// Namespace onde a classe está localizada.
namespace ProjetoBase.DataBase
{
    // A classe é 'static', o que significa que não pode ser instanciada. 
    // Seus membros e métodos são acessados diretamente (ex: SessionFactory.Session()).
    public static class SessionFactory
    {
        // Declaração das variáveis estáticas. Elas manterão seu valor durante toda a execução do programa.
        
        // 'isessionFactory' é a "fábrica de sessões". É um objeto pesado e caro de criar.
        // A ideia é criá-lo apenas uma vez e reutilizá-lo.
        static ISessionFactory isessionFactory = null;

        // 'sessao' é a sessão de comunicação com o banco de dados. É através dela que
        // as operações de salvar, buscar, deletar, etc., são realizadas.
        static ISession sessao = null;

        // 'caminhoCFG' define o nome do arquivo de cache para a configuração do NHibernate.
        // Isso acelera a inicialização do programa nas próximas vezes que ele for aberto.
        public static String caminhoCFG = "nh.cfg";

        // Método público principal para obter uma sessão.
        // Retorna uma sessão "limpa" (flushed).
        public static ISession Session()
        {
            // Chama o método privado, passando 'true' para indicar que a sessão deve ser limpa.
            return getSession(true);
        }

        // Método público para obter a sessão atual sem limpá-la.
        // Útil quando várias operações precisam ser feitas na mesma transação sem interferência.
        public static ISession UnflushedSession()
        {
            // Chama o método privado, passando 'false' para não limpar a sessão.
            return getSession(false);
        }
        
        // Este é o coração da classe. Ele gerencia a criação e manutenção da sessão.
        private static ISession getSession(Boolean flushed)
        {
            // --- ETAPA 1: GERAR A CONEXÃO E A SESSÃO ---
            try
            {
                // Verifica se a fábrica de sessões já foi criada.
                if (isessionFactory == null)
                {
                    // Se não foi, cria a fábrica. A função 'getConfigPorCacheOuGerar()' faz o trabalho pesado
                    // de configurar o NHibernate, usando um cache para acelerar o processo.
                    isessionFactory = Fluently.Configure(getConfigPorCacheOuGerar()).BuildSessionFactory();
                }

                // Verifica se a sessão não existe ou se foi fechada por algum motivo.
                if (sessao == null || sessao.IsOpen == false)
                {
                    // Se a sessão não está disponível, abre uma nova usando a fábrica.
                    sessao = isessionFactory.OpenSession();
                }

                // Se o parâmetro 'flushed' for verdadeiro...
                if (flushed)
                {
                    // sessao?.Clear(): Limpa o cache de primeiro nível do NHibernate. Remove todos os objetos monitorados.
                    // sessao?.Flush(): Sincroniza as alterações pendentes (inserts, updates, deletes) com o banco de dados.
                    // O '?' é um operador de "null-conditional", que evita erro se 'sessao' for nula.
                    sessao?.Clear();
                    sessao?.Flush();
                }
            }
            catch
            {
                // Bloco catch vazio. Se ocorrer um erro na criação da sessão, ele é ignorado aqui,
                // mas provavelmente será pego na etapa de teste de conexão abaixo.
            }

            // --- ETAPA 2: TESTAR SE A CONEXÃO AINDA ESTÁ ATIVA ---
            try
            {
                // Executa uma consulta SQL muito simples e rápida ("SELECT 1") para verificar se a conexão
                // com o banco de dados ainda é válida. Se o banco caiu ou a rede falhou, isso vai gerar uma exceção.
                sessao.CreateSQLQuery("SELECT 1").UniqueResult();
            }
            catch
            {
                // Se a consulta de teste falhou, a conexão foi perdida.
                // Tenta reconectar chamando uma classe 'ReconectarBanco'.
                // Se a reconexão falhar E a janela de reconexão não estiver aberta,
                // o programa é encerrado para evitar mais erros.
                if (ReconectarBanco.reconectar() == false && ReconectarBanco.janelaAberta() == false)
                {
                    Application.Exit();
                }
            }

            // Finalmente, retorna a sessão, que agora está (esperançosamente) pronta para uso.
            return sessao;
        }

        // Método para criar uma sessão completamente nova e independente da sessão principal.
        // Útil para tarefas em background ou operações que não devem interferir na sessão global.
        public static ISession newDetachedSession()
        {
            try
            {
                // Garante que a fábrica de sessões exista.
                if (isessionFactory == null)
                {
                    isessionFactory = Fluently.Configure(getConfigPorCacheOuGerar()).BuildSessionFactory();
                }
                // Abre e retorna uma sessão totalmente nova, sem armazená-la na variável estática 'sessao'.
                var sessaoNova = isessionFactory.OpenSession();
                return sessaoNova;
            }
            catch
            {
                // Se algo der errado, retorna null.
                return null;
            }
        }

        // Método responsável por carregar ou criar a configuração do NHibernate.
        // É aqui que a "mágica" da otimização acontece.
        private static Configuration getConfigPorCacheOuGerar()
        {
            Configuration nhConfigurationCache;

            // Cria um objeto para gerenciar o cache da configuração em um arquivo.
            var nhCfgCache = new ConfigurationFileCache(Assembly.Load("ProjetoBase"), caminhoCFG);
            
            // Tenta carregar a configuração a partir do arquivo de cache (nh.cfg).
            var cachedCfg = nhCfgCache.LoadConfigurationFromFile();

            // Se a configuração não foi encontrada no cache (primeira vez que o programa roda ou o cache foi deletado)...
            if (cachedCfg == null)
            {
                // ...então, cria a configuração do zero. Este é o processo lento.
                nhConfigurationCache = Fluently.Configure()
                    // 1. Configura o Banco de Dados
                    .Database(
                        // Especifica que é um SQL Server 2012 e pega a string de conexão de um 'ConfigManager'.
                        MsSqlConfiguration.MsSql2012.ConnectionString(ConfigManager.getConnectionString())
                    )
                    // 2. Configura os Mapeamentos
                    .Mappings(m => 
                        // Diz ao NHibernate para encontrar todas as classes de mapeamento (como CargoMap)
                        // no mesmo assembly (projeto) onde 'CargoMap' está.
                        m.FluentMappings.AddFromAssemblyOf<CargoMap>()
                    )
                    // 3. Expõe configurações avançadas do NHibernate.
                    .ExposeConfiguration(cfg =>
                    {
                        // Define um tempo limite de 300 segundos para os comandos SQL.
                        cfg.SetProperty("command_timeout", "300");

                        // ATENÇÃO: Esta linha é muito poderosa e potencialmente perigosa.
                        // 'new SchemaUpdate(cfg).Execute(true, true)' compara o mapeamento do código C# com o banco de
                        // dados e AUTOMATICAMENTE cria/altera tabelas e colunas para que correspondam.
                        // Ótimo para desenvolvimento, mas arriscado em produção.
                        new SchemaUpdate(cfg).Execute(true, true);
                        
                        // Configurações de integração com o banco de dados.
                        cfg.DataBaseIntegration(prop => { 
                            prop.BatchSize = 20; // Define o tamanho do lote para operações em massa.
                            prop.Driver<SqlClientDriver>(); // Especifica o driver do SQL Server.
                        });
                    })
                    // Constrói o objeto de configuração final.
                    .BuildConfiguration();

                // Salva a configuração recém-criada no arquivo de cache para uso futuro.
                nhCfgCache.SaveConfigurationToFile(nhConfigurationCache);
            }
            else // Se a configuração foi carregada com sucesso do cache...
            {
                // ...simplesmente usa a configuração do cache. Isso é muito mais rápido.
                nhConfigurationCache = cachedCfg;
            }
            
            // Retorna a configuração pronta para ser usada para criar a ISessionFactory.
            return nhConfigurationCache;
        }
    }
}