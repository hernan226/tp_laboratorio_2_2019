using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
  public partial class FormCalculadora : Form
  {
    
    public FormCalculadora()
    {
      InitializeComponent();
    }

    private void FormCalculadora_Load(object sender, EventArgs e)
    {
      this.CmbOperador.DropDownStyle = ComboBoxStyle.DropDownList;
      this.MinimizeBox = false;
      this.MaximizeBox = false;
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.CenterToScreen();
    }
    private static double Operar(string num1, string num2, string operador)
    {
      double doble2, doble1;
      if (double.TryParse(num1, out doble1) && double.TryParse(num2, out doble2))
      {
        switch (operador)
        {
          case "/":
            return doble1 / doble2;
          case "*":
            return doble1 * doble2;
          case "-":
            return doble1 - doble2;
          case "+":
            return doble1 + doble2;
          default:
            return 0;
        }
      }
      return 0;
    }

    private void BtnLimpiar_Click(object sender, EventArgs e)
    {
      this.TxtNum1.Text = "";
      this.TxtNum2.Text = "";
      this.CmbOperador.Text = "/";
      this.LblResultado.Text = "Resultado";
    }

    private void BtnOperar_Click(object sender, EventArgs e)
    {
      this.LblResultado.Text = ""+
        Operar(this.TxtNum1.Text, this.TxtNum2.Text, this.CmbOperador.Text);
    }

    private void BtnCerrar_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void BtnConvertirABinario_Click(object sender, EventArgs e)
    {
      double num;
      double.TryParse(this.LblResultado.Text, out num);
      string cadena="";
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

      this.LblResultado.Text = cadena;
    }

    private void BtnConvertirADecimal_Click(object sender, EventArgs e)
    {
      if (esBinario(this.LblResultado.Text))
      {
        this.LblResultado.Text = Convert.ToInt32(this.LblResultado.Text, 2).ToString();
      }
      else
        this.LblResultado.Text = "Valor invalido";
    }

    static bool esBinario(string palabra)
    {
      foreach (var obj in palabra)
        if (obj != '0' && obj != '1')
          return false;
      return true;
    }
  }
}
