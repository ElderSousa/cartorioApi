using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBase.DataBase.Dominio;
using ProjetoBase.DataBase.Dominio.Funcionario;


namespace ProjetoBase.DataBase.Ferramentas
{
    public static class Repositorios
    {

        public static Repositorio<Cargo> Cargo = new Repositorio<Cargo>();
        public static Repositorio<Usuario> Usuario = new Repositorio<Usuario>();
        public static Repositorio<Funcionario> Funcionario = new Repositorio<Funcionario>();
        public static Repositorio<NivelDeAcesso> NivelDeAcesso = new Repositorio<NivelDeAcesso>();
    }
}
