namespace Main
{
  partial class FormCalculadora
  {
    /// <summary>
    /// Variable del diseñador necesaria.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Limpiar los recursos que se estén usando.
    /// </summary>
    /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Código generado por el Diseñador de Windows Forms

    /// <summary>
    /// Método necesario para admitir el Diseñador. No se puede modificar
    /// el contenido de este método con el editor de código.
    /// </summary>
    private void InitializeComponent()
    {
            this.TxtNum1 = new System.Windows.Forms.TextBox();
            this.TxtNum2 = new System.Windows.Forms.TextBox();
            this.LblResultado = new System.Windows.Forms.Label();
            this.CmbOperador = new System.Windows.Forms.ComboBox();
            this.BtnOperar = new System.Windows.Forms.Button();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnConvertirABinario = new System.Windows.Forms.Button();
            this.BtnConvertirADecimal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtNum1
            // 
            this.TxtNum1.Location = new System.Drawing.Point(14, 28);
            this.TxtNum1.Name = "TxtNum1";
            this.TxtNum1.Size = new System.Drawing.Size(100, 20);
            this.TxtNum1.TabIndex = 0;
            // 
            // TxtNum2
            // 
            this.TxtNum2.Location = new System.Drawing.Point(253, 28);
            this.TxtNum2.Name = "TxtNum2";
            this.TxtNum2.Size = new System.Drawing.Size(100, 20);
            this.TxtNum2.TabIndex = 2;
            // 
            // LblResultado
            // 
            this.LblResultado.AutoSize = true;
            this.LblResultado.Location = new System.Drawing.Point(264, 9);
            this.LblResultado.Name = "LblResultado";
            this.LblResultado.Size = new System.Drawing.Size(55, 13);
            this.LblResultado.TabIndex = 3;
            this.LblResultado.Text = "Resultado";
            // 
            // CmbOperador
            // 
            this.CmbOperador.FormattingEnabled = true;
            this.CmbOperador.Items.AddRange(new object[] {
            "/",
            "*",
            "-",
            "+"});
            this.CmbOperador.Location = new System.Drawing.Point(163, 27);
            this.CmbOperador.Name = "CmbOperador";
            this.CmbOperador.Size = new System.Drawing.Size(43, 21);
            this.CmbOperador.TabIndex = 1;
            this.CmbOperador.Text = "/";
            // 
            // BtnOperar
            // 
            this.BtnOperar.Location = new System.Drawing.Point(51, 69);
            this.BtnOperar.Name = "BtnOperar";
            this.BtnOperar.Size = new System.Drawing.Size(75, 23);
            this.BtnOperar.TabIndex = 4;
            this.BtnOperar.Text = "Operar";
            this.BtnOperar.UseVisualStyleBackColor = true;
            this.BtnOperar.Click += new System.EventHandler(this.BtnOperar_Click);
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Location = new System.Drawing.Point(244, 69);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(75, 23);
            this.BtnCerrar.TabIndex = 6;
            this.BtnCerrar.Text = "Cerrar";
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Location = new System.Drawing.Point(146, 69);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.BtnLimpiar.TabIndex = 5;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnConvertirABinario
            // 
            this.BtnConvertirABinario.Enabled = false;
            this.BtnConvertirABinario.Location = new System.Drawing.Point(14, 98);
            this.BtnConvertirABinario.Name = "BtnConvertirABinario";
            this.BtnConvertirABinario.Size = new System.Drawing.Size(112, 23);
            this.BtnConvertirABinario.TabIndex = 7;
            this.BtnConvertirABinario.Text = "Convertir a binario";
            this.BtnConvertirABinario.UseVisualStyleBackColor = true;
            this.BtnConvertirABinario.Click += new System.EventHandler(this.BtnConvertirABinario_Click);
            // 
            // BtnConvertirADecimal
            // 
            this.BtnConvertirADecimal.Enabled = false;
            this.BtnConvertirADecimal.Location = new System.Drawing.Point(244, 98);
            this.BtnConvertirADecimal.Name = "BtnConvertirADecimal";
            this.BtnConvertirADecimal.Size = new System.Drawing.Size(109, 23);
            this.BtnConvertirADecimal.TabIndex = 8;
            this.BtnConvertirADecimal.Text = "Convertir a decimal";
            this.BtnConvertirADecimal.UseVisualStyleBackColor = true;
            this.BtnConvertirADecimal.Click += new System.EventHandler(this.BtnConvertirADecimal_Click);
            // 
            // FormCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(365, 129);
            this.Controls.Add(this.BtnConvertirADecimal);
            this.Controls.Add(this.BtnConvertirABinario);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.BtnOperar);
            this.Controls.Add(this.CmbOperador);
            this.Controls.Add(this.LblResultado);
            this.Controls.Add(this.TxtNum2);
            this.Controls.Add(this.TxtNum1);
            this.Name = "FormCalculadora";
            this.Text = "Calculadora de Hernan Coronel del curso 2ºD";
            this.Load += new System.EventHandler(this.FormCalculadora_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox TxtNum1;
    private System.Windows.Forms.TextBox TxtNum2;
    private System.Windows.Forms.Label LblResultado;
    private System.Windows.Forms.ComboBox CmbOperador;
    private System.Windows.Forms.Button BtnOperar;
    private System.Windows.Forms.Button BtnCerrar;
    private System.Windows.Forms.Button BtnLimpiar;
    private System.Windows.Forms.Button BtnConvertirADecimal;
    private System.Windows.Forms.Button BtnConvertirABinario;
  }
}

