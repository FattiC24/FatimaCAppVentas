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
using appVentas.VISTA.FormularioDeBusqueda;
namespace appVentas.VISTA
{
    public partial class frmVentas : Form
    {
        public frmVentas()
        {
            InitializeComponent();
        }
        private void dtgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
     
        }
        private void frmVentas_Load(object sender, EventArgs e)
        {
            retornoid();
            CargarComobo();
        }
        void retornoid()
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                var tb_V = db.tb_Venta;

                foreach (var iterardatostbVentas in tb_V)
                {
                    txtIdNumeracion.Text = iterardatostbVentas.idVenta.ToString();
                    //dtvVentas.Rows.Add(iterardatostbUsuario.Id, iterardatostbUsuario.email, iterardatostbUsuario.contrasena);
                }

            }
        }
        void CargarComobo()
        {
            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                var clientes = bd.tb_cliente.ToList();

                cmbCliente.DataSource = clientes;
                cmbCliente.DisplayMember = "nombreCliente";
                cmbCliente.ValueMember = "iDCliente";

                var tipoDoc = bd.tb_documento.ToList();

                cmbTipoDoc.DataSource = tipoDoc;
                cmbTipoDoc.DisplayMember = "nombreDocumento";
                cmbTipoDoc.ValueMember = "iDDocumento";

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBusqueda busqueda = new frmBusqueda();
            busqueda.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                calculo();
                
            }
            catch (Exception ex)
            {

            }

            dtgProductos.Rows.Add(txtIdProd.Text, txtNomProd.Text, txtPrecioProd.Text,txtCantidad.Text, txtTotal.Text);
            calcularTotal();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            calculo();
           
        } 
        void calculo()
        {
            try
            {
                Double precioProd;
                Double cantidad;
                Double total;

                precioProd = Double.Parse(txtPrecioProd.Text);
                cantidad = Convert.ToDouble(txtCantidad.Text);

                total = precioProd * cantidad;

                txtTotal.Text = total.ToString();
            }
            catch (Exception )
            {
                txtCantidad.Text = "0";
                MessageBox.Show("No puede operar datos menores a 0");
                txtCantidad.Select();
                //MessageBox.Show(ex.ToString());
            }
        }
        void calcularTotal()
        {
            double total = 0;
            foreach (DataGridViewRow row in dtgProductos.Rows)
            {
                total += Convert.ToDouble(row.Cells["total"].Value);
            }

            txtCalcularTotal.Text = Convert.ToString(total);
            
        }

        
    }
}
