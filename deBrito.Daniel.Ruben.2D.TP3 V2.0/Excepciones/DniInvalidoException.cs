using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException :Exception
    {
        private static string _mensajeBase = "Numero de DNI invalido";

        public DniInvalidoException()
            : base()
        { 
        }

        public DniInvalidoException(Exception e)
            : base(_mensajeBase, e)
        { 
        }

        public DniInvalidoException (string message)
            :base(message)
        {
        }

        public DniInvalidoException(Exception e, string message)
            : base(message, e)
        { 
        }
    }
}
