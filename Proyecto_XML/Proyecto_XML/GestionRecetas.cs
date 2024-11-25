using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Proyecto_XML
{
    public class GestionRecetas
    {
        public List<Receta> ListaRecetas { get; set; } = new List<Receta>();
        private string rutaArchivo = "recetas.xml";

        public GestionRecetas()
        {
            if (ListaRecetas.Count == 0)
            {
                InicializarRecetasPredefinidas();
            }
        }
    
        private void InicializarRecetasPredefinidas()
        {
            ListaRecetas.Add(new Receta
            {
                Nombre = "Vigorón",
                Categoria = "Comida Tipica Nica",
                Ingredientes = new List<Ingrediente>
                {
                    new Ingrediente { Nombre = "Yuca", Cantidad = 300, Unidad = "gramos" },
                    new Ingrediente { Nombre = "Chicharrón", Cantidad = 200, Unidad = "gramos" },
                    new Ingrediente { Nombre = "Cebolla", Cantidad = 1, Unidad = "unidad" },
                    new Ingrediente { Nombre = "Tomate", Cantidad = 1, Unidad = "unidad" },
                    new Ingrediente { Nombre = "Cilantro", Cantidad = 1, Unidad = "ramita" }
                }
            });

            ListaRecetas.Add(new Receta
            {
                Nombre = "Gallo Pinto",
                Categoria = "Comida Tipica Nica",
                Ingredientes = new List<Ingrediente>
                {
                    new Ingrediente { Nombre = "Arroz", Cantidad = 200, Unidad = "gramos" },
                    new Ingrediente { Nombre = "Frijoles", Cantidad = 150, Unidad = "gramos" },
                    new Ingrediente { Nombre = "Cebolla", Cantidad = 1, Unidad = "unidad" },
                    new Ingrediente { Nombre = "Pimiento", Cantidad = 1, Unidad = "unidad" },
                    new Ingrediente { Nombre = "Ajo", Cantidad = 2, Unidad = "dientes" },
                    new Ingrediente { Nombre = "Aceite", Cantidad = 3, Unidad = "cucharadas" }
                }
            });

            ListaRecetas.Add(new Receta
            {
                Nombre = "Sopa de Res",
                Categoria = "Comida Tipica Tipica Nica",
                Ingredientes = new List<Ingrediente>
                {
                    new Ingrediente { Nombre = "Carne de res", Cantidad = 300, Unidad = "gramos" },
                    new Ingrediente { Nombre = "Papa", Cantidad = 3, Unidad = "unidades" },
                    new Ingrediente { Nombre = "Zanahoria", Cantidad = 2, Unidad = "unidades" },
                    new Ingrediente { Nombre = "Maíz", Cantidad = 2, Unidad = "mazorcas" },
                    new Ingrediente { Nombre = "Cilantro", Cantidad = 1, Unidad = "ramita" },
                    new Ingrediente { Nombre = "Ajo", Cantidad = 3, Unidad = "dientes" }
                }
            });
        }

       
        public void AñadirReceta(string nombreReceta, string categoria)
        {
            try
            {
                ListaRecetas.Add(new Receta
                {
                    Nombre = nombreReceta,
                    Categoria = categoria
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al añadir receta: " + ex.Message);
            }

        }
        public void BorrarTodasLasRecetas()
        {
            try
            {
                ListaRecetas.Clear(); 
                if (File.Exists(rutaArchivo))
                {
                    File.Delete(rutaArchivo); 
                }
                MessageBox.Show("Todas las recetas han sido borradas.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar recetas: " + ex.Message);
            }
        }
     
        public void AñadirIngrediente(int indiceReceta, string nombreIngrediente, double cantidad, string unidad)
        {
            try
            {
                if (indiceReceta >= 0 && indiceReceta < ListaRecetas.Count)
                {
                    var recetaSeleccionada = ListaRecetas[indiceReceta];
                    recetaSeleccionada.Ingredientes.Add(new Ingrediente
                    {
                        Nombre = nombreIngrediente,
                        Cantidad = cantidad,
                        Unidad = unidad
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al añadir ingrediente: " + ex.Message);
            }
        }

   
        public void GuardarDatosEnXML()
        {
            try
            {
                using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Receta>));
                    serializer.Serialize(fs, ListaRecetas);
                }
                MessageBox.Show("Datos guardados en XML exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en XML: " + ex.Message);
            }
        }

 
        public void CargarDatosDesdeXML()
        {
            if (File.Exists(rutaArchivo))
            {
                try
                {
                    using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Receta>));
                        ListaRecetas = (List<Receta>)serializer.Deserialize(fs);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos desde XML: " + ex.Message);
                }
            }
        }
    }
}
        
    