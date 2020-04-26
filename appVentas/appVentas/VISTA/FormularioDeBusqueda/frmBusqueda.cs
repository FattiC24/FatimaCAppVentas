using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appVentas.Model;
using appVentas.VISTA;
using appVentas.VISTA.FormularioDeBusqueda;

namespace appVentas.VISTA.FormularioDeBusqueda
{
    public partial class frmBusqueda : Form
    {
        public frmBusqueda()
        {
            InitializeComponent();
        }

        private void frmBusqueda_Load(object sender, EventArgs e)
        {
            filtro();
        }
        void filtro()
        {
            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                String nombre = txtBuscar.Text;

                var buscarpro = from tbprod in bd.producto

                                where tbprod.nombreProducto.Contains(nombre)

                                select new
                                {
                                    Id = tbprod.idProducto,
                                    Nombre = tbprod.nombreProducto,
                                    Precio = tbprod.precioProducto
                                };
                dtgProducto.DataSource = buscarpro.ToList();

            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }

        private void dtgProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            envio();
        }
        void envio()
        {
            String id; id = dtgProducto.CurrentRow.Cells[0].Value.ToString();
            String nombre = dtgProducto.CurrentRow.Cells[1].Value.ToString();
            String precio = dtgProducto.CurrentRow.Cells[2].Value.ToString();

            frmMenu.venta.txtIdProd.Text = id;
            frmMenu.venta.txtNomProd.Text = nombre;
            frmMenu.venta.txtPrecioProd.Text = precio;

            frmMenu.venta.txtCantidad.Focus();
            this.Close();
        }

        private void dtgProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                envio();
            }
        }
    }
}
