using System;
using Clases_Instanciables;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class Testing
    {
        /// <summary>
        /// Verifica que el alumno no este repetido
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestAlumnoRepetido()
        {
            Universidad uni = new Universidad();
            Alumno alu1;
            Alumno alu2;

            alu1 = new Alumno(1, "test", "test", "123",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino,
                Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            alu2 = new Alumno(1, "test", "test", "123",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino,
                Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);

            uni += alu1;
            uni += alu2;
        }
        /// <summary>
        /// Verifica que el DNI sea valido
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDNI()
        {
            Alumno TestAlumno;

            TestAlumno = new Alumno(1, "test", "test", "-123",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino,
                Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
        }

        /// <summary>
        /// Verifica que el DNI pertenezca a un argentino\a
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidadInvalidaLocal()
        {
            Alumno TestPersona;

            TestPersona = new Alumno(1, "test", "test", "123",
                EntidadesAbstractas.Persona.ENacionalidad.Extranjero,
                Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);

        }

        /// <summary>
        /// Verifica que el DNI pertenezca a un extranjero\a
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidadInvalidaExtranjero()
        {
            Alumno TestPersona;

            TestPersona = new Alumno(1, "test", "test", "90000000",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino,
                Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
        }       

        /// <summary>
        /// Verifica que el apellido no sea nulo.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestApellido()
        {
            Alumno TestAlumno;

            TestAlumno = new Alumno(1, "test", null, "123",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino,
                Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);

        }

        /// <summary>
        /// Verifica que el nombre no sea nulo.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNombre()
        {
            Alumno TestAlumno;

            try
            {
                TestAlumno = new Alumno(1, null, "test", "123",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino,
            Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
                Assert.Fail();
            }
            catch (NullReferenceException)
            {
                //Validado con exito
            }

        }

    }
}
