using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appVentas.VISTA
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void rOLESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRoles ro1 = new frmRoles();
            ro1.MdiParent = this;
            ro1.Show();
        }

        private void uSUARIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario User = new frmUsuario();
            User.MdiParent = this;
            User.Show();       
        }

        private void uSUARIOSToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmUsuario User = new frmUsuario();
            User.MdiParent = this;
            User.Show();
        }

        public static frmVentas venta = new frmVentas();

        private void vENDERToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            venta.MdiParent = this;
            venta.Show();            
        }
    }
}
