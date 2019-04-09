using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

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

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
          this.limpiar();
          this.BtnConvertirABinario.Enabled = false;
          this.BtnConvertirADecimal.Enabled = false;
        }

        private void BtnOperar_Click(object sender, EventArgs e)
        {
          this.BtnConvertirABinario.Enabled = true;
          this.LblResultado.Text = Operar(this.TxtNum1.Text, this.TxtNum2.Text, this.CmbOperador.Text).ToString();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
          this.Close();
        }

        private void BtnConvertirABinario_Click(object sender, EventArgs e)
        {
          this.BtnConvertirADecimal.Enabled = true;
          this.LblResultado.Text = Numero.DecimalBinario(this.LblResultado.Text);
          this.BtnConvertirABinario.Enabled = false;
        }

        private void BtnConvertirADecimal_Click(object sender, EventArgs e)
        {
          this.BtnConvertirABinario.Enabled = true;
          this.LblResultado.Text = Convert.ToInt32(Numero.BinarioDecimal(this.LblResultado.Text),2).ToString();
          this.BtnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// Reestablece todos los textbox, el combobox y el label a por defecto.
        /// </summary>
        void limpiar()
        {
          this.TxtNum1.Text = "";
          this.TxtNum2.Text = "";
          this.CmbOperador.Text = "/";
          this.LblResultado.Text = "Resultado";
        }

        /// <summary>
        /// Opera los numeros recibidos.
        /// </summary>
        /// <param name="numero1">Numero a operar.</param>
        /// <param name="numero2">Numero a operar.</param>
        /// <param name="operador">Operador.</param>
        /// <returns>Resultado.</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
          Numero num1 = new Numero(numero1);
          Numero num2 = new Numero(numero2);

          return Calculadora.Operar(num1, num2, operador);
        }


  }
}
