using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace Clases_Instanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornada = new List<Jornada>();
            this.Profesores = new List<Profesor>();
        }

        #region Metodos
        public static bool Guardar(Universidad uni)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Universidad));
            try
            {
                using (XmlTextWriter xtw = new XmlTextWriter("../../../Universidad.xml", Encoding.UTF8))
                    xs.Serialize(xtw, uni);

                return true;
            }
            catch (ArchivosException ex)
            {
                throw ex;
            }
        }
        public static Universidad Leer()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Universidad));
            Universidad aux;
            try
            {
                using (XmlTextReader xtr = new XmlTextReader("../../../Universidad.xml"))
                    aux = (Universidad)xs.Deserialize(xtr);

                return aux;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            foreach (Jornada item in this.Jornada)
            {
                sb.AppendLine(item.ToString());
                sb.AppendLine("<------------------------------------------------------------------>");
            }

            return sb.ToString();
            
        }

        private static string MostrarDatos(Universidad uni)
        {
            return uni.ToString();
        }
        #endregion

        #region Propiedades
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
        public List<Jornada> Jornada
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        public List<Profesor> Profesores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }
        #endregion

        #region Operadores

        /// <summary>
        /// Verifica que un alumo este en la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno item in g.Alumnos)
            {
                if (item == a)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica que un alumo no este en la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Verifica que un profesor este en la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor item in g.Profesores)
            {
                if (item == i)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica que un profesor no este en la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Verifica si un profesor puede dar determinada clase y lo retorna
        /// caso contrario arroja una excepcion
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.Profesores)
            {
                if (item == clase)
                    return item;
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Verifica si un profesor no puede dar determinada clase y lo retorna
        /// caso contrario arroja una excepcion
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.Profesores)
            {
                if (item != clase)
                    return item;
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Agrega un alumno a la universidad si este no esta repetido
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
                g.Alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();

            return g;
        }

        /// <summary>
        /// Agrega un profesor a la universidad si este no esta repetido
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
                g.Profesores.Add(i);

            return g;
        }

        /// <summary>
        /// Agrega una clase a la universidad si esta no esta repetida
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad j, EClases clase)
        {
            Profesor instructor;
            try
            {
                instructor = j == clase;

                Jornada jornada = new Jornada(clase, instructor);
                foreach (Alumno item in j.Alumnos)
                {
                    if (item == clase)
                        jornada += item;
                }
                j.Jornada.Add(jornada);
            }
            catch (SinProfesorException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return j;
        }
        #endregion

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
    }
}
