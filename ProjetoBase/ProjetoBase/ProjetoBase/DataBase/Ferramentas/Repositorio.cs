// Importa as bibliotecas necessárias.
using NHibernate; // A biblioteca principal do NHibernate.
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBase.DataBase.Dominio; // Suas classes de entidade (ex: a classe base 'Entidade').
using ProjetoBase.DataBase.Dominio.Interface; // Suas interfaces de domínio.
using ProjetoBase.Enumeradores; // Seus enums (ex: EnumResultadoQuery).
using ProjetoBase.Ferramentas; // Outras ferramentas, como a SessionFactory.
using ProjetoBase.Formularios;

namespace ProjetoBase.DataBase.Ferramentas
{
    // Declara a classe genérica 'Repositorio'.
    // "ICrud<T>" significa que esta classe promete implementar todos os métodos definidos na interface ICrud.
    // "where T : class" é uma restrição que garante que o tipo 'T' seja sempre uma classe.
    public class Repositorio<T> : ICrud<T> where T : class
    {
        // Declara uma variável para a sessão do NHibernate. É o objeto que gerencia a conversa com o banco de dados.
        // É inicializada imediatamente pegando uma sessão da SessionFactory.
        ISession session = SessionFactory.Session();

        // --- MÉTODO SALVAR ---
        // Responsável por inserir um novo registro ou atualizar um existente.
        public EnumResultadoQuery Salvar(T entidade)
        {
            // Pega uma sessão do pool de sessões. 'false' indica para não limpar (flush) a sessão.
            ISession sessao = getSessao(false);

            // Inicia uma transação. Isso garante que as operações seguintes sejam tratadas como uma única unidade atômica.
            // Ou tudo funciona, ou nada é salvo no banco.
            using (ITransaction transaction = sessao.BeginTransaction())
            {
                // Bloco de código para registrar a operação em um log.
                //=============LOG==============
                // 'novo' controla se a operação é uma inserção (true) ou uma atualização (false).
                Boolean novo = false;
                // Verifica se a entidade que estamos salvando herda da classe base 'Entidade'.
                if (entidade is Entidade)
                {
                    // Converte o objeto para o tipo 'Entidade' para acessar a propriedade 'Codigo'.
                    Entidade Entidade = (Entidade)entidade;
                    // Uma convenção do sistema: se o código é "0", é um novo registro.
                    if (Entidade.Codigo == "0")
                    {
                        novo = true;
                    }
                }
                //=============LOG==============
                
                // Primeira tentativa para salvar.
                try
                {
                    // Pede ao NHibernate para fazer um INSERT (se o objeto é novo) ou um UPDATE (se já existe).
                    sessao.SaveOrUpdate(entidade);
                    // Se o comando acima não deu erro, confirma a transação, aplicando as mudanças no banco.
                    transaction.Commit();

                    // Bloco para salvar o log APÓS a transação ser confirmada com sucesso.
                    //=============LOG==============
                    if (entidade is Entidade)
                    {
                        Entidade Entidade = (Entidade)entidade;
                        salvarLogTransacao(entidade.GetType().Name, Entidade.Codigo, novo, false);
                    }
                    //=============LOG==============

                    // Verifica se a transação foi realmente efetivada no banco.
                    if (transaction.WasCommitted)
                    {
                        // Retorna um enum indicando sucesso.
                        return EnumResultadoQuery.SUCESSO;
                    }
                    else
                    {
                        // Se por algum motivo não foi efetivada, retorna erro.
                        return EnumResultadoQuery.ERRO_GENERICO;
                    }
                }
                // Se a primeira tentativa (try) falhar, o código entra no catch.
                catch
                {
                    // Se a transação ainda está aberta (não foi confirmada nem revertida).
                    if (!transaction.WasCommitted)
                    {
                        // Segunda tentativa, usando uma estratégia diferente.
                        try
                        {
                            // 'Merge' é uma alternativa ao 'SaveOrUpdate' que pode resolver problemas de "objetos duplicados" na sessão.
                            sessao.Merge(entidade);
                            // Tenta confirmar a transação novamente.
                            transaction.Commit();

                            // Se o Merge funcionou, salva o log.
                            //=============LOG==============
                            if (entidade is Entidade)
                            {
                                Entidade Entidade = (Entidade)entidade;
                                salvarLogTransacao(entidade.GetType().Name, Entidade.Codigo, novo, false);
                            }
                            //=============LOG==============

                            // Verifica se agora a transação foi confirmada.
                            if (transaction.WasCommitted)
                            {
                                return EnumResultadoQuery.SUCESSO;
                            }
                            else
                            {
                                return EnumResultadoQuery.ERRO_GENERICO;
                            }
                        }
                        // Se a segunda tentativa (com Merge) também falhar.
                        catch (Exception ex)
                        {
                            // Garante que a transação seja desfeita, para não deixar o banco em estado inconsistente.
                            if (!transaction.WasCommitted)
                            {
                                // Desfaz todas as mudanças que foram tentadas.
                                transaction.Rollback();
                                // Cancela a query atual na sessão.
                                sessao.CancelQuery();
                            }

                            // Analisa a mensagem de erro para dar uma resposta mais específica ao usuário.
                            if (ex.InnerException?.Message?.Contains("Nao é possivel deletar esta linha") == true)
                            {
                                return EnumResultadoQuery.TENTANTIVA_DE_DELETE;
                            }
                            else
                            {
                                // Se for outro tipo de erro, chama um método auxiliar para interpretá-lo.
                                return getResultadoExecao(ex);
                            }
                        }
                    }
                }
                // Se o código chegar aqui, algo deu errado.
                return EnumResultadoQuery.ERRO_GENERICO;
            }
        }
        
        // --- MÉTODO EXCLUIR ---
        // Responsável por remover um registro do banco de dados.
        public EnumResultadoQuery Excluir(T entidade)
        {
            ISession sessao = getSessao(false);
            using (ITransaction transaction = sessao.BeginTransaction())
            {
                try
                {
                    // Pede ao NHibernate para executar um comando DELETE para a entidade.
                    sessao.Delete(entidade);
                    // Confirma a transação para efetivar a exclusão.
                    transaction.Commit();

                    // Salva o log da exclusão.
                    //=============LOG==============
                    if (entidade is Entidade)
                    {
                        Entidade Entidade = (Entidade)entidade;
                        salvarLogTransacao(entidade.GetType().Name, Entidade.Codigo, false, true);
                    }
                    //=============LOG==============

                    // Se a transação foi confirmada, retorna o status de deletado.
                    if (transaction.WasCommitted)
                    {
                        return EnumResultadoQuery.DELETADO;
                    }
                    else
                    {
                        return EnumResultadoQuery.ERRO_GENERICO;
                    }
                }
                // Se ocorrer um erro durante a exclusão.
                catch (Exception ex)
                {
                    // Desfaz a transação.
                    if (!transaction.WasCommitted)
                    {
                        transaction.Rollback();
                        sessao.CancelQuery();
                    }
                    // Retorna um resultado de erro interpretado.
                    return getResultadoExecao(ex);
                }
            }
        }
        
        // --- MÉTODOS DE BUSCA ---

        // Procura um objeto pelo seu identificador único (ID).
        public T ProcurarPorID(Object id)
        {
            if (id != null)
            {
                try
                {
                    // O NHibernate pode lidar com diferentes tipos de ID (int, string, etc.).
                    // Este bloco tenta descobrir o tipo correto do ID para fazer a busca.
                    int idInt = 0;
                    Boolean numero = int.TryParse(id.ToString(), out idInt);
                    bool eEnum = id is Enum;

                    if (numero && id is String == false)
                    {
                        // Se o ID é um número, usa o método Get<T>(int).
                        return getSessao(false).Get<T>(idInt);
                    }
                    else if (eEnum)
                    {
                        // Se o ID é um enum, converte para int.
                        return getSessao(false).Get<T>(Convert.ToInt32(id));
                    }
                    else
                    {
                        // Caso contrário, trata como string.
                        return getSessao(false).Get<T>(id.ToString());
                    }
                }
                catch
                {
                    // Se houver qualquer erro na conversão, tenta buscar como string como último recurso.
                    try { return getSessao(false).Get<T>(id.ToString()); }
                    catch { return null; }
                }
            }
            else
            {
                return null;
            }
        }

        // Busca um único registro. Por convenção, busca o registro com ID = 1.
        // Útil para tabelas de configuração que só têm uma linha.
        public T Procurar()
        {
            try { return getSessao(false).Get<T>(1); }
            catch { return null; }
        }

        // Retorna uma lista com TODOS os registros de uma tabela.
        public IList<T> getLista()
        {
            // Usa a API QueryOver do NHibernate para criar e executar um "SELECT * FROM Tabela".
            return getSessao(false).QueryOver<T>().List();
        }

        // --- MÉTODOS DE GERENCIAMENTO DE SESSÃO ---

        // Remove o "proxy" do NHibernate e retorna o objeto real.
        public T UnProxyObjectAs(object obj)
        {
            try { NHibernateUtil.Initialize(obj); }
            catch { }
            return (T)getSessao(false).GetSessionImplementation().PersistenceContext.UnproxyAndReassociate(obj);
        }

        // Carrega um objeto na sessão pelo seu ID sem necessariamente buscar todos os dados.
        public void LoadObjetoNaSessao(object obj, object id)
        {
            try { getSessao(false).Load(obj, id); }
            catch { }
        }

        // Remove um objeto do cache de primeiro nível da sessão do NHibernate.
        public void Evict(object obj)
        {
            ISession sessao = getSessao(false);
            using (ITransaction transaction = sessao.BeginTransaction())
            {
                try
                {
                    if (sessao.Contains(obj))
                    {
                        sessao.Evict(obj);
                    }
                }
                catch (Exception)
                {
                    if (!transaction.WasCommitted)
                    {
                        transaction.Rollback();
                        sessao.CancelQuery();
                    }
                }
            }
        }

        // Atualiza o estado de um objeto na memória com os dados mais recentes do banco de dados.
        public void Refresh(object obj)
        {
            ISession sessao = getSessao(false);
            using (ITransaction transaction = sessao.BeginTransaction())
            {
                try { sessao.Refresh(obj); }
                catch (Exception)
                {
                    if (!transaction.WasCommitted)
                    {
                        transaction.Rollback();
                        sessao.CancelQuery();
                    }
                }
            }
        }

        // Método central para obter a sessão do NHibernate.
        public ISession getSessao(Boolean Flushed)
        {
            // Se for pedido um "flush" ou se a sessão atual estiver fechada, cria uma nova.
            if (Flushed || session.IsOpen == false)
            {
                session = SessionFactory.Session();
                session.Flush(); // Envia as alterações pendentes para o banco.
                session.Clear(); // Limpa o cache da sessão.
            }
            else
            {
                // Caso contrário, reutiliza a sessão existente.
                session = SessionFactory.UnflushedSession();
            }
            return session;
        }
        
        // --- MÉTODOS AUXILIARES ---

        // "Traduz" exceções do banco de dados para enums mais amigáveis.
        public EnumResultadoQuery getResultadoExecao(Exception ex)
        {
            EnumResultadoQuery resultado = EnumResultadoQuery.ERRO_GENERICO;
            if (ex != null)
            {
                // Se o erro for de chave estrangeira (tentando deletar algo que está em uso).
                if (ex.InnerException != null && ex.InnerException.Message != null && ex.InnerException.Message.Contains("violation of FOREIGN KEY constraint"))
                {
                    resultado = EnumResultadoQuery.OBJETO_REFERENCIADO;
                }
                // Se o erro for de objeto duplicado na sessão.
                else if (ex.Message != null && ex.Message.Contains("different object with the same identifier"))
                {
                    resultado = EnumResultadoQuery.PK_DUPLICADO;
                }
            }
            return resultado;
        }

        // Salva um registro de auditoria na tabela 'Log_Transacao'.
        public void salvarLogTransacao(String classe, String id, Boolean novo, Boolean excluir)
        {
            try
            {
                // Cria uma consulta SQL nativa.
                var query = SessionFactory.UnflushedSession().CreateSQLQuery("INSERT INTO Log_Transacao (Classe, IdClasse, Data, Responsavel_id, Novo, Excluir) VALUES (:Classe, :IdClasse, :Data, :Responsavel_id, :Novo, :Excluir)");
                // Define os parâmetros da consulta.
                query.SetParameter("Classe", classe);
                query.SetParameter("IdClasse", id);
                query.SetParameter("Data", DateTime.Now);
                query.SetParameter("Responsavel_id", SessaoSistema.funcionario.Id);
                query.SetParameter("Novo", novo);
                query.SetParameter("Excluir", excluir);
                // Executa o comando.
                query.UniqueResult();
            }
            catch
            {
                // O log não deve impedir o funcionamento do sistema, então qualquer erro aqui é ignorado.
            }
        }
    }
}