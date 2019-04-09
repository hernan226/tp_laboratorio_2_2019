using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {

        /// <summary>
        /// Toma los dos numeos recibidos y realiza la operacion indicada en la variable operador.
        /// </summary>
        /// <param name="num1">Primer numero a operar.</param>
        /// <param name="num2">Segundo numero a operar.</param>
        /// <param name="operador">El operador.</param>
        /// <returns>Devuelve el resultado de la operacion y en caso de no poder retona cero.</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            switch (ValidadOperador(operador))
            {
            case "/":
            return num1 / num2;
            case "*":
            return num1 * num2;
            case "-":
            return num1 - num2;
            case "+":
            return num1 + num2;
            default:
            return 0;
            }      
        }

        /// <summary>
        /// Valida que el operador recibido sea efectivamente uno,
        /// caso contrario, retonara +.
        /// </summary>
        /// <param name="operador">Operador a validar.</param>
        /// <returns>El operador validado.</returns>
        static string ValidadOperador(string operador)
        {
            switch (operador)
            {
            case "/":
                return "/";
            case "*":
                return "*";
            case "-":
                return "-";
            default:
                return "+";
            }
        }
    }
}
