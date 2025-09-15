using FluentNHibernate.Cfg;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using ProjetoBase.Ferramentas;

namespace ProjetoBase.DataBase.Ferramentas
{

    public class ConfigurationFileCache : NHibernate.Exceptions.ISQLExceptionConverter
    {
        public string _cacheFile;
        private readonly Assembly _definitionsAssembly;

        public ConfigurationFileCache(Assembly definitionsAssembly, String caminho)
        {
            _definitionsAssembly = definitionsAssembly;
            _cacheFile = caminho;
        }

        public void DeleteCacheFile()
        {
            if (File.Exists(_cacheFile))
                File.Delete(_cacheFile);
        }

        public bool IsConfigurationFileValid
        {
            get
            {
                if (!File.Exists(_cacheFile))
                    return false;
                var configInfo = new FileInfo(_cacheFile);
                var asmInfo = new FileInfo(_definitionsAssembly.Location);

                if (configInfo.Length < 5 * 1024)
                    return false;

                return configInfo.LastWriteTime >= asmInfo.LastWriteTime;

            }
        }

        public void SaveConfigurationToFile(Configuration configuration)
        {
            using (var file = File.Open(_cacheFile, FileMode.Create))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(file, configuration);
            }
        }

        public Configuration LoadConfigurationFromFile()
        {
            if (!IsConfigurationFileValid)
                return null;

            using (var file = File.Open(_cacheFile, FileMode.Open, FileAccess.Read))
            {
                var bf = new BinaryFormatter();
                return bf.Deserialize(file) as Configuration;
            }
        }

        public Exception Convert(NHibernate.Exceptions.AdoExceptionContextInfo adoExceptionContextInfo)
        {
            throw new NotImplementedException();
        }
    }
}
