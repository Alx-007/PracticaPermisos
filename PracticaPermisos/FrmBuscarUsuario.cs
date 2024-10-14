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
    public partial class FrmBuscarUsuario : Form
    {
        ManejadorUsuario mu; 
        public FrmBuscarUsuario()
        {
            InitializeComponent();
            mu = new ManejadorUsuario();
        }

        public static List<Usuarios> usuarios = new List<Usuarios>();
        int fila = 0, columna = 0;
        public static int id = 0;
        public static string Nombre = "", ApellidoP = "", ApellidoM = "", FechaNacimiento = "", RFC = "", nic = "", Tipo = "", clave = "";

        private void dtgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            id = int.Parse(dtgvUsuarios.Rows[fila].Cells[0].Value.ToString());
            mu.Borrar(id, dtgvUsuarios.Rows[fila].Cells[1].Value.ToString());
            Limpiar();
            Actualizar();
            txtBuscar.Focus();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            id = int.Parse(dtgvUsuarios.Rows[fila].Cells[0].Value.ToString());
            Nombre = dtgvUsuarios.Rows[fila].Cells[1].Value.ToString();
            ApellidoP = dtgvUsuarios.Rows[fila].Cells[2].Value.ToString();
            ApellidoM = dtgvUsuarios.Rows[fila].Cells[3].Value.ToString();
            FechaNacimiento = dtgvUsuarios.Rows[fila].Cells[4].Value.ToString();
            RFC = dtgvUsuarios.Rows[fila].Cells[5].Value.ToString();
            nic = dtgvUsuarios.Rows[fila].Cells[6].Value.ToString();
            Tipo = dtgvUsuarios.Rows[fila].Cells[7].Value.ToString();
            clave = dtgvUsuarios.Rows[fila].Cells[8].Value.ToString();
            FrmUsuarios dm = new FrmUsuarios();
            dm.ShowDialog();
            Actualizar();
            txtBuscar.Focus();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            id = 0; Nombre = ""; ApellidoP = ""; ApellidoM = ""; FechaNacimiento = ""; RFC = ""; nic = ""; Tipo = ""; clave = "";
            FrmBuscarUsuario dm = new FrmBuscarUsuario();
            dm.ShowDialog();
            txtBuscar.Focus();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            id = 0; Nombre = ""; ApellidoP = ""; ApellidoM = ""; FechaNacimiento = ""; RFC = ""; nic = ""; Tipo = ""; clave = "";
            FrmUsuarios dm = new FrmUsuarios();
            dm.ShowDialog();
            Actualizar();
            txtBuscar.Focus();
        }

        private void dtgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mu.Mostrar(dtgvUsuarios, txtBuscar.Text);
        }

        void Limpiar()
        {
            mu.Mostrar(dtgvUsuarios, "-1");
        }

        void Actualizar()
        {
            mu.Mostrar(dtgvUsuarios, usuarios.ToString());
        }
    }
}
