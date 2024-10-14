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
            if (FrmBuscarUsuario.id > 0)
            {
                txtNombre.Text = FrmBuscarUsuario.Nombre;
                txtApellidoP.Text = FrmBuscarUsuario.ApellidoP;
                txtApellidoM.Text = FrmBuscarUsuario.ApellidoM;
                txtFechaN.Text = FrmBuscarUsuario.FechaNacimiento;
                txtRFC.Text = FrmBuscarUsuario.RFC;
                txtUsuario.Text = FrmBuscarUsuario.nic;
                txtTipo.Text = FrmBuscarUsuario.Tipo;
                txtClave.Text = FrmBuscarUsuario.clave;

                btnAceptar.Text = "Editar";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (FrmBuscarUsuario.id > 0)
            {
                mu.Modificar(FrmBuscarUsuario.id, txtNombre, txtApellidoP, txtApellidoM, txtFechaN, txtRFC, txtUsuario, txtTipo, txtClave);
            }
            else
            {
                MessageBox.Show(mu.Guardar(txtNombre, txtApellidoP, txtApellidoM, txtFechaN, txtRFC, txtUsuario, txtTipo, txtClave), "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Close();
        }
    }
}
