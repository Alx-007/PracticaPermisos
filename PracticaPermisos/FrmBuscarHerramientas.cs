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
using Manejadores;
using Entidades;

namespace PracticaPermisos
{
    public partial class FrmBuscarHerramientas : Form
    {
        ManeajorHerramientas mh;
        public FrmBuscarHerramientas()
        {
            InitializeComponent();
            mh = new ManeajorHerramientas();
        }

        public static List<Herramientas> herramientas = new List<Herramientas>();
        int fila = 0, columna = 0;
        public static int id = 0;
        public static string Codigo = "", Nombre = "", Descripcion = "";
        public static int Marca = 0;
        public static double Medida = 0.0;

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mh.Mostrar(dtgvHerramientas, txtBuscar.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Codigo = dtgvHerramientas.Rows[fila].Cells[0].Value.ToString();
            mh.Borrar(Codigo, dtgvHerramientas.Rows[fila].Cells[1].Value.ToString());
            Limpiar();
            Actualizar();
            txtBuscar.Focus();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Codigo = dtgvHerramientas.Rows[fila].Cells[0].Value.ToString();
            Nombre = dtgvHerramientas.Rows[fila].Cells[1].Value.ToString();
            Medida = double.Parse(dtgvHerramientas.Rows[fila].Cells[2].Value.ToString());
            Descripcion = dtgvHerramientas.Rows[fila].Cells[3].Value.ToString();
            Marca = int.Parse(dtgvHerramientas.Rows[fila].Cells[4].Value.ToString());
            FrmHerramientas dm = new FrmHerramientas();
            dm.ShowDialog();
            Actualizar();
            txtBuscar.Focus();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Codigo = ""; Nombre = ""; Descripcion = "";
            Marca = 0;
            Medida = 0.0;
            FrmHerramientas dm = new FrmHerramientas();
            dm.ShowDialog();
            Actualizar();
            txtBuscar.Focus();
        }

        void Limpiar()
        {
            mh.Mostrar(dtgvHerramientas, "-1");
        }

        void Actualizar()
        {
            mh.Mostrar(dtgvHerramientas, herramientas.ToString());
        }
    }
}
