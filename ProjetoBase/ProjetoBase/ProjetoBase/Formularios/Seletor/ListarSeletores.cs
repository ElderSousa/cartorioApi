using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using NHibernate.Transform;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBase.DataBase;
using ProjetoBase.DataBase.Dominio;
using ProjetoBase.DataBase.Dominio.Funcionario;
using ProjetoBase.DataBase.Dominio.Interface;

using ProjetoBase.DataBase.Ferramentas;
using ProjetoBase.Enumeradores;
using ProjetoBase.Ferramentas;

namespace ProjetoBase.Formularios
{
    public static class ListarSeletores
    {
        static ISession session = null;

        public static IList<Cargo> getListaCargo(String filtro)
        {
            IList<Cargo> lista = getSessao().QueryOver<Cargo>().Where(x => x.Id == convertFromString(filtro) || x.Nome.IsInsensitiveLike(filtro, MatchMode.Anywhere)).List();
            return lista;
        }

      
        public static ISession getSessao()
        {
            if (session == null || session.IsOpen == false)
            {
                session = SessionFactory.UnflushedSession();
            }
            return session;
        }

        public static int convertFromString(String valor)
        {
            int valorConvertido = 0;
            try
            {
                Int32.TryParse(valor, out valorConvertido);
                //valorConvertido = Convert.ToInt32(valor);
            }
            catch
            {

            }
            return valorConvertido;
        }
    }
}
