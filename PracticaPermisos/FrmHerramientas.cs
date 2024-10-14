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
    public partial class FrmHerramientas : Form
    {
        ManeajorHerramientas mh;
        public FrmHerramientas()
        {
            InitializeComponent();
            mh = new ManeajorHerramientas();
            if (!FrmBuscarHerramientas.Codigo.Equals(""))
            {
                txtCodigo.Text = FrmBuscarHerramientas.Codigo;
                txtNombre.Text = FrmBuscarHerramientas.Nombre;
                txtMedida.Text = FrmBuscarHerramientas.Medida.ToString();
                txtDescripcion.Text = FrmBuscarHerramientas.Descripcion;
                txtMarca.Text = FrmBuscarHerramientas.Marca.ToString();

                btnAceptar.Text = "Editar";
            }
        }

        private void FrmHerramientas_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!FrmBuscarHerramientas.Codigo.Equals(""))
            {
                mh.Modificar(txtCodigo, txtNombre, txtMedida, txtDescripcion, txtMarca);
            }
            else
            {
                MessageBox.Show(mh.Guardar(txtCodigo, txtNombre, txtMedida,  txtDescripcion, txtMarca), "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Close();
        }
    }
}
