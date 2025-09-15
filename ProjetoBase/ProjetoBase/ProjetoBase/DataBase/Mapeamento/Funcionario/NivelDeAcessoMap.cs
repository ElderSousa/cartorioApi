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
    class NivelDeAcessoMap : ClassMap<NivelDeAcesso>
    {
        public NivelDeAcessoMap()
        {
            Id(x => x.Id).GeneratedBy.Assigned();
            Map(x => x.Nome);
            Table("NIVEL_DE_ACESSO");            
        }
    }
}
