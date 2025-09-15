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
    class NivelDeAcessoDinamicoMap : ClassMap<NivelDeAcessoDinamico>
    {
        public NivelDeAcessoDinamicoMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Nome);
            Map(x => x.Acao);
            Map(x => x.DataCadastro);
            References(x => x.CadastradoPor, "CADASTRADO_POR_ID").Cascade.None();
            HasManyToMany(x => x.Funcionarios).ParentKeyColumn("NIVEL_DE_ACESSO_DINAMICO_ID").ChildKeyColumn("FUNCIONARIO_ID").Table("NIVEL_ACESSO_DINAMICO_FUNCIONARIOS");
            Table("NIVEL_DE_ACESSO_DINAMICO");            
        }
    }
}
