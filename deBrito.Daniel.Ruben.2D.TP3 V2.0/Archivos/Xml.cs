using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo <T>
    {
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer sr = new XmlSerializer(typeof(T));
                XmlTextWriter wt = new XmlTextWriter(archivo, Encoding.UTF8);
                sr.Serialize(wt, datos);
                wt.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                TextReader writer = new StreamReader(archivo);
                datos = (T)serializer.Deserialize(writer);
                writer.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                datos = default(T);
                return false;
            }
        }  
    }
}
