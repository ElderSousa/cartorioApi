using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
// Importa a biblioteca para usar Reflection, que permite inspecionar e manipular objetos e suas propriedades dinamicamente.
using System.Reflection;
using System.Text;
// Importa a interface base 'Entidade', que é usada para identificar os objetos do nosso domínio.
using ProjetoBase.DataBase.Dominio.Interface;

// Define o namespace (pacote) da classe.
namespace ProjetoBase.DataBase.Ferramentas
{
    // Declara uma classe estática. Isso significa que você não precisa criar uma instância dela para usar seus métodos.
    // Você pode simplesmente chamar EntidadeManager.forcarLoad().
    public static class EntidadeManager
    {
        // Este é o método público que você chama para iniciar o processo.
        // 'objeto': O objeto principal que você quer carregar completamente (ex: um Funcionario).
        // 'IndiceMaximo': Um limite de profundidade para evitar loops infinitos em relacionamentos complexos.
        public static void forcarLoad(object objeto, int IndiceMaximo)
        {
            // A linha original está comentada, mas a intenção era chamar o método privado que faz o trabalho pesado.
            // Inicia o processo de carregamento recursivo a partir do objeto inicial, com profundidade 0.
            loadObjeto(objeto, 0, IndiceMaximo);
        }

        // Este é o método recursivo privado que navega pela árvore de objetos.
        // 'objeto': O objeto que está sendo inspecionado no momento.
        // 'indiceObjeto': A profundidade atual da recursão.
        // 'IndiceMaximo': O limite máximo de profundidade.
        private static void loadObjeto(object objeto, int indiceObjeto, int IndiceMaximo)
        {
            // Incrementa o índice de profundidade para a próxima chamada recursiva.
            int indice = indiceObjeto + 1;

            // Usa um bloco try-catch para evitar que qualquer erro durante o processo de Reflection pare a aplicação.
            try
            {
                // Usando Reflection, pega uma lista de todas as propriedades públicas do objeto atual.
                PropertyInfo[] props = objeto.GetType().GetProperties();
                // Itera sobre cada propriedade encontrada (ex: Id, Nome, Cargo, etc.).
                foreach (PropertyInfo prop in props)
                {
                    // Outro try-catch interno para que um erro ao acessar uma propriedade não impeça a verificação das outras.
                    try
                    {
                        // AQUI ACONTECE A MÁGICA DO LAZY LOADING:
                        // Ao chamar prop.GetValue(), você está forçando o C# a ler o valor da propriedade.
                        // Se a propriedade for um objeto "preguiçoso" do NHibernate (um proxy), esta chamada
                        // forçará o NHibernate a ir ao banco de dados e carregar os dados reais.
                        object obj = prop.GetValue(objeto, null);

                        // VERIFICAÇÃO RECURSIVA PARA OBJETOS ÚNICOS:
                        // Se a profundidade atual for menor que o limite E o valor da propriedade for um tipo de 'Entidade' (ex: a propriedade Cargo).
                        if (indice < IndiceMaximo && obj is Entidade)
                        {
                            // Chama a si mesmo (recursão) para fazer o mesmo processo de carregamento dentro deste objeto aninhado.
                            loadObjeto(obj, indice, IndiceMaximo);
                        }
                        // VERIFICAÇÃO RECURSIVA PARA COLEÇÕES (LISTAS):
                        // Se a profundidade for menor que o limite E a propriedade for uma coleção (como ISet ou IEnumerable).
                        else if (indice < IndiceMaximo && (prop.PropertyType.Name.Contains("ISet") || obj is System.Collections.IEnumerable))
                        {
                            // Itera sobre cada item dentro da coleção.
                            foreach (object objetoLista in (IEnumerable)obj)
                            {
                                // Se o item da lista for uma 'Entidade'.
                                if (objetoLista is Entidade)
                                {
                                    // Chama a si mesmo (recursão) para carregar completamente cada objeto da lista.
                                    loadObjeto(objetoLista, indice, IndiceMaximo);
                                }
                            }
                        }
                    }
                    catch
                    {
                        // Se ocorrer um erro ao acessar uma propriedade específica, ele é ignorado e o loop continua.
                        // Isso é útil para propriedades que podem não ser legíveis ou que podem causar exceções.
                    }
                }
            }
            catch
            {
                // Se ocorrer um erro mais geral ao tentar obter as propriedades do objeto, ele é ignorado.
            }
        }
    }
}