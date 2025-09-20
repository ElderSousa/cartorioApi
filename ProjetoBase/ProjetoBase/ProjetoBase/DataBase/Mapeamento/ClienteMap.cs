using FluentNHibernate.Mapping;
using ProjetoBase.DataBase.Dominio;

namespace ProjetoBase.DataBase.Mapeamento
{
    public class ClienteMap : ClassMap<Cliente>
    {
        public ClienteMap()
        {
            Table("CLIENTE");
            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.Tipo).Length(2).Not.Nullable();

            // Mapeia TODOS os campos. O NHibernate aceitará valores nulos.
            Map(x => x.Endereco).Length(200);
            Map(x => x.Bairro).Length(100);
            Map(x => x.Cidade).Length(100);
            Map(x => x.Uf).Length(2);
            Map(x => x.Cep).Length(10);
            Map(x => x.Ddd).Length(3);
            Map(x => x.Telefone).Length(20);
            Map(x => x.Email).Length(150);

            Map(x => x.Nome).Length(200);
            Map(x => x.Cpf).Length(14);
            Map(x => x.Rg).Length(20);
            Map(x => x.DataNascimento);

            Map(x => x.RazaoSocial).Length(200);
            Map(x => x.NomeFantasia).Length(200);
            Map(x => x.Cnpj).Length(18);
            Map(x => x.Ie).Length(20);
            Map(x => x.DataFundacao);

            // Propriedades somente leitura
            Map(x => x.Codigo).Formula("Id");
            Map(x => x.Descricao).Formula("CASE WHEN Tipo = 'PF' THEN Nome ELSE RazaoSocial END");
        }
    }
}