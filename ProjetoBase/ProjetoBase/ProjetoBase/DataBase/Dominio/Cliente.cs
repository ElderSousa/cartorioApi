using System;
using ProjetoBase.DataBase.Dominio.Interface;

namespace ProjetoBase.DataBase.Dominio
{
    [Serializable]
    public class Cliente : Entidade
    {
        public virtual int Id { get; set; }
        public virtual string Tipo { get; set; } // "PF" ou "PJ"

        // Campos Comuns
        public virtual string Endereco { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Cidade { get; set; }
        public virtual string Uf { get; set; }
        public virtual string Cep { get; set; }
        public virtual string Ddd { get; set; }
        public virtual string Telefone { get; set; }
        public virtual string Email { get; set; }

        // Campos de Pessoa Física (podem ser nulos se for PJ)
        public virtual string Nome { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Rg { get; set; }
        public virtual DateTime? DataNascimento { get; set; }

        // Campos de Pessoa Jurídica (podem ser nulos se for PF)
        public virtual string RazaoSocial { get; set; }
        public virtual string NomeFantasia { get; set; }
        public virtual string Cnpj { get; set; }
        public virtual string Ie { get; set; }
        public virtual DateTime? DataFundacao { get; set; }

        // Propriedades de apoio
        public virtual string Codigo { get { return Id.ToString(); } protected set { } }
        public virtual string Descricao { get { return this.Tipo == "PF" ? this.Nome : this.RazaoSocial; } protected set { } }
        public virtual Entidade Proprio { get { return this; } protected set { } }
    }
}