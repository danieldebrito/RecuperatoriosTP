using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Alumno :PersonaGimnasio
    {

        public enum EEstadoCuenta { AlDia, Deudor, MesPrueba }
        
        #region Fields
        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;
        #endregion

        #region Methods
        public Alumno (int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("Estado de cuenta: " + this._estadoCuenta);
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString(); 
        }
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE: " + this._claseQueToma.ToString();
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator == (Alumno a, Gimnasio.EClases clase)
        {
            bool retorno = false;
            if (a._claseQueToma.Equals(clase))
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator != (Alumno a, Gimnasio.EClases clase)
        {
            return !(a == clase);
        }
        #endregion
    }
}
