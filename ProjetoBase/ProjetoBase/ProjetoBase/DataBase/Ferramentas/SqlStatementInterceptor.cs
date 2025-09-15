using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Diagnostics;

namespace ProjetoBase.DataBase.Ferramentas
{


    [Serializable]
    public class SqlStatementInterceptor : EmptyInterceptor
    {
        public override NHibernate.SqlCommand.SqlString OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
        {
            Console.WriteLine(sql.ToString());
            return sql;
        }
    }
}
