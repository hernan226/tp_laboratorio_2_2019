using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        static PaqueteDAO()
        {
            comando = new SqlCommand();
            conexion = new SqlConnection(
                "Data Source =.\\SQLEXPRESS; Initial Catalog = correo-sp-2017; Integrated Security = True");
            comando.CommandType = CommandType.Text;
            comando.Connection = conexion;
        }
        /// <summary>
        /// Guarda en la base de datos
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            string yo = "Coronel Hernan";
            try
            {
                conexion.Open();
                comando.CommandText = string.Format("INSERT INTO correo-sp-2017 (codPatente, tipoCodigo) " +
                  "VALUES({0}, {1}, {2})", p.DireccionEntrega, p.TrackingID, yo);

                comando.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo guardar en la base", ex);
            }
            finally
            {
                conexion.Close();
            }

        }

    }
}
