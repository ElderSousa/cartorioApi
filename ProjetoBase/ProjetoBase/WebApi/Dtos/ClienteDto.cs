namespace WebApi.Models
{
    /// <summary>
    /// Objeto de Transferência de Dados para Cliente.
    /// </summary>
    public class ClienteDto
    {
      
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual string Cpf { get; set; }

        public virtual string RazaoSocial { get; set; }

        public virtual string Cnpj { get; set; }

        public virtual string Email { get; set; }

        public virtual string Telefone { get; set; }

        public virtual string Observacoes { get; set; }
    }

    public class ClienteUpdateDto
    {
        public string Observacoes { get; set; }
    }
}
