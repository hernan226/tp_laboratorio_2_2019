﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        public Dulce(EMarca marca, string patente, ConsoleColor color)
            :base(patente,marca,color)
        {
        }

        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        public override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }

        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine((string)this);
            sb.AppendLine(string.Format("CALORIAS : {0}", this.CantidadCalorias));
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
