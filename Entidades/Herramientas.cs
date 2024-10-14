using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Herramientas
    {
        public Herramientas(string codigo, string nombre, string medida, string descripcion, int marca)
        {
            Codigo = codigo;
            Nombre = nombre;
            Medida = medida;
            Descripcion = descripcion;
            Marca = marca;
        }

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Medida { get; set; }
        public string Descripcion { get; set; }
        public int Marca { get; set; }
    }
}
