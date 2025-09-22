using ProjetoBase.Ferramentas;
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

        /// <summary>
        /// Define a senha do usuário de forma segura, armazenando apenas o hash.
        /// </summary>
        /// <param name="senhaPura">A senha em texto puro digitada pelo usuário.</param>
        public virtual void DefinirSenha(string senhaPura)
        {
            // A lógica de criptografia vive aqui dentro.
            this.Senha = CriptografiaHelper.GerarHash(senhaPura);
        }


        /// <summary>
        /// Verifica se a senha fornecida corresponde à senha armazenada.
        /// </summary>
        /// <param name="senhaPura">A senha em texto puro a ser verificada.</param>
        /// <returns>Verdadeiro se a senha corresponder, falso caso contrário.</returns>
        public virtual bool VerificarSenha(string senhaPura)
        {
            return CriptografiaHelper.VerificarSenha(senhaPura, this.Senha);
        }
    }
}
