using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_XML
{
    public partial class Form1 : Form
    {
        private GestionRecetas gestionRecetas = new GestionRecetas();

        public Form1()
        {
            InitializeComponent();
            gestionRecetas.CargarDatosDesdeXML();
            CargarRecetasEnComboBox();
            
        }
        private void añadirRecetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreReceta = txtNombreReceta.Text;
                string categoria = txtCategoria.Text;

                gestionRecetas.AñadirReceta(nombreReceta, categoria);
                cmbReceta.Items.Add(nombreReceta);

                txtNombreReceta.Clear();
                txtCategoria.Clear();

                MessageBox.Show("Receta añadida exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al añadir receta: " + ex.Message);
            }
        }
        private void añadirIngredientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbReceta.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona una receta para añadir ingredientes");
                    return;
                }

                string nombreIngrediente = txtNombreIngrediente.Text;
                double cantidad = double.Parse(txtCantidad.Text);
                string unidad = txtUnidad.Text;

                int recetaIndex = cmbReceta.SelectedIndex;
                gestionRecetas.AñadirIngrediente(recetaIndex, nombreIngrediente, cantidad, unidad);

                txtNombreIngrediente.Clear();
                txtCantidad.Clear();
                txtUnidad.Clear();

                MessageBox.Show("Ingrediente añadido exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al añadir ingrediente: " + ex.Message);
            }
        }
        private void verRecetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listRecetas.Items.Clear();
            foreach (var receta in gestionRecetas.ListaRecetas)
            {
                listRecetas.Items.Add($"Receta: {receta.Nombre}, Categoría: {receta.Categoria}");
                foreach (var ingrediente in receta.Ingredientes)
                {
                    listRecetas.Items.Add($"Ingrediente: {ingrediente.Nombre}, Cantidad: {ingrediente.Cantidad}, Unidad: {ingrediente.Unidad}");
                }

            }
        }
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gestionRecetas.GuardarDatosEnXML();
            MessageBox.Show("Datos guardados correctamente");
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            MessageBox.Show("Gracias por usar nuestro sistema");
        
    }    
        private void CargarRecetasEnComboBox()
        {
            cmbReceta.Items.Clear();
            foreach (var receta in gestionRecetas.ListaRecetas)
            {
                cmbReceta.Items.Add(receta.Nombre);
            }

            if (cmbReceta.Items.Count > 0)
            {
                cmbReceta.SelectedIndex = 0; 
            }
        }
         private void MostrarIngredientesDeReceta(int indiceReceta)
            {
            listRecetas.Items.Clear();

            if (indiceReceta >= 0 && indiceReceta < gestionRecetas.ListaRecetas.Count)
            {
                var receta = gestionRecetas.ListaRecetas[indiceReceta];

                listRecetas.Items.Add($"Receta: {receta.Nombre}");
                listRecetas.Items.Add($"Categoría: {receta.Categoria}");
                listRecetas.Items.Add("Ingredientes:");

                foreach (var ingrediente in receta.Ingredientes)
                {
                    listRecetas.Items.Add($"- {ingrediente.Nombre}: {ingrediente.Cantidad} {ingrediente.Unidad}");
                }
            }
        }
          private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
             {
              var confirmacion = MessageBox.Show(
              "Estas seguro de que deseas borrar todas las recetas? Esta acción no se puede deshacer",
              "Confirmar eliminación",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Warning
             );

              if (confirmacion == DialogResult.Yes)
              {
                     gestionRecetas.BorrarTodasLasRecetas(); 
                     cmbReceta.Items.Clear(); 
                     listRecetas.Items.Clear();
              }
        }   
          private void cmbReceta_SelectedIndexChanged(object sender, EventArgs e)
            {
            int indiceSeleccionado = cmbReceta.SelectedIndex;

             if (indiceSeleccionado >= 0)
             {
                MostrarIngredientesDeReceta(indiceSeleccionado);
             }
        }
    }
}

