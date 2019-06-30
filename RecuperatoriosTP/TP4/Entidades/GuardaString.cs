using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GuardaString
    {

        /// <summary>
        /// Guarda los datos en un archivo de texto en el escritorio
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, true))
                    sw.WriteLine(texto);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
