using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBase.DataBase.Dominio;
using ProjetoBase.DataBase.Dominio.Funcionario;

namespace ProjetoBase.DataBase.Mapeamento
{
    class SessaoLoginMap : ClassMap<SessaoLogin>
    {
        public SessaoLoginMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            References(x => x.Funcionario, "FUNCIONARIO_ID").Cascade.None();
            Map(x => x.Login);
            Map(x => x.Logout);
            Map(x => x.EncerradaSemLogout);
            Table("SESSAO_LOGIN");
        }
    }
}
