using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_JSON
{
    public class Tipo_Carne
    {
        public string Nombre { get; set; }
        public double PrecioPorKilo { get; set; }
        public string Descripcion { get; set; }

        public Tipo_Carne(string nombre, double precioPorKilo, string descripcion)
        {
            Nombre = nombre;
            PrecioPorKilo = precioPorKilo;
            Descripcion = descripcion;
        }
    }
}
