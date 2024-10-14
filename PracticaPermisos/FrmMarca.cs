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
    public partial class FrmMarca : Form
    {
        ManejadorMarca mm;
        public FrmMarca()
        {
            InitializeComponent();
            mm = new ManejadorMarca();
            if (FrmBuscarMarca.id > 0)
            {
                txtNombre.Text = FrmBuscarMarca.Nombre;
                txtDescripcion.Text = FrmBuscarMarca.Descripcion;

                btnAceptar.Text = "Editar";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (FrmBuscarMarca.id > 0)
            {
                mm.Modificar(FrmBuscarMarca.id, txtNombre, txtDescripcion);
            }
            else
            {
                MessageBox.Show(mm.Guardar(txtNombre, txtDescripcion), "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Close();
        }
    }
}
