using Clases_Instanciables;
using Excepciones;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{   
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda datos en un archivo XML.
        /// </summary>
        /// <param name="archivos">Direccion del archivo.</param>
        /// <param name="datos">Datos recibidos.</param>
        /// <returns>Devuelve true si pudo guardar o arroja una
        /// excepcion si no pudo.</returns>
        public bool guardar(string archivos, T datos)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            try
            {
                using (XmlTextWriter xtw = new XmlTextWriter(archivos, Encoding.UTF8))
                    xs.Serialize(xtw, datos);

                return true;
            }
            catch (ArchivosException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lee de un archivo XML los datos
        /// y los devuelve por out.
        /// </summary>
        /// <param name="archivos">Direccion del archivo.</param>
        /// <param name="datos">Salida de la universidad.</param>
        /// <returns>Devuelve true si leyo con exito o lanza una
        /// excepcion si no pudo</returns>
        public bool leer(string archivos, out T datos)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            T aux;
            try
            {
                using (XmlTextReader xtr = new XmlTextReader(archivos))
                    aux = (T)xs.Deserialize(xtr);
                datos = aux;

                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }
    }
}