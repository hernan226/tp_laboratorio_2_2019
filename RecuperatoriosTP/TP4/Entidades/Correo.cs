using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Otorga acceso a la lista de paquetes
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        /// <summary>
        /// Termina con todos los hilos
        /// </summary>
        public void FinDeEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                if(item.IsAlive)
                    item.Abort();
            }
        }

        /// <summary>
        /// Muestra los datos de todos ls paquetes
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            Correo aux = (Correo)elementos;
            StringBuilder sb = new StringBuilder();
            foreach (Paquete p in aux.Paquetes)
            {
                sb.AppendLine(string.Format("{0} ({1})", p.ToString(),
                    p.Estado.ToString()));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Agrega un paquete al correo si este no esta,
        /// caso contrario arroja una excepcion
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            if (c != null)
            {
                Thread nuevoHilo;
                foreach (Paquete item in c.Paquetes)
                {
                    if (item == p)
                        throw new TrackingIdepetidoException("Paquete repetido");
                }
                c.Paquetes.Add(p);
                try
                {
                    nuevoHilo = new Thread(p.MockCicloDeVida);
                    nuevoHilo.Start();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                c.mockPaquetes.Add(nuevoHilo);

                return c;
            }
            else
                throw new ArgumentNullException();
        }
    }
}
