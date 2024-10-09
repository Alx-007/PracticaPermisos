using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios
    {
        public Usuarios(string nombre, string apellidos, string contraseña, string tipo)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Contraseña = contraseña;
            Tipo = tipo;
        }

        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Contraseña { get; set; }
        public string Tipo { get; set; }
    }
}
