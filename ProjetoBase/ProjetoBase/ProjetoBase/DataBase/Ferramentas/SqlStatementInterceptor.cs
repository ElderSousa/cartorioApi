// Importa as bibliotecas necessárias.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// Importa a biblioteca principal do NHibernate.
using NHibernate;
// A biblioteca de diagnóstico é frequentemente usada junto com interceptadores para escrever no "Output" do Visual Studio.
using System.Diagnostics;

// Define o namespace onde a classe está localizada.
namespace ProjetoBase.DataBase.Ferramentas
{
    // O atributo [Serializable] indica que uma instância desta classe pode ser convertida
    // para uma sequência de bytes (serializada). Isso é, por vezes, necessário para
    // configurações do NHibernate, especialmente se a configuração for cacheada ou distribuída.
    [Serializable]
    public class SqlStatementInterceptor : EmptyInterceptor // A classe herda de 'EmptyInterceptor'.
    {
        // Este método é o coração da classe. Ele sobrescreve ('override') o método da classe base.
        // O NHibernate chama este método AUTOMATICAMENTE toda vez que prepara um comando SQL para ser executado.
        public override NHibernate.SqlCommand.SqlString OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
        {
            // AÇÃO PRINCIPAL: Pega o comando SQL que será executado...
            // ... e o imprime na janela do console.
            // Isso permite que o desenvolvedor veja em tempo real todas as queries geradas pelo NHibernate.
            Console.WriteLine(sql.ToString());

            // IMPORTANTE: Retorna o comando SQL original, sem nenhuma modificação.
            // O NHibernate pegará este valor de retorno e o executará no banco de dados.
            // Se você quisesse, poderia modificar o SQL aqui antes de retorná-lo.
            return sql;
        }
    }
}