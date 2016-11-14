using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public class Concesionaria
    {
        #region enumerados
        public enum ETipo
        {
            Moto, Camion, Automovil, Todos
        }
        #endregion
        
        #region atributos
        protected List<Vehiculo> _vehiculos;
        protected int _espacioDisponible;
        #endregion   

        #region constructores
        private Concesionaria()
        {
            this._vehiculos = new List<Vehiculo>();
        }
        
        public Concesionaria(int espacioDisponible):this()
        {
            this._espacioDisponible = espacioDisponible;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Muestro la concecionaria y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Concesionaria.Mostrar(this, ETipo.Todos);
        }

        /// <summary>
        /// Expone los datos de la concecionaria y sus vehículos (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="concecionaria">Concecionaria a exponer</param>
        /// <param name="ETipo">Tipos de Vehiculos a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Concesionaria concecionaria, ETipo tipoDeVehiculo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", concecionaria._vehiculos.Count, concecionaria._espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in concecionaria._vehiculos)
            {
                switch (tipoDeVehiculo)
                {
                    case ETipo.Automovil:
                        if( v is Automovil )
                        sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Moto:
                        if ( v is Moto)
                        sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Camion:
                        if (v is Camion)
                        sb.AppendLine(v.Mostrar());
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region sobrecargas
        /// <summary>
        /// Agregará un vehículo a la concecionaria, siempre que haya espacio disponible
        /// </summary>
        /// <param name="concecionaria">Objeto del tipo Concecionaria donde se agregará el vehículo</param>
        /// <param name="vehiculo">Objeto del tipo Vehículo a agregar</param>
        /// <returns></returns>
        public static Concesionaria operator + (Concesionaria concecionaria, Vehiculo vehiculo)
        {
            if (concecionaria._vehiculos.Count >= concecionaria._espacioDisponible)
                return concecionaria;

                foreach (Vehiculo v in concecionaria._vehiculos)
                {
                    if (v == vehiculo)
                    {
                        return concecionaria;
                    }
                }
            concecionaria._vehiculos.Add(vehiculo);
            return concecionaria;
        }
        /// <summary>
        /// Quitará un vehículo de la concecionaria
        /// </summary>
        /// <param name="concecionaria">Objeto del tipo Concecionaria donde se quitara el vehículo</param>
        /// <param name="vehiculo">Objeto del tipo Vehículo a quitar</param>
        /// <returns></returns>
        public static Concesionaria operator - (Concesionaria concecionaria, Vehiculo vehiculo)
        {
            for (int i = 0 ; i < concecionaria._vehiculos.Count ; i++)
            {
                if (concecionaria._vehiculos[i] == vehiculo)
                {
                    concecionaria._vehiculos.Remove(vehiculo);
                    break;
                }
            }

            return concecionaria;
        }
        #endregion
    }
}
