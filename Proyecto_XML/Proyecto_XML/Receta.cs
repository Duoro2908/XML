using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_XML
{
    public class Receta
    {
        public string Nombre { get; set; }
        public string Categoria { get; set; } 
        public List<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();
    }
}
