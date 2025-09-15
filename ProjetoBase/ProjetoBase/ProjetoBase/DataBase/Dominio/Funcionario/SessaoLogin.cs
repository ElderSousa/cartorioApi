using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBase.DataBase.Dominio.Interface;
using ProjetoBase.DataBase.Interface;

namespace ProjetoBase.DataBase.Dominio.Funcionario
{
    [Serializable]
    public class SessaoLogin : Entidade
    {
        public virtual int Id { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public virtual DateTime Login { get; set; }
        public virtual DateTime? Logout { get; set; }
        public virtual Boolean? EncerradaSemLogout { get; set; }

        public virtual string Codigo
        {
            get { return Id.ToString(); }
        }

        public virtual string Descricao
        {
            get { return $"{Login.ToString()} <-> {(Logout?.ToString() ?? "Ativo")}"; }
        }
        public virtual Entidade Proprio
        {
            get { return this; }
        }

        public virtual String getDescricaoLogout()
        {
            if (Logout == null && EncerradaSemLogout == null)
            {
                var tempoAtivo = DateTime.Now.Subtract(Login);

                return tempoAtivo.ToString("h'h 'm'm 's's'") + " (Ativo)";
            }
            else if (Logout != null)
            {
                var tempoAtivo = Logout.Value.Subtract(Login);

                return tempoAtivo.ToString("h'h 'm'm 's's'") + " (Encerrado)";
            }
            else if (EncerradaSemLogout != null)
            {
                return "Encerrado sem logout";
            }

            return null;
        }
    }
}
