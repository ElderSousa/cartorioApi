using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBase.DataBase.Dominio.Funcionario
{
    [Serializable]
    public class NivelDeAcessoUsuario
    {
        public virtual int Id { get; set; }
        public virtual NivelDeAcesso NivelAcesso { get; set; }       
    }
}
