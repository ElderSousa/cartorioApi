using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBase.DataBase.Dominio.Funcionario
{
    [Serializable]
    public class Usuario
    {
        public virtual int Id { get; set; }
        public virtual String Login { get; set; }
        public virtual String Senha { get; set; }
        public virtual Boolean Administrador { get; set; }
        public virtual PerfilDeAcesso PerfilDeAcesso { get; set; }
        public virtual ISet<NivelDeAcesso> NivelDeAcesso { get; set; }
        public virtual Boolean ResetarSenha { get; set; }
        public virtual Boolean ReceberAlertas { get; set; }

        public Usuario()
        {
            NivelDeAcesso = new HashSet<NivelDeAcesso>();
        }
    }
}
