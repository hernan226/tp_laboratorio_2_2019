using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Excepcion para cuando se repite la tracking id
    /// </summary>
    public class TrackingIdepetidoException : Exception
    {
        public TrackingIdepetidoException(string mensaje)
            : base(mensaje)
        { }
        public TrackingIdepetidoException(string mensaje, Exception inner)
            : base(mensaje, inner)
        { }
    }
}
