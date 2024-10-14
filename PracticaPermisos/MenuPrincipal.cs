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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FrmBuscarUsuario u = new FrmBuscarUsuario();
            u.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmBuscarRefacciones r = new FrmBuscarRefacciones();
            r.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FrmBuscarHerramientas h = new FrmBuscarHerramientas();
            h.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            FrmBuscarMarca m = new FrmBuscarMarca();
            m.ShowDialog();
        }
    }
}
