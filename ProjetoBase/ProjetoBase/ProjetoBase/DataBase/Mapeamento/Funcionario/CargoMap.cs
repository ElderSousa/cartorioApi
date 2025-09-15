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
    class CargoMap : ClassMap<Cargo>
    {
        public CargoMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Nome).Length(10);
            Table("CARGO");            
        }
    }
}
