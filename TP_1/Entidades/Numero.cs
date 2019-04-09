using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public class Numero
  {
    double numero;

    public Numero()
    {
      this.numero = 0;
    }
    public Numero(double num)
    {
      this.numero = num;
    }
    public Numero(string strNumero)
    {
      this.SetNumero = strNumero;
    }

    string SetNumero { set => numero = ValidarNumero(value); }

    private double ValidarNumero(string strNumero)
    {
      double num;

      if (double.TryParse(strNumero, out num))
        return num;

      return 0;
    }

    public static string DecimalBinario(string num)
    {
      double doble;
      string cadena = "";
      if (double.TryParse(num, out doble))
        return DecimalBinario(doble);

      return cadena;
    }
    public static string DecimalBinario(double num)
    {
      string cadena = "";
      if ((int)num > 0)
      {
        while ((int)num > 0)
        {
          if ((int)num % 2 == 0)
            cadena = "0" + cadena;
          else
            cadena = "1" + cadena;
          num = ((int)num / 2);
        }
      }
      else if ((int)num == 0)
      {
        cadena = "0";
      }
      else
        cadena = "Valor invalido";

      return cadena;
    }
    public static string BinarioDecimal(string binario)
    {
      if (esBinario(binario))
        return binario;
      else
        return "Valor invalido";
    }

    static bool esBinario(string palabra)
    {
      foreach (var obj in palabra)
        if (obj != '0' && obj != '1')
          return false;
      return true;
    }

    public static double operator +(Numero n1, Numero n2)
    {
      return n1.numero + n2.numero;
    }
    public static double operator -(Numero n1, Numero n2)
    {
      return n1.numero - n2.numero;
    }
    public static double operator *(Numero n1, Numero n2)
    {
      return n1.numero * n2.numero;
    }
    public static double operator /(Numero n1, Numero n2)
    {
      if (n2.numero == 0)
        return 0;

      return n1.numero / n2.numero;
    }
  }
}
