using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBase.DataBase.Dominio.Interface;
using ProjetoBase.DataBase.Interface;

namespace ProjetoBase.DataBase.Dominio.Funcionario
{
    [Serializable]
    public class Cargo : Entidade, DeletavelInterface
    {
        public virtual int Id { get; set; }
        public virtual String Nome { get; set; }
        
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
        public virtual bool deletavel()
        {
            return true;
        }
    }
}
