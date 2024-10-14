using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Manejadores;


namespace PracticaPermisos
{
    public partial class FrmBuscarMarca : Form
    {
        ManejadorMarca mm;
        public FrmBuscarMarca()
        {
            InitializeComponent();
            mm = new ManejadorMarca();
        }

        public static List<Marca> marca = new List<Marca>();
        int fila = 0, columna = 0;
        public static int id = 0;
        public static string Nombre = "", Descripcion = "";

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Nombre = ""; Descripcion = "";
            FrmMarca dm = new FrmMarca();
            dm.ShowDialog();
            Actualizar();
            txtBuscar.Focus();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            id = int.Parse(dtgvMarca.Rows[fila].Cells[0].Value.ToString());
            Nombre = dtgvMarca.Rows[fila].Cells[1].Value.ToString();
            Descripcion = dtgvMarca.Rows[fila].Cells[2].Value.ToString();
            FrmMarca dm = new FrmMarca();
            dm.ShowDialog();
            Actualizar();
            txtBuscar.Focus();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mm.Mostrar(dtgvMarca, txtBuscar.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            id = int.Parse(dtgvMarca.Rows[fila].Cells[0].Value.ToString());
            mm.Borrar(id, dtgvMarca.Rows[fila].Cells[1].Value.ToString());
            Limpiar();
            Actualizar();
            txtBuscar.Focus();
        }

        void Limpiar()
        {
            mm.Mostrar(dtgvMarca, "-1");
        }

        void Actualizar()
        {
            mm.Mostrar(dtgvMarca, marca.ToString());
        }
    }
}
