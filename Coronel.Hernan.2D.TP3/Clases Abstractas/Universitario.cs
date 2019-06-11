using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region Constructores
        public Universitario() { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Verifica que el objeto recibido sea o no igual a si mismo
        /// </summary>
        /// <param name="obj">objeto</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return ((Universitario)obj == this);
        }

        /// <summary>
        /// Muestra los datos del universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine(string.Format("\nLEGAJO NUMERO {0}", this.legajo));

            return sb.ToString();
        }

        protected abstract string PaticiparEnClase();
        #endregion

        #region Operadores
        /// <summary>
        /// compara dos universitario y verifica que sean iguales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return
                ((pg1.GetType() == pg2.GetType())
                &&
                (pg2.legajo == pg1.legajo || pg1.Dni == pg2.Dni));
        }

        /// <summary>
        /// compara dos universitario y verifica que no sean iguales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
