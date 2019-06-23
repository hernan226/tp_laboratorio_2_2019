using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Correo correo;
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }

        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();

            foreach (Paquete item in correo.Paquetes)
            {
                switch (item.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(item);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(item);
                        break;
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(item);
                        break;
                }
            }
        }
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            Correo aux = (Correo)elemento;
            string path = string.Format(@"{0}\salida.txt",
                   Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

            if (elemento != null)
            {
                this.rtbMostrar.Text = aux.MostrarDatos(aux);

                try
                {
                    foreach (var item in aux.Paquetes)
                    {
                        item.ToString().Guardar(path);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                throw new ArgumentNullException();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Paquete pack = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
                pack.InformaEstado += paq_InformaEstado;

                this.correo += pack;
                this.ActualizarEstados();
            }
            catch (TrackingIdepetidoException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
                this.ActualizarEstados();
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinDeEntregas();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void lstEstadoEntregado_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.cmsListas.Show(Control.MousePosition);
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.rtbMostrar.Text = lstEstadoEntregado.SelectedItem.ToString();
        }

    }
}
