using System;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class Testing
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CorreoNotNull()
        {
            Correo testCoreo = null;

            testCoreo += new Paquete("test","test");
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdepetidoException))]
        public void PaqueteRepetido()
        {
            Correo testCoreo = new Correo();

            testCoreo += new Paquete("test", "test");
            testCoreo += new Paquete("test", "test");
        }
    }
}
