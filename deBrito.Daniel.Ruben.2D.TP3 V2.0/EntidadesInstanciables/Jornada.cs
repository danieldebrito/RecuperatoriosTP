using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Archivos;

namespace EntidadesInstanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Instructor))]

    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Gimnasio.EClases _clase;
        private Instructor _instructor;

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Gimnasio.EClases clase, Instructor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        public static bool operator == (Jornada j, Alumno a)
        {
            foreach (Alumno a2 in j._alumnos)
            {
                if (a == a2)
                    return true;
            }
            return false;
        }
        public static bool operator != (Jornada j, Alumno a)
        {
            return !(j == a);
        }
        public static Jornada operator + (Jornada j, Alumno a)
        {
            if (j != a)
                j._alumnos.Add(a);
            return j;
        }

        public static bool Guardar (Jornada j)
        {
            Texto tx = new Texto();
            return tx.Guardar("jornada.txt", j.ToString());
        }
        public static string Leer(Jornada j)
        {
            string dato="";
            Texto tx = new Texto();
            tx.Leer("jornada.txt", out dato);
            return dato;
        }
    }
}
