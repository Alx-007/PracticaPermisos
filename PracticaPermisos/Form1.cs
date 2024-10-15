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
    public partial class Form1 : Form
    {
        ManejadorRefacciones mr;
        ManejadorUsuario mu;
        public Form1()
        {
            InitializeComponent();
            mu = new ManejadorUsuario();
            mr = new ManejadorRefacciones();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtClave.Text.Equals("") || txtUsuario.Text.Equals(""))
            {
                MessageBox.Show("No ha ingresado ningun usuario.");
            }

            string r = mu.validar(txtUsuario, txtClave);
            if (!r.Equals("Error"))
            {

                switch (r.ToUpper())
                {
                    case "ADMINISTRADOR":
                        {

                            MenuPrincipal m = new MenuPrincipal();
                            m.ShowDialog();
                            txtClave.Clear(); txtUsuario.Clear();
                        }
                        break;
                    case "EMPLEADO":
                        {
                            MenuPrincipal m = new MenuPrincipal();
                            m.ShowDialog();
                            txtClave.Clear(); txtUsuario.Clear();
                        }
                        break;
                }
            }
            else
            {
                lblErrores.Text = "El usuario y constraseña son incorrectos";
            }
            this.Show();
        }
    }
}
