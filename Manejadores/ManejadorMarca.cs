using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorMarca
    {
        Base b = new Base("localhost", "root", "", "formulario");

        public string Guardar(TextBox Nombre, TextBox Descripcion)
        {
            try
            {
                return b.Comando($"INSERT INTO marca VALUES(NULL, '{Nombre.Text}', '{Descripcion.Text}')");
            }
            catch (Exception)
            {
                return "Error Valor";
            }
        }

        public void Mostrar(DataGridView Tabla, string filtro)
        {
            Tabla.Columns.Clear();
            Tabla.DataSource = b.Consultar($"select * from marca where nombre like '%{filtro}%'", "marca").Tables[0];
            Tabla.AutoResizeColumns();
            Tabla.AutoResizeRows();
        }

        public void Borrar(int id, string Dato)
        {
            DialogResult rs = MessageBox.Show($"Estas seguro de eliminar a {Dato}", "!Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                b.Comando($"delete from marca where idMarcas={id}");
                MessageBox.Show("Registro Eliminado", "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Modificar(int id, TextBox Nombre, TextBox Descripcion)
        {
            b.Comando($"update marca set nombre = '{Nombre.Text}', descripcion = '{Descripcion.Text}', WHERE idMarcas = {id};");
            MessageBox.Show("Registro Modificado", "!Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
