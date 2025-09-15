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
    class PerfilDeAcessoMap : ClassMap<PerfilDeAcesso>
    {
        public PerfilDeAcessoMap()
        {            
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Nome);
            HasManyToMany(x => x.NivelDeAcesso).ParentKeyColumn("PERFIL_ACESSO_ID").ChildKeyColumn("NIVEL_ACESSO_ID").Table("NIVEIS_PERFIL_DE_ACESSO").Cascade.All();

            Table("PERFIL_DE_ACESSO");
        }
    }
}
