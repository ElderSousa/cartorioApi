// Importa a biblioteca do NHibernate que contém as ferramentas de transformação de resultados.
using NHibernate.Transform;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
// Importa a biblioteca para usar Reflection, que permite inspecionar e manipular objetos e suas propriedades dinamicamente.
using System.Reflection;
using System.Text;

// Define o namespace (pacote) da classe.
namespace ProjetoBase.DataBase.Ferramentas
{
    // Declara a classe genérica. "TEntity" será o tipo do objeto principal que queremos construir (ex: Funcionario).
    // Ela implementa a interface "IResultTransformer", que obriga a classe a ter os métodos "TransformTuple" e "TransformList".
    public class DeepTransformer<TEntity> : IResultTransformer
        where TEntity : class
    {
        // Este método é o coração da classe. Ele é chamado pelo NHibernate para CADA LINHA retornada pela consulta SQL.
        public object TransformTuple(object[] tuple, string[] aliases)
        {
            // 'tuple': Um array com os valores da linha (ex: { 1, "João Silva", "Vendedor" }).
            // 'aliases': Um array com os nomes (apelidos) das colunas (ex: { "Id", "Nome", "Cargo.Nome" }).

            // Converte o array de aliases para uma lista, que é mais fácil de manipular.
            var list = new List<string>(aliases);

            // Cria uma cópia da lista de aliases. Esta lista será usada para as propriedades simples (não aninhadas).
            var propertyAliases = new List<string>(list);
            // Cria uma lista vazia para guardar apenas os aliases das propriedades complexas (aninhadas).
            var complexAliases = new List<string>();

            // Percorre a lista de aliases para separar os simples dos complexos.
            for (var i = 0; i < list.Count; i++)
            {
                var aliase = list[i];
                // A REGRA PRINCIPAL: Se o alias contém um '.', ele representa uma propriedade aninhada (ex: "Cargo.Nome").
                if (aliase.Contains('.'))
                {
                    // Adiciona o alias complexo à sua lista específica.
                    complexAliases.Add(aliase);
                    // Na lista de propriedades simples, define a posição deste alias como nula.
                    // Isso diz ao transformador padrão do NHibernate para ignorar esta coluna por enquanto.
                    propertyAliases[i] = null;
                }
            }

            // TRUQUE INTELIGENTE: Em vez de reinventar a roda...
            // Usa o transformador padrão do NHibernate ("AliasToBean") para preencher todas as propriedades SIMPLES.
            // Ele vai pegar a lista "propertyAliases" (que agora só tem "Id" e "Nome") e preencher o objeto Funcionario.
            var result = Transformers
                .AliasToBean<TEntity>()
                .TransformTuple(tuple, propertyAliases.ToArray());

            // Agora, com o objeto base preenchido, chama nosso método customizado para lidar com as propriedades aninhadas.
            TransformPersistentChain(tuple, complexAliases, result, list);

            // Retorna o objeto "Funcionario" completo, com o "Cargo" preenchido dentro dele.
            return result;
        }

        /// <summary>
        /// Este método navega por um caminho de propriedades (ex: Cliente.Endereco.Cidade) e preenche o valor final.
        /// </summary>
        protected virtual void TransformPersistentChain(object[] tuple, List<string> complexAliases, object result, List<string> list)
        {
            // Converte o resultado para o tipo da nossa entidade (ex: Funcionario).
            var entity = result as TEntity;

            // Itera sobre cada alias complexo que encontramos (ex: "Cargo.Nome").
            foreach (var aliase in complexAliases)
            {
                // Encontra o valor correspondente a este alias no array de valores da linha.
                var index = list.IndexOf(aliase);
                var value = tuple[index];
                // Se o valor for nulo no banco, não há nada a fazer, então pulamos para o próximo.
                if (value == null)
                {
                    continue;
                }

                // Divide o caminho do alias em partes (ex: "Cargo.Nome" vira { "Cargo", "Nome" }).
                var parts = aliase.Split('.');
                var name = parts[0]; // A primeira parte é o nome da primeira propriedade no caminho (ex: "Cargo").

                // Usando Reflection, obtemos as informações da propriedade "Cargo" a partir do tipo do "Funcionario".
                var propertyInfo = entity.GetType()
                        .GetProperty(name, BindingFlags.NonPublic
                                           | BindingFlags.Instance
                                           | BindingFlags.Public);

                // Começamos a navegar a partir do objeto principal (o Funcionario).
                object currentObject = entity;

                // Este loop "caminha" pela estrutura de objetos (ex: de Funcionario para Cargo).
                var current = 1;
                while (current < parts.Length)
                {
                    name = parts[current]; // Pega a próxima parte do caminho (ex: "Nome").
                    // Pega a instância do objeto atual no caminho (ex: pega o objeto 'Cargo' de dentro do 'Funcionario').
                    object instance = propertyInfo.GetValue(currentObject, null);
                    // Se o objeto no meio do caminho não existir (ex: Funcionario.Cargo está nulo)...
                    if (instance == null)
                    {
                        // ...cria uma nova instância dele (ex: new Cargo()).
                        instance = Activator.CreateInstance(propertyInfo.PropertyType);
                        // ...e atribui essa nova instância à propriedade do objeto pai (ex: Funcionario.Cargo = new Cargo()).
                        propertyInfo.SetValue(currentObject, instance, null);
                    }

                    // Atualiza as informações da propriedade para a próxima iteração (agora, vamos procurar a propriedade "Nome" dentro da classe "Cargo").
                    propertyInfo = propertyInfo.PropertyType.GetProperty(name, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                    // Define o objeto atual como a instância que acabamos de obter ou criar (agora, 'currentObject' é o objeto 'Cargo').
                    currentObject = instance;
                    current++;
                }

                // Após o loop, 'currentObject' é o último objeto na cadeia (o 'Cargo') e 'propertyInfo' é a propriedade final ('Nome').
                
                // (Esta parte é para um caso de uso avançado com objetos dinâmicos, podemos ignorar por enquanto).
                var dictionary = currentObject as IDictionary;
                if (dictionary != null)
                {
                    dictionary[name] = value;
                }
                else
                {
                    // Usando Reflection, finalmente definimos o valor final na propriedade correta.
                    // (ex: define a propriedade 'Nome' do objeto 'Cargo' com o valor "Vendedor").
                    propertyInfo.SetValue(currentObject, value, null);
                }
            }
        }

        // Este método é chamado pelo NHibernate uma vez no final, depois que todas as linhas foram processadas.
        public System.Collections.IList TransformList(System.Collections.IList collection)
        {
            // Ele simplesmente usa o transformador padrão para garantir que a lista final não tenha duplicatas do objeto principal.
            var results = Transformers.AliasToBean<TEntity>().TransformList(collection);
            return results;
        }
    }
}