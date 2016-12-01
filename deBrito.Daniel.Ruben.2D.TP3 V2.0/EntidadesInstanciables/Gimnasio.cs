using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Archivos;
using Excepciones;

namespace EntidadesInstanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Instructor))]
    [XmlInclude(typeof(Jornada))]
    public class Gimnasio
    {
        public enum EClases { Pilates, Natacion, CrossFit, Yoga }

        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        protected List<Jornada> _jornada;

        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }

        public Jornada this[int index]
        {
            get
            {
                return this._jornada[index];
            }
        }

        private static string MostrarDatos(Gimnasio g)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Jornadas :");

            foreach (Jornada j in g._jornada)
                sb.AppendLine(j.ToString());

            sb.AppendLine("Alumnos :");

            foreach (Alumno a in g._alumnos)
                sb.AppendLine(a.ToString());

            sb.AppendLine("Instructores :");

            foreach (Instructor i in g._instructores)
                sb.AppendLine(i.ToString());

            return sb.ToString();
        }

        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }

        public static bool Guardar(Gimnasio g)
        {
            Xml<Gimnasio> dato = new Xml<Gimnasio>();
            return dato.Guardar("gimnasio.xml", g);
        }
        public static Gimnasio Leer(Gimnasio g)
        {
            Xml<Gimnasio> dato = new Xml<Gimnasio>();
            Gimnasio ginAux;
            dato.Leer("gimnasio.xml", out ginAux);
            return ginAux;
        }

        public static bool operator == (Gimnasio g, Alumno a)
        {
            foreach (Alumno a2 in g._alumnos)
            {
                if (a2 == a)
                    return true;
            }
            return false;
        }
        public static bool operator != (Gimnasio g, Alumno a)
        {
            return !(g == a);
        }
        public static Instructor operator == (Gimnasio g, EClases clase)
        {
            foreach (Instructor i in g._instructores)
            {
                if (i == clase)
                    return i;
            }
            throw new SinInstructorException();
        }
        public static Instructor operator != (Gimnasio g, EClases clase)
        {
            foreach (Instructor i in g._instructores)
            {
                if (i != clase)
                    return i;
            }
            throw new SinInstructorException();
        }
        public static Gimnasio operator + (Gimnasio g, Alumno a)
        {
            foreach (Alumno a2 in g._alumnos)
            {
                if (a2 == a)
                    throw new AlumnoRepetidoException();
            }
            g._alumnos.Add(a);
            return g;
        }
        public static Gimnasio operator + (Gimnasio g, Instructor i)
        {
            foreach (Instructor i2 in g._instructores)
            {
                if (i2 == i)
                    return g;
            }
            g._instructores.Add(i);
            return g;
        }

        public static Gimnasio operator + (Gimnasio g, EClases clase)
        {
            Jornada j = new Jornada(clase, g == clase);

            foreach (Alumno a in g._alumnos)
            {
                if (a == clase)
                {
                    j += a;
                }
            }
            g._jornada.Add(j);
            return g;
        }

    }
}
