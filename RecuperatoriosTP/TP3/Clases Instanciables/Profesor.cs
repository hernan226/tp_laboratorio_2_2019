using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor:Universitario
    {
        private Queue<Universidad.EClases> claseDelDia;
        private static Random random;

        #region Constructores
        static Profesor()
        {
            random = new Random();
        }

        public Profesor() { }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        } 
        #endregion

        #region Metodos
        /// <summary>
        /// Asigna clases a un profesor
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this.claseDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
            }
        }
        /// <summary>
        /// Hace publica las clases en las que participa el profesor
        /// </summary>
        /// <returns></returns>
        protected override string PaticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA:");
            foreach (Universidad.EClases item in this.claseDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Muestra los datos del profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return this.ToString();
        }

        /// <summary>
        /// Hace publicos los datos del profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(string.Format("{0}",this.PaticiparEnClase()));

            return sb.ToString();
        }
        #endregion

        #region Operadores

        /// <summary>
        /// Verifica si un profesor da una determinada clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases item in i.claseDelDia)
            {
                if (item == clase)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Verifica si un profesor no da una determinada clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        } 
        #endregion
    }
}
