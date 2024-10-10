using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios
    {
        public Usuarios(string nombre, string apellidoP, string apellidoM, string fechaNacimiento, string rfc, string nic, string tipo, string clave)
        {
            Nombre = nombre;
            ApellidoP = apellidoP;
            ApellidoM = apellidoM;
            FechaNacimiento = fechaNacimiento;
            RFC = rfc;
            Nic = nic;
            Tipo = tipo;
            Clave = clave;
        }

        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string FechaNacimiento { get; set; }
        public string RFC {  get; set; }
        public string Nic { get; set; }
        public string Tipo { get; set; }
        public string Clave { get; set; }
    }
}
