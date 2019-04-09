using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public class Numero
  {
    /// <summary>
    /// Atributo que guarda el numero a operar.
    /// </summary>
    double numero;

        /// <summary>
        /// Constructor por defecto.
        /// Asigna cero al atributo <see cref="numero"/>.
        /// </summary>
        public Numero() => this.numero = 0;

        /// <summary>
        /// Asigna el numero de presicion doble al atributo <see cref="numero"/>.
        /// </summary>
        /// <param name="num">Numero que se asignara.</param>
        public Numero(double num) => this.numero = num;

        /// <summary>
        /// Asigna el numero recibido en un string al atributo <see cref="numero"/>
        /// por medio de la propiedad <see cref="SetNumero"/>.
        /// </summary>
        /// <param name="strNumero">Numero que se asignara.</param>
        public Numero(string strNumero) => this.SetNumero = strNumero;

        /// <summary>
        /// Propiedad que guarda en el atributo <see cref="numero"/>
        /// el numero recibido en string validado 
        /// </summary>
        string SetNumero { set => numero = ValidarNumero(value); }
    
        /// <summary>
        /// Valida que el numero dento del string sea efectivamente uno,
        /// caso contrario, retorna cero.
        /// </summary>
        /// <param name="strNumero">String con el numero a validar.</param>
        /// <returns>El numero validado.</returns>
        private static double ValidarNumero(string strNumero)
        {
            double num;

            return double.TryParse(strNumero, out num) ? num : 0;
        }

        /// <summary>
        /// Convierte el numero recibido a binario y lo retorna como string.
        /// </summary>
        /// <param name="num">Numero a convertir.</param>
        /// <returns>Un numero convertido a binario o "Valor invalido." en caso de error.</returns>
        public static string DecimalBinario(string num)
        {
            double doble;
            return double.TryParse(num, out doble) ? DecimalBinario(doble) : "Valor invalido";
        }

        /// <summary>
        /// Convierte el numero recibido a binario y lo retorna como string.
        /// </summary>
        /// <param name="doble">Numero a convertir.</param>
        /// <returns>Un numero convertido a binario.</returns>
        public static string DecimalBinario(double doble)
        {
            string cadena = "";
            int numero = (int)doble;
        
            if (numero > 0)
            {
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    cadena = "0" + cadena;
                    else
                    cadena = "1" + cadena;
                    numero = (numero / 2);
                }
            }
            else if (numero == 0)
                cadena = "0";

            return cadena;
        }

        /// <summary>
        /// Convierte un numero binario a decimal.
        /// </summary>
        /// <param name="binario">Numero binario a convertir.</param>
        /// <returns>Numero convertido.</returns>
        public static string BinarioDecimal(string binario)
        {
            return esBinario(binario) ? binario : "Valor invalido";
        }

        /// <summary>
        /// Comprueba si el numero recibido es un binario valido.
        /// </summary>
        /// <param name="binario">Binario a validar.</param>
        /// <returns>Retorna true si es valido y false si no.</returns>
        static bool esBinario(string binario)
        {
          foreach (char obj in binario)
            {
                if (obj != '0' && obj != '1')
                    return false;
            }

          return true;
        }

        /// <summary>
        /// suma dos Numeros.
        /// </summary>
        /// <param name="n1">Numero a sumar.</param>
        /// <param name="n2">Numero a sumar.</param>
        /// <returns>Resultado de la suma.</returns>
        public static double operator +(Numero n1, Numero n2)
        {
          return n1.numero + n2.numero;
        }

        /// <summary>
        /// Resta dos numeros.
        /// </summary>
        /// <param name="n1">Numero a restar.</param>
        /// <param name="n2">Numero que resta.</param>
        /// <returns>Resultado de la resta.</returns>
        public static double operator -(Numero n1, Numero n2)
        {
          return n1.numero - n2.numero;
        }

        /// <summary>
        /// Multiplica dos numeros.
        /// </summary>
        /// <param name="n1">Numero a multiplicar.</param>
        /// <param name="n2">Numero a multiplicar.</param>
        /// <returns>Resultado de la multiplicacion.</returns>
        public static double operator *(Numero n1, Numero n2)
        {
          return n1.numero * n2.numero;
        }

        /// <summary>
        /// Divide dos numeros.
        /// </summary>
        /// <param name="n1">Dividendo.</param>
        /// <param name="n2">Divisor.</param>
        /// <returns>Resultado de la division o cero si el divisor es cero.</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            return n2.numero == 0 ? 0 : n1.numero / n2.numero;
        }
    }
}
