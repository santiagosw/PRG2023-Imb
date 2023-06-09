using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InmobiliariaApp
{
    public partial class MainForm : Form
    {
        private List<Casa> casas;

        public MainForm()
        {
            InitializeComponent();
            casas = new List<Casa>();
        }

        private void btnAgregarCasa_Click(object sender, EventArgs e)
        {
            // Obtener datos de la casa desde los controles de la interfaz
            string direccion = txtDireccion.Text;
            decimal precio = decimal.Parse(txtPrecio.Text);
            bool disponible = chkDisponible.Checked;
            DateTime fechaConstruccion = dtpFechaConstruccion.Value;

            // Crear objeto Casa
            Casa nuevaCasa = new Casa(direccion, precio, disponible, fechaConstruccion);

            // Agregar la casa a la lista
            casas.Add(nuevaCasa);

            // Limpiar los controles de entrada
            LimpiarCamposCasa();

            // Actualizar la lista de casas en la interfaz
            ActualizarListaCasas();
        }

        private void ActualizarListaCasas()
        {
            // Limpiar la lista de casas en la interfaz
            lstCasas.Items.Clear();

            // Agregar las casas a la lista en la interfaz
            foreach (Casa casa in casas)
            {
                lstCasas.Items.Add(casa.Direccion);
            }
        }

        private void LimpiarCamposCasa()
        {
            txtDireccion.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            chkDisponible.Checked = false;
            dtpFechaConstruccion.Value = DateTime.Now;
        }

        private void lstCasas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el índice seleccionado de la lista de casas
            int indiceSeleccionado = lstCasas.SelectedIndex;

            if (indiceSeleccionado >= 0 && indiceSeleccionado < casas.Count)
            {
                // Obtener la casa seleccionada
                Casa casaSeleccionada = casas[indiceSeleccionado];

                // Mostrar los detalles de la casa en los controles de la interfaz
                txtDireccionDetalle.Text = casaSeleccionada.Direccion;
                txtPrecioDetalle.Text = casaSeleccionada.Precio.ToString();
                chkDisponibleDetalle.Checked = casaSeleccionada.Disponible;
                dtpFechaConstruccionDetalle.Value = casaSeleccionada.FechaConstruccion;
            }
        }

    }
}