using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBase.DataBase.Dominio.Interface;

namespace ProjetoBase.DataBase.Dominio.Funcionario
{
    [Serializable]
    public class NivelDeAcessoDinamico : Entidade
    {
        public virtual int Id { get; set; }
        public virtual String Nome { get; set; }
        public virtual String Acao { get; set; }
        public virtual DateTime DataCadastro { get; set; }
        public virtual Funcionario CadastradoPor { get; set; }

        public virtual ISet<Funcionario> Funcionarios { get; set; }

        public virtual string Codigo
        {
            get { return Id.ToString(); }
        }

        public virtual string Descricao
        {
            get { return Nome; }
        }
        public virtual Entidade Proprio
        {
            get { return this; }
        }
    }
}
