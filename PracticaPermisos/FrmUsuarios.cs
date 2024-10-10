using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejadores;
using Entidades;

namespace PracticaPermisos
{
    public partial class FrmUsuarios : Form
    {
        ManejadorUsuario mu;
        public FrmUsuarios()
        {
            InitializeComponent();
            mu = new ManejadorUsuario();
        }

        public static List<Usuarios> usuarios = new List<Usuarios>();
        int fila = 0, columna = 0;
        public static int id = 0;
        public static string Nombre = "", ApellidoP = "", ApellidoM = "", FechaNac = "", RFC = "", Usuario = "", Tipo = "", Clave = "";

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (FrmUsuarios.id > 0)
            {
                mu.Modificar(FrmUsuarios.id, txtNombre, txtApellidoP, txtApellidoM, txtFechaN, txtRFC, txtUsuario, txtTipo, txtClave);
            }
            else
            {
                MessageBox.Show(mu.Guardar(txtNombre, txtApellidoP, txtApellidoM, txtFechaN, txtRFC, txtUsuario, txtTipo, txtClave), "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }
    }
}
