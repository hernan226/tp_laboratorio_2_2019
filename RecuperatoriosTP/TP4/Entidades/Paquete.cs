using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{

    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs e);

        public event DelegadoEstado InformaEstado;
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #region Propiedades
        /// <summary>
        /// Otorga acceso a la direccion de entrega
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }
        /// <summary>
        /// Otorga acceso al estado
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        /// <summary>
        /// Otorga acceso al tracking ID
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        #endregion
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        /// <param name="direccionEntega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntega, string trackingID)
        {
            this.DireccionEntrega = direccionEntega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;
        }

        #region Metodos
        /// <summary>
        /// Simula el trayecto del mensaje
        /// </summary>
        public void MockCicloDeVida()
        {
            do
            {
                Thread.Sleep(4000);

                if (this.Estado == EEstado.Ingresado)
                    Estado = EEstado.EnViaje;
                else
                    Estado = EEstado.Entregado;

                InformaEstado(this, new EventArgs());
            } while (this.Estado != EEstado.Entregado);

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Muestra los datos del paquete
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", this.TrackingID, this.DireccionEntrega);
        }
        /// <summary>
        /// Hace publicos los datos del paquete
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Verifica si los paquetes son iguales
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return (p1.TrackingID == p2.TrackingID);
        }
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        } 
        #endregion


        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
    }
}
