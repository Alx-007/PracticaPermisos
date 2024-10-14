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
    public partial class FrmRefacciones : Form
    {
        ManejadorRefacciones mr;
        public FrmRefacciones()
        {
            InitializeComponent();
            mr = new ManejadorRefacciones();
            if (FrmBuscarRefacciones.id > 0)
            {
                txtCodigo.Text = FrmBuscarRefacciones.Codigo;
                txtNombre.Text = FrmBuscarRefacciones.Nombre;
                txtDescripcion.Text = FrmBuscarRefacciones.Descripcion;
                txtMarca.Text = FrmBuscarRefacciones.Marca.ToString();
                btnAceptar.Text = "Modificar";
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (FrmBuscarRefacciones.id > 0)
            {
                mr.Modificar(FrmBuscarRefacciones.id, txtCodigo, txtNombre, txtDescripcion, txtMarca);
            }
            else
            {
                MessageBox.Show(mr.Guardar(txtCodigo, txtNombre, txtDescripcion, txtMarca), "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Close();
        }
    }
}
