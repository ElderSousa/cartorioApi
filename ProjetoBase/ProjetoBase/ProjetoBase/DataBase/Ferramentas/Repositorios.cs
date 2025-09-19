using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBase.DataBase.Dominio;
using ProjetoBase.DataBase.Dominio.Funcionario;


namespace ProjetoBase.DataBase.Ferramentas
{
  // Declara uma classe estática. A palavra-chave "static" significa que você não precisa
// criar uma instância dela (com 'new Repositorios()'). Você pode acessá-la diretamente
// de qualquer lugar do código, como um atalho global.
public static class Repositorios
{
    // Cria uma propriedade estática chamada "Cargo".
    // "public static": Pode ser acessada de qualquer lugar.
    // "Repositorio<Cargo>": O tipo da propriedade é um Repositório que sabe trabalhar com objetos 'Cargo'.
    // "= new Repositorio<Cargo>()": Aqui, uma única instância do repositório de Cargo é criada
    // quando o programa começa a rodar. Essa mesma instância será usada em todo o sistema.
    public static Repositorio<Cargo> Cargo = new Repositorio<Cargo>();

    // Faz exatamente a mesma coisa, mas para a entidade 'Usuario'.
    // Agora, para acessar a tabela de usuários, você pode simplesmente usar "Repositorios.Usuario".
    public static Repositorio<Usuario> Usuario = new Repositorio<Usuario>();

    // O mesmo para a entidade 'Funcionario'.
    public static Repositorio<Funcionario> Funcionario = new Repositorio<Funcionario>();

    // E o mesmo para a entidade 'NivelDeAcesso'.
    public static Repositorio<NivelDeAcesso> NivelDeAcesso = new Repositorio<NivelDeAcesso>();
}
}
