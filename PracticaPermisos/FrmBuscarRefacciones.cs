using Entidades;
using Manejadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaPermisos
{
    public partial class FrmBuscarRefacciones : Form
    {
        ManejadorRefacciones mr;
        public FrmBuscarRefacciones()
        {
            InitializeComponent();
            mr = new ManejadorRefacciones();
        }

        public static List<Refacciones> refacciones = new List<Refacciones>();
        int fila = 0, columna = 0;
        public static int id = 0;
        public static string Codigo = "", Nombre = "", Descripcion = "";
        public static int Marca = 0;

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            id = int.Parse(dtgvRefacciones.Rows[fila].Cells[0].Value.ToString());
            mr.Borrar(id, dtgvRefacciones.Rows[fila].Cells[1].Value.ToString());
            Limpiar();
            Actualizar();
            txtBuscar.Focus();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mr.Mostrar(dtgvRefacciones, txtBuscar.Text);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            id = int.Parse(dtgvRefacciones.Rows[fila].Cells[0].Value.ToString());
            Codigo = dtgvRefacciones.Rows[fila].Cells[1].Value.ToString();
            Nombre = dtgvRefacciones.Rows[fila].Cells[2].Value.ToString();
            Descripcion = dtgvRefacciones.Rows[fila].Cells[3].Value.ToString();
            Marca = int.Parse(dtgvRefacciones.Rows[fila].Cells[4].Value.ToString());
            FrmRefacciones dm = new FrmRefacciones();
            dm.ShowDialog();
            Actualizar();
            txtBuscar.Focus();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            id = 0;  Codigo = ""; Nombre = ""; Descripcion = "";
            Marca = 0;
            FrmRefacciones dm = new FrmRefacciones();
            dm.ShowDialog();
            Actualizar();
            txtBuscar.Focus();
        }

        void Limpiar()
        {
            mr.Mostrar(dtgvRefacciones, "-1");
        }

        void Actualizar()
        {
            mr.Mostrar(dtgvRefacciones, refacciones.ToString());
        }
    }
}
