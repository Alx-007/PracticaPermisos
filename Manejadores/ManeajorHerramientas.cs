using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using AccesoDatos;

namespace Manejadores
{
    public class ManeajorHerramientas
    {
        Base b = new Base("localhost", "root", "", "formulario");

        public string Guardar(TextBox Codigo, TextBox Nombre, TextBox Medida, TextBox Descripcion, TextBox Marca)
        {
            try
            {
                return b.Comando($"INSERT INTO Herramientas VALUES('{Codigo.Text}', '{Nombre.Text}', {double.Parse(Medida.Text)}, '{Descripcion.Text}', {int.Parse(Marca.Text)})");
            }
            catch (Exception)
            {
                return "Error Valor";
            }
        }

        public void Mostrar(DataGridView Tabla, string filtro)
        {
            Tabla.Columns.Clear();
            Tabla.DataSource = b.Consultar($"select * from Herramientas where CodigoHerramienta like '%{filtro}%'", "Herramientas").Tables[0];
            Tabla.AutoResizeColumns();
            Tabla.AutoResizeRows();
        }

        public void Borrar(string Codigo, string Dato)
        {
            DialogResult rs = MessageBox.Show($"Estas seguro de eliminar a {Dato}", "!Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                b.Comando($"delete from Herramientas where CodigoHerramienta={Codigo}");
                MessageBox.Show("Registro Eliminado", "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Modificar(TextBox Codigo, TextBox Nombre, TextBox Medida, TextBox Descripcion, TextBox Marca)
        {
            b.Comando($"update Herramientas set codigo='{Codigo.Text}', nombre='{Nombre.Text}', medida='{double.Parse(Medida.Text)}', descripcion='{Descripcion.Text}', marca='{int.Parse(Marca.Text)}', where CodigoHerramienta={Codigo}");
            MessageBox.Show("Registro Modificado", "!Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
