using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Refacciones
    {
        public Refacciones(string codigo, string nombre, string descripcion, int marca)
        {
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            Marca = marca;
        }

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Marca { get; set; }
    }
}
