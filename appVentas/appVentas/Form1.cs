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

namespace appVentas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ENTRAR_Click(object sender, EventArgs e)
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                var lista = from usuario in db.tb_usuarios
                            where usuario.email == txtUsuario.Text
                            && usuario.contrasena == txtContrasena.Text
                            select usuario;
                if (lista.Count()>0)
                {
                    Usuario User = new Usuario();
                    User.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("El usuario no existe");
                }

            }
        }
    }
}
