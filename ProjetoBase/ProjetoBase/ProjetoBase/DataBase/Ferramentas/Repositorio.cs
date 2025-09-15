using NHibernate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBase.DataBase.Dominio;
using ProjetoBase.DataBase.Dominio.Interface;
using ProjetoBase.Enumeradores;
using ProjetoBase.Ferramentas;
using ProjetoBase.Formularios;

namespace ProjetoBase.DataBase.Ferramentas
{
    public class Repositorio<T> : ICrud<T> where T : class
    {
        ISession session = SessionFactory.Session();

        public EnumResultadoQuery Salvar(T entidade)
        {
            ISession sessao = getSessao(false);

            using (ITransaction transaction = sessao.BeginTransaction())
            { 
                //=============LOG==============
                Boolean novo = false;
                if (entidade is Entidade)
                {
                    Entidade Entidade = (Entidade)entidade;
                    if (Entidade.Codigo == "0")
                    {
                        novo = true;
                    }
                }
                //=============LOG==============
                try
                {                  
                    sessao.SaveOrUpdate(entidade);
                    transaction.Commit();

                    //=============LOG==============
                    if (entidade is Entidade)
                    {
                        Entidade Entidade = (Entidade)entidade;
                        salvarLogTransacao(entidade.GetType().Name, Entidade.Codigo, novo, false);
                    }
                    //=============LOG==============

                    
                    if (transaction.WasCommitted)
                    {
                        return EnumResultadoQuery.SUCESSO;
                    }
                    else
                    {
                        return EnumResultadoQuery.ERRO_GENERICO;
                    }
                }
                catch
                {
                    if (!transaction.WasCommitted)
                    {
                        try
                        {
                            sessao.Merge(entidade);
                            transaction.Commit();

                            //=============LOG==============
                            if (entidade is Entidade)
                            {
                                Entidade Entidade = (Entidade)entidade;
                                salvarLogTransacao(entidade.GetType().Name, Entidade.Codigo, novo, false);
                            }
                            //=============LOG==============

                            if (transaction.WasCommitted)
                            {
                                return EnumResultadoQuery.SUCESSO;
                            }
                            else
                            {
                                return EnumResultadoQuery.ERRO_GENERICO;
                            }
                        }
                        catch (Exception ex)
                        {
                            if (!transaction.WasCommitted)
                            {
                                transaction.Rollback();
                                sessao.CancelQuery();
                            }

                            if (ex.InnerException?.Message?.Contains("Nao é possivel deletar esta linha") == true)
                            {
                                return EnumResultadoQuery.TENTANTIVA_DE_DELETE;
                            }
                            else
                            {
                                return getResultadoExecao(ex);
                            }
                        }
                    }
                }
                return EnumResultadoQuery.ERRO_GENERICO;
            }
        }


        public EnumResultadoQuery Excluir(T entidade)
        {
            ISession sessao = getSessao(false);
            using (ITransaction transaction = sessao.BeginTransaction())
            {
                try
                {
                    sessao.Delete(entidade);
                    transaction.Commit();

                    //=============LOG==============
                    if (entidade is Entidade)
                    {
                        Entidade Entidade = (Entidade)entidade;
                        salvarLogTransacao(entidade.GetType().Name, Entidade.Codigo, false, true);
                    }
                    //=============LOG==============

                    if (transaction.WasCommitted)
                    {
                        return EnumResultadoQuery.DELETADO;
                    }
                    else
                    {
                        return EnumResultadoQuery.ERRO_GENERICO;
                    }
                }
                catch (Exception ex)
                {
                    if (!transaction.WasCommitted)
                    {
                        transaction.Rollback();
                        sessao.CancelQuery();
                    }
                    return getResultadoExecao(ex);
                }

            }
        }

        public T ProcurarPorID(Object id)
        {
            if (id != null)
            {
                try
                {
                    int idInt = 0;
                    Boolean numero = int.TryParse(id.ToString(), out idInt);

                    bool eEnum = id is Enum;

                    if (numero && id is String == false)
                    {
                        return getSessao(false).Get<T>(idInt);
                    }
                    else if (eEnum)
                    {
                        return getSessao(false).Get<T>(Convert.ToInt32(id));
                    }
                    else
                    {
                        return getSessao(false).Get<T>(id.ToString());
                    }
                }
                catch
                {
                    try
                    {
                        return getSessao(false).Get<T>(id.ToString());
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }
        }

        public T Procurar()
        {
            try
            {
                return getSessao(false).Get<T>(1);
            }
            catch
            {
                return null;
            }
        }

        public IList<T> getLista()
        {
            return getSessao(false).QueryOver<T>().List();
        }

        public T UnProxyObjectAs(object obj)
        {
            try
            {
                NHibernateUtil.Initialize(obj);
            }
            catch
            {
            }
            return (T)getSessao(false).GetSessionImplementation().PersistenceContext.UnproxyAndReassociate(obj);
        }

        public void LoadObjetoNaSessao(object obj, object id)
        {
            try
            {
                getSessao(false).Load(obj, id);
            }
            catch
            {
            }
        }

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
                catch (Exception ex)
                {
                    if (!transaction.WasCommitted)
                    {
                        transaction.Rollback();
                        sessao.CancelQuery();
                    }
                }
            }
        }

        public void Refresh(object obj)
        {
            ISession sessao = getSessao(false);

            using (ITransaction transaction = sessao.BeginTransaction())
            {
                try
                {
                    sessao.Refresh(obj);
                }
                catch (Exception ex)
                {
                    if (!transaction.WasCommitted)
                    {
                        transaction.Rollback();
                        sessao.CancelQuery();
                    }
                }
            }
        }

        public ISession getSessao(Boolean Flushed)
        {
            if (Flushed || session.IsOpen == false)
            {
                session = SessionFactory.Session();
                session.Flush();
                session.Clear();
            }
            else
            {
                session = SessionFactory.UnflushedSession();
            }
            return session;
        }

        public EnumResultadoQuery getResultadoExecao(Exception ex)
        {
            EnumResultadoQuery resultado = EnumResultadoQuery.ERRO_GENERICO;

            if (ex != null)
            {
                if (ex.InnerException != null && ex.InnerException.Message != null && ex.InnerException.Message.Contains("violation of FOREIGN KEY constraint"))
                {
                    resultado = EnumResultadoQuery.OBJETO_REFERENCIADO;
                }
                else if (ex.Message != null && ex.Message.Contains("different object with the same identifier"))
                {
                    resultado = EnumResultadoQuery.PK_DUPLICADO;
                }
            }
            return resultado;
        }


        public void salvarLogTransacao(String classe, String id, Boolean novo, Boolean excluir)
        {
            try
            {
                var query = SessionFactory.UnflushedSession().CreateSQLQuery("INSERT INTO Log_Transacao (Classe, IdClasse, Data, Responsavel_id, Novo, Excluir) VALUES (:Classe, :IdClasse, :Data, :Responsavel_id, :Novo, :Excluir)");
                query.SetParameter("Classe", classe);
                query.SetParameter("IdClasse", id);
                query.SetParameter("Data", DateTime.Now);
                query.SetParameter("Responsavel_id", SessaoSistema.funcionario.Id);
                query.SetParameter("Novo", novo);
                query.SetParameter("Excluir", excluir);
                query.UniqueResult();
            }
            catch
            {

            }
        }

    }
}
