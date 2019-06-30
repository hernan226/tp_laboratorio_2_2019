using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        #region Constructores
        public Persona() { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.Dni = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }
        #endregion

        #region Propiedades

        /// <summary>
        /// Guarda o devuelve el apellido de la persona
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Guarda o devuelve el DNI de la persona
        /// </summary>
        public int Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                try
                {
                    this.dni = ValidarDni(this.nacionalidad, value);
                }
                catch (DniInvalidoException ex)
                {
                    throw ex;
                }
                catch (NacionalidadInvalidaException ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Guarda o devuelve la nacionalidad de la persona
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Guarda o devuelve el nombre de la persona
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Convierte el DNI recibido como string a int y lo guarda.
        /// Devuelve el DNI como strring
        /// </summary>
        public string StringToDni
        {
            get
            {
                return this.dni.ToString();
            }
            set
            {

                try
                {
                    this.dni = ValidarDni(this.nacionalidad, value);
                }
                catch (DniInvalidoException ex)
                {
                    throw ex;
                }
                catch (NacionalidadInvalidaException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Hace publicos los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("NOMBRE COMPLETO:  {0}, {1}", this.Apellido, this.Nombre));
            //sb.AppendLine(string.Format("DNI:  {0}", this.StringToDni));
            sb.AppendLine(string.Format("NACIONALIDAD:  {0}", this.Nacionalidad.ToString()));

            return sb.ToString();
        }

        /// <summary>
        /// valida que el DNI se condiga con la nacionalidad y sea un DNI valido
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="dato">DNI</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato >= 1 && dato <= 89999999)
            {
                if (nacionalidad == ENacionalidad.Argentino)
                {
                    return dato;
                }
                else
                    throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
            }
            else if (dato >= 90000000 && dato <= 99999999)
            {
                if (nacionalidad == ENacionalidad.Extranjero)
                {
                    return dato;
                }
                else
                    throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
            }
            else
                throw new DniInvalidoException("El numero de DNI no es valido (menor a 0 o mayor a 99999999)");

        }

        /// <summary>
        /// valida que el DNI se condiga con la nacionalidad y sea un DNI valido
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="dato">DNI</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            if (int.TryParse(dato, out dni))
                return this.ValidarDni(nacionalidad, dni);
            else
                throw new DniInvalidoException("El numero de DNI no es valido (Caracteres invalidos)");
        }

        /// <summary>
        /// Valida que el nombre sea valido y no sea null
        /// </summary>
        /// <param name="dato">nombre recibido</param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            if (dato != null)
            {
                Regex nombre = new Regex(@"^[a-zA-Z]+$");

                if (nombre.IsMatch(dato))
                    return dato;
                else
                    return "";
            }
            else
                throw new ArgumentNullException();
        }

        #endregion
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
    }
}
