using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using System.IO;
using System.Text;
using Excepciones;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region Constructores
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.instructor = instructor;
            this.clase = clase;
        } 
        #endregion

        #region Propiedades

        /// <summary>
        /// Otorga acceso a la lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Otorga acceso a las clases
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Otorga acceso al instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Guarda la jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("../../../Jornada.txt"))
                    sw.WriteLine(jornada.ToString());

                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }
        /// <summary>
        /// Lee de un archivo de texto la jornada guardada
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (StreamReader sr = new StreamReader("../../../Jornada.txt"))
                {
                    string Recuperado;

                    while ((Recuperado = sr.ReadLine()) != null)
                    {
                        sb.Append(Recuperado);
                    }
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }

        /// <summary>
        /// Hace publicos los datos de la jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine(string.Format("CLASE DE {0} POR {1}", this.clase, this.instructor.ToString()));
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this.Alumnos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
        #endregion

        #region Operadores

        /// <summary>
        /// Verifica que un alumno este en la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno item in j.alumnos)
            {
                if (item == a)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Verifica que un alumno no este en la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a la jornada si este no esta en ella
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.alumnos.Add(a);

            return j;
        }
        #endregion
    }
}
