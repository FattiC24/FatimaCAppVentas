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
                txtIdNumeracion.Text = "1";
                foreach (var iterardatostbVentas in tb_V)
                {
                    int idVenta = iterardatostbVentas.idVenta;
                    int suma = idVenta + 1;
                    txtIdNumeracion.Text = suma.ToString();
                    
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
            double suma = 0;
            for (int i=0; i < dtgProductos.RowCount;i++)
            {
                String datosAOperar = dtgProductos.Rows[i].Cells[4].Value.ToString();
                Double datosConvertidos = Convert.ToDouble(datosAOperar);

                //suma = suma + datosConvertidos;
                suma += datosConvertidos;
                txtTotalFinal.Text = suma.ToString();


            }


            //calcularTotal();
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
                txtCantidad.Text = "1";
                
                txtCantidad.Select();
                //MessageBox.Show(ex.ToString());
            }
        }
        //void calcularTotal()
        //{
        //    double total = 0;
        //    foreach (DataGridViewRow row in dtgProductos.Rows)
        //    {
        //        total += Convert.ToDouble(row.Cells["total"].Value);
        //    }

        //    txtTotalFinal.Text = Convert.ToString(total);
            
        //}

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                tb_Venta tb_v = new tb_Venta();
                String comboTipoDoc = cmbTipoDoc.SelectedValue.ToString();
                String comboCliente = cmbCliente.SelectedValue.ToString();
                tb_v.idDocumento = Convert.ToInt32(comboTipoDoc);
                tb_v.idCliente = Convert.ToInt32(comboCliente);
                tb_v.idUsuario = 1;
                tb_v.totalVenta = Convert.ToDecimal(txtTotalFinal.Text);
                tb_v.fecha = Convert.ToDateTime(dtpFecha.Text);
                
                bd.tb_Venta.Add(tb_v);
                bd.SaveChanges();

                detalleVenta dete = new detalleVenta();
                for (int i = 0; i < dtgProductos.RowCount; i++)
                {
                    String idProducto = dtgProductos.Rows[i].Cells[0].Value.ToString();
                    int idProductoConvertido = Convert.ToInt32(idProducto);

                    String cantidad = dtgProductos.Rows[i].Cells[3].Value.ToString();
                    int cantidadConvertidos = Convert.ToInt32(cantidad);

                    String precio = dtgProductos.Rows[i].Cells[2].Value.ToString();
                    Decimal precioConvertidos = Convert.ToDecimal(precio);

                    String total = dtgProductos.Rows[i].Cells[4].Value.ToString();
                    Decimal totalConvertidos = Convert.ToDecimal(total);

                    dete.idVenta = Convert.ToInt32(txtIdNumeracion.Text);
                    dete.idProducto = idProductoConvertido;
                    dete.cantidad = cantidadConvertidos;
                    dete.precio = precioConvertidos;
                    dete.total = totalConvertidos;
                    bd.detalleVenta.Add(dete);
                    bd.SaveChanges();


                }
            }
            retornoid();
        }

        private void txtBuscarProd_KeyUp(object sender, KeyEventArgs e)
        {
            if(txtBuscarProd.Text == ""){
                if (e.KeyCode == Keys.Enter)
                {
                    btnBuscar.PerformClick();
                }
            }else if (e.KeyCode == Keys.Enter)
            {
                using (sistema_ventasEntities bd = new sistema_ventasEntities())
                {
                    producto pr = new producto();
                    int buscar = int.Parse(txtBuscarProd.Text);
                    pr = bd.producto.Where(idBuscar => idBuscar.idProducto == buscar).First();
                    txtIdProd.Text = Convert.ToString(pr.idProducto);
                    txtNomProd.Text = Convert.ToString(pr.nombreProducto);
                    txtPrecioProd.Text = Convert.ToString(pr.precioProducto);
                    txtCantidad.Focus();
                    txtBuscarProd.Text = "";
                }
            }
        }
        int intentos = 1;
        private void txtCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (intentos == 2)
                {
                    btnAgregar.PerformClick();
                    txtIdProd.Text = "";
                    txtNomProd.Text = "";
                    txtPrecioProd.Text = "";
                    txtTotal.Text = "";
                    intentos = 0;
                    txtCantidad.Text = "1";
                    txtBuscarProd.Focus();
                }
                intentos += 1;
            }
        }
    }
}
