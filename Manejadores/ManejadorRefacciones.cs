using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;
using Entidades;

namespace Manejadores
{
    public class ManejadorRefacciones
    {
        Base b = new Base("localhost", "root", "", "formulario");

        public string Guardar(TextBox Codigo, TextBox Nombre, TextBox Descripcion, TextBox Marca)
        {
            try
            {
                return b.Comando($"INSERT INTO Refacciones VALUES(NULL, '{Codigo.Text}', '{Nombre.Text}', '{Descripcion.Text}', {int.Parse(Marca.Text)})");
            }
            catch (Exception)
            {
                return "Error Valor";
            }
        }

        public void Mostrar(DataGridView Tabla, string filtro)
        {
            Tabla.Columns.Clear();
            Tabla.DataSource = b.Consultar($"select * from Refacciones where idRefaccion like '%{filtro}%'", "Refacciones").Tables[0];
            Tabla.AutoResizeColumns();
            Tabla.AutoResizeRows();
        }

        public void Borrar(int id, string Dato)
        {
            DialogResult rs = MessageBox.Show($"Estas seguro de eliminar a {Dato}", "!Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                b.Comando($"delete from Refacciones where idRefaccion={id}");
                MessageBox.Show("Registro Eliminado", "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Modificar(int id, TextBox Codigo, TextBox Nombre, TextBox Descripcion, TextBox Marca)
        {
            b.Comando($"update refacciones set codigo='{Codigo.Text}', nombre='{Nombre.Text}', descripcion='{Descripcion.Text}', marca='{int.Parse(Marca.Text)}', where idRefaccion={id}");
            MessageBox.Show("Registro Modificado", "!Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
