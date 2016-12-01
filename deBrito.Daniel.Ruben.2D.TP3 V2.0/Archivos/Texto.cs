using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto :IArchivo <string>
    {
        public bool Guardar (string archivo, string datos)
        {
            bool ret;
            try 
            {
                using (StreamWriter writer = new StreamWriter(archivo))
                {
                    ret = true;
                    writer.Write(datos);
                }
            }
            catch(Exception ex)
            {
                ret = false;
                throw new ArchivosException(ex);
            }
            return ret;
        }

        public bool Leer (string archivo, out string datos)
        {
            bool ret = true;
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    ret = true;
                    datos = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                ret = false;
                throw new ArchivosException(ex);
            }
            return ret;
        }
    }
}
