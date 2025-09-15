using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ProjetoBase.Ferramentas
{
    public static class Serializacao
    {
        public static Boolean Serializar(Object objeto, String nome)
        {
            nome = nome.Replace(".xml", "");
            Type tipoObjeto = objeto.GetType();
            XmlSerializer mySerializer = new XmlSerializer(tipoObjeto);
            FileStream stream = new FileStream(nome + ".xml", FileMode.Create);
            mySerializer.Serialize(stream, objeto);
            stream.Close();
            return true;
        }

        public static Boolean Serializar(Object objeto, String nome, String nspace)
        {
            nome = nome.Replace(".xml", "");
            Type tipoObjeto = objeto.GetType();
            XmlSerializer mySerializer = new XmlSerializer(tipoObjeto);

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("tipos", "http://www.ginfes.com.br/tipos_v03.xsd");

            FileStream stream = new FileStream(nome + ".xml", FileMode.Create);
            mySerializer.Serialize(stream, objeto, ns);
            stream.Close();
            return true;
        }

        public static Boolean SerializarSemNamespace(Object objeto, String nome)
        {
            Type tipoObjeto = objeto.GetType();
            XmlSerializer mySerializer = new XmlSerializer(tipoObjeto);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            FileStream stream = new FileStream(nome + ".xml", FileMode.Create);
            mySerializer.Serialize(stream, objeto, ns);
            stream.Close();
            return true;
        }

        public static Boolean SerializarSemNameSpaceISO8859(Object objeto, String nome)
        {
            Type tipoObjeto = objeto.GetType();

            var xml = new XmlSerializer(tipoObjeto);

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var appendMode = false;
            var encoding = Encoding.GetEncoding("ISO-8859-1");
            using (StreamWriter sw = new StreamWriter(nome + ".xml", appendMode, encoding))
            {
                xml.Serialize(sw, objeto, ns);
            }
            return true;
        }
        public static Boolean SerializarSemNameSpaceUTF8(Object objeto, String nome)
        {
            Type tipoObjeto = objeto.GetType();

            var xml = new XmlSerializer(tipoObjeto);

            if (nome?.Contains(".xml") == true)
            {
                nome = nome.Replace(".xml", "");
            }

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var appendMode = false;
            var encoding = Encoding.GetEncoding("utf-8");
            using (StreamWriter sw = new StreamWriter(nome + ".xml", appendMode, encoding))
            {
                xml.Serialize(sw, objeto, ns);
            }
            return true;
        }

        public static Object Deserializar(Object objeto, String nome)
        {
            FileStream myFileStream = null;
            try
            {
                nome = nome.Replace(".xml", "");

                Object objetoDeserializado;
                Type tipoObjeto = objeto.GetType();
                XmlSerializer mySerializer = new XmlSerializer(tipoObjeto);
                myFileStream = new FileStream(nome + ".xml", FileMode.Open);
                objetoDeserializado = mySerializer.Deserialize(myFileStream);
                myFileStream.Close();
                return objetoDeserializado;
            }
            catch (Exception ex)
            {
                if (myFileStream != null)
                {
                    myFileStream.Close();
                }

                return null;
            }
        }

        // Convert an object to a byte array
        public static byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);

            return ms.ToArray();
        }

        // Convert a byte array to an Object
        public static Object ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);

            return obj;
        }

        public static string SerializeToString<T>(this T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (Utf8StringWriter textWriter = new Utf8StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }

        public static string SerializeToStringDefault<T>(this T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }

        public static T DeserializeFromString<T>(String xml)
        {
            T instance;
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                using (var stringreader = new StringReader(xml))
                {
                    instance = (T)xmlSerializer.Deserialize(stringreader);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return instance;
        }

        public static string SerializeObjectToString<T>(this T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }
    }

    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }



}
