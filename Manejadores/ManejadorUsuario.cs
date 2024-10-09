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
    public class ManejadorUsuario
    {
        Base b = new Base("localhost", "root", "", "formulario");

        public string validar(TextBox nic, TextBox clave)
        {
            try
            {
                DataSet ds = b.Consultar($"call validar('{nic.Text}',Sha1('{clave.Text}'))", "usuarios");
                DataTable dt = ds.Tables[0];

                if (dt.Rows[0]["rs"].ToString().Equals("C0rr3ct0"))
                    return dt.Rows[0]["tipo"].ToString();
                else
                    return "Error";
            }
            catch (Exception)
            {


                MessageBox.Show($"El usuario y contraseña son incorrectos", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Error";
            }
        }
        public static string Sha1(string texto)
        {
            SHA1 sha1 = SHA1CryptoServiceProvider.Create();
            Byte[] textOriginal = ASCIIEncoding.Default.GetBytes(texto);
            Byte[] hash = sha1.ComputeHash(textOriginal);
            StringBuilder cadena = new StringBuilder();
            foreach (byte i in hash)
            {
                cadena.AppendFormat("{0:x2}", i);
            }
            return cadena.ToString();
        }

        public string Guardar(TextBox Nombre, TextBox Apellido, TextBox Contraseña, TextBox Tipo)
        {
            try
            {
                //return b.Comando($"Insert into usuarios values(NULL,'{Nombre.Text}','{Apellido.Text}','{Telefono.Text}','{Email.Text}', SHA1('{Contraseña.Text}'),'{Tipo.Text}')");
                return b.Comando($"INSERT INTO usuarios VALUES(NULL, '{Nombre.Text}', '{Apellido.Text}', SHA1('{Contraseña.Text}'), '{Tipo.Text}')");
            }
            catch (Exception)
            {
                return "Error Valor";
            }
        }

        public void Mostrar(DataGridView Tabla, string filtro)
        {
            Tabla.Columns.Clear();
            Tabla.DataSource = b.Consultar($"select * from usuarios where nic like '%{filtro}%'", "usuarios").Tables[0];
            Tabla.Columns.Insert(5, Boton("Eliminar", Color.Red));
            Tabla.Columns.Insert(6, Boton("Modificar", Color.Blue));
            Tabla.AutoResizeColumns();
            Tabla.AutoResizeRows();
        }

        DataGridViewButtonColumn Boton(string t, Color f)
        {
            DataGridViewButtonColumn x = new DataGridViewButtonColumn();
            x.Text = t;
            x.UseColumnTextForButtonValue = true;
            x.FlatStyle = FlatStyle.Popup;
            x.DefaultCellStyle.ForeColor = Color.White;
            x.DefaultCellStyle.BackColor = f;
            return x;
        }

        public void Borrar(int id, string Dato)
        {
            DialogResult rs = MessageBox.Show($"Estas seguro de eliminar a {Dato}", "!Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                b.Comando($"delete from usuarios where idUsuario={id}");
                MessageBox.Show("Registro Eliminado", "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Modificar(int id, TextBox Nombre, TextBox Apellido, TextBox Contraseña, TextBox Tipo)
        {
            b.Comando($"update usuarios set nombre='{Nombre.Text}', apellido='{Apellido.Text}', contraseña='{Contraseña.Text}', tipo='{Tipo.Text}', where idUsuario={id}");
            MessageBox.Show("Registro Modificado", "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
