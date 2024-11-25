using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_JSON
{
    public partial class Form1 : Form
    {
        private readonly Carne carne;
        private List<Tipo_Carne> listaCarnes;

        public Form1()
        {
            InitializeComponent();
            carne = new Carne("carnes.json");
            listaCarnes = carne.LeerDatos();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombre = txtNombres.Text;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre no puede estar vacío.");
                return;
            }

            if (!double.TryParse(txtPrecios.Text, out double precio))
            {
                MessageBox.Show("Por favor, ingrese un precio válido.");
                return;
            }

            string descripcion = txtDescripciones.Text;

            listaCarnes.Add(new Tipo_Carne(nombre, precio, descripcion));
            carne.GuardarDatos(listaCarnes);
            MessageBox.Show("Tipo de carne añadido con éxito.");
            LimpiarCampos();
        }

        private void verDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstDatos.Items.Clear();
            foreach (var carne in listaCarnes)
            {
                lstDatos.Items.Add($"Nombre: {carne.Nombre}, Precio/Kilo: {carne.PrecioPorKilo}, Descripción: {carne.Descripcion}");
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show("¿Está seguro de que desea borrar todos los datos y salir?",
                                      "Confirmar",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
               
                listaCarnes.Clear();

                
                carne.GuardarDatos(listaCarnes);

                Close();
            }
        }
            private void LimpiarCampos()
            {
                txtNombres.Clear();
                txtPrecios.Clear();
                txtDescripciones.Clear();
            }
       }
}

