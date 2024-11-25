using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_JSON
{
    public class Carne
    {
        private readonly string rutaArchivo;

        public Carne(string ruta)
        {
            rutaArchivo = ruta;
        }

        public void GuardarDatos(List<Tipo_Carne> listaCarnes)
        {
            var json = JsonSerializer.Serialize(listaCarnes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(rutaArchivo, json);
        }

        public List<Tipo_Carne> LeerDatos()
        {
            if (!File.Exists(rutaArchivo)) return new List<Tipo_Carne>();
            var json = File.ReadAllText(rutaArchivo);
            return JsonSerializer.Deserialize<List<Tipo_Carne>>(json) ?? new List<Tipo_Carne>();
        }
    }
}

