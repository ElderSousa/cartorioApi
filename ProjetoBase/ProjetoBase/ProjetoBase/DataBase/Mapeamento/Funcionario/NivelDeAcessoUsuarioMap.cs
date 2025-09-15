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
    class NivelDeAcessoUsuarioMap : ClassMap<NivelDeAcessoUsuario>
    {
        public NivelDeAcessoUsuarioMap()
        {
            Id(x => x.Id).GeneratedBy.Native("GEN_NIVEL_ACESSO_USUARIO_ID");
            References(x => x.NivelAcesso, "NIVEL_ACESSO_ID").Cascade.None();
            Table("NIVEL_DE_ACESSO_USUARIO");            
        }
    }
}
