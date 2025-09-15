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
    class FuncionarioMap : ClassMap<Funcionario>
    {
        public FuncionarioMap()
        {
            
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.DataAdmissao);
            References(x => x.Cargo, "CARGO_ID").Cascade.None();
            Map(x => x.Nome);
            Map(x => x.Cpf);
            Map(x => x.Rg);
            Map(x => x.DataNascimento);
            Map(x => x.DDD);
            Map(x => x.Telefone);
            Map(x => x.Email);
            Map(x => x.IpEstacaoLogada);
            Map(x => x.Foto).Length(50000);
            Map(x => x.StatusChat);
            References(x => x.usuario, "USUARIO_ID").Cascade.All();
            Map(x => x.AssinaReconhecimentoFirma);
            Map(x => x.SomenteSelosFisicosAlocados);
            Map(x => x.SelarSeloFisicoAutomatico);
            Map(x => x.SelarAutomaticoBotaoPraticar);
            Map(x => x.AssinaAtosBalcao);
            Map(x => x.EmiteCPF);
            Map(x => x.Inativo);
            Map(x => x.ConfiguraNivelAcessoDinamico);

            Table("FUNCIONARIO");
        }
    }
}
