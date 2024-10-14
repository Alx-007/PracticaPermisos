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

        public string Guardar(TextBox Nombre, TextBox ApellidoP, TextBox ApellidoM, TextBox FechaNacimiento, TextBox rfc, TextBox nic, TextBox Tipo, TextBox Clave)
        {
            try
            {
                return b.Comando($"INSERT INTO usuarios VALUES(NULL, '{Nombre.Text}', '{ApellidoP.Text}', '{ApellidoM.Text}', '{FechaNacimiento.Text}', '{rfc.Text}', '{nic.Text}', '{Tipo.Text}', SHA1('{Clave.Text}'))");
            }
            catch (Exception)
            {
                return "Error Valor";
            }
        }

        public void Mostrar(DataGridView Tabla, string filtro)
        {
            Tabla.Columns.Clear();
            Tabla.DataSource = b.Consultar($"select * from usuarios where nombre like '%{filtro}%'", "usuarios").Tables[0];
            Tabla.Columns.Insert(9, Boton("Eliminar", Color.Red));
            Tabla.Columns.Insert(10, Boton("Modificar", Color.Blue));
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

        public void Modificar(int id, TextBox Nombre, TextBox ApellidoP, TextBox ApellidoM, TextBox FechaNacimiento, TextBox rfc, TextBox nic, TextBox Tipo, TextBox Clave)
        {
            string fr = $"{FechaNacimiento.Text.Substring(6, 4)}-{FechaNacimiento.Text.Substring(3, 2)}-{FechaNacimiento.Text.Substring(0, 2)}";
            b.Comando($"update usuarios set nombre = '{Nombre.Text}', apellidoP = '{ApellidoP.Text}', apellidoM = '{ApellidoM.Text}', fechaNacimiento = '{fr}', rfc = '{rfc}', nic = '{nic}', tipo = '{Tipo}', clave = sha1('{Clave}') WHERE idUsuario = {id};");
            MessageBox.Show("Registro Modificado", "!Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
