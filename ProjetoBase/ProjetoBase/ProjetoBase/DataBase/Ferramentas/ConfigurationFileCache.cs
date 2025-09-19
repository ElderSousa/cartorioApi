// Importa as bibliotecas necessárias do FluentNHibernate e do NHibernate.
using FluentNHibernate.Cfg;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
// Importa a biblioteca para manipulação de arquivos (ler, escrever, deletar).
using System.IO;
using System.Linq;
// Importa a biblioteca para trabalhar com "Assemblies", que são os arquivos .dll ou .exe do projeto.
using System.Reflection;
// Importa a biblioteca para serialização binária, que converte objetos em um formato que pode ser salvo em um arquivo.
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using ProjetoBase.Ferramentas;

// Define o namespace (pacote) onde a classe está localizada.
namespace ProjetoBase.DataBase.Ferramentas
{
    // Declara a classe. Ela implementa a interface ISQLExceptionConverter, embora não a utilize de fato (veremos o porquê no final).
    public class ConfigurationFileCache : NHibernate.Exceptions.ISQLExceptionConverter
    {
        // Variável pública que armazena o caminho e o nome do arquivo de cache (ex: "C:\temp\nhibernate.cfg").
        public string _cacheFile;
        // Variável privada que guarda uma referência ao assembly principal do projeto, onde os mapeamentos estão.
        private readonly Assembly _definitionsAssembly;

        // Este é o construtor da classe. Ele é chamado quando um objeto ConfigurationFileCache é criado.
        public ConfigurationFileCache(Assembly definitionsAssembly, String caminho)
        {
            // Guarda a referência ao assembly do projeto.
            _definitionsAssembly = definitionsAssembly;
            // Define o caminho completo para o arquivo de cache que será usado.
            _cacheFile = caminho;
        }

        // Método para deletar o arquivo de cache.
        public void DeleteCacheFile()
        {
            // Verifica se o arquivo de cache realmente existe no disco.
            if (File.Exists(_cacheFile))
                // Se existir, deleta o arquivo.
                File.Delete(_cacheFile);
        }

        // Esta é uma propriedade "somente leitura" que verifica se o arquivo de cache é válido. É a parte mais importante.
        public bool IsConfigurationFileValid
        {
            get
            {
                // Se o arquivo de cache não existir, ele obviamente não é válido.
                if (!File.Exists(_cacheFile))
                    return false;
                
                // Pega as informações do arquivo de cache (tamanho, data de modificação, etc.).
                var configInfo = new FileInfo(_cacheFile);
                // Pega as informações do arquivo .dll ou .exe do seu projeto.
                var asmInfo = new FileInfo(_definitionsAssembly.Location);

                // Uma verificação de segurança. Se o arquivo de cache for muito pequeno (menos de 5KB), provavelmente está corrompido.
                if (configInfo.Length < 5 * 1024)
                    return false;

                // A VERIFICAÇÃO FINAL E MAIS IMPORTANTE:
                // Compara a data da última modificação do arquivo de cache com a data do arquivo do seu projeto (.dll).
                // Se o seu projeto foi compilado DEPOIS que o cache foi salvo, significa que você pode ter mudado
                // alguma classe de mapeamento, e o cache está desatualizado e inválido.
                return configInfo.LastWriteTime >= asmInfo.LastWriteTime;
            }
        }

        // Método que salva o objeto de configuração do NHibernate no arquivo de cache.
        public void SaveConfigurationToFile(Configuration configuration)
        {
            // Abre (ou cria, se não existir) o arquivo de cache em modo de escrita.
            using (var file = File.Open(_cacheFile, FileMode.Create))
            {
                // Cria um "formatador binário", que é o objeto que sabe como converter o objeto "configuration" em bytes.
                var bf = new BinaryFormatter();
                // Serializa (converte e salva) o objeto de configuração no arquivo.
                bf.Serialize(file, configuration);
            }
        }

        // Método que carrega a configuração a partir do arquivo de cache.
        public Configuration LoadConfigurationFromFile()
        {
            // Primeiro, verifica se o cache é válido usando a propriedade que analisamos acima.
            if (!IsConfigurationFileValid)
                // Se não for válido, retorna nulo para sinalizar que a configuração precisa ser criada do zero.
                return null;

            // Se o cache for válido, abre o arquivo para leitura.
            using (var file = File.Open(_cacheFile, FileMode.Open, FileAccess.Read))
            {
                // Cria o formatador binário para ler os dados.
                var bf = new BinaryFormatter();
                // Desserializa (lê do arquivo e reconstrói o objeto) e retorna o objeto de configuração pronto para uso.
                // "as Configuration" faz a conversão do tipo do objeto lido para o tipo Configuration do NHibernate.
                return bf.Deserialize(file) as Configuration;
            }
        }

        // Este método vem da interface ISQLExceptionConverter.
        // O objetivo dessa interface é permitir a conversão de exceções específicas do banco de dados em exceções do NHibernate.
        // No entanto, esta classe está sendo usada apenas para o cache, e não para o tratamento de exceções.
        public Exception Convert(NHibernate.Exceptions.AdoExceptionContextInfo adoExceptionContextInfo)
        {
            // Como a funcionalidade de conversão de exceção não é o propósito desta classe,
            // o método simplesmente lança uma exceção indicando que não foi implementado.
            throw new NotImplementedException();
        }
    }
}