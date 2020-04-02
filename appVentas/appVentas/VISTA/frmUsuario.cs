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

namespace appVentas.VISTA
{
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
            //cargardatos();
        }
        tb_usuarios user = new tb_usuarios();

        void cargardatos()
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                var tb_Usuarios = db.tb_usuarios;

                foreach(var iterardatostbUsuario in tb_Usuarios)
                {
                    dtvUsuarios.Rows.Add(iterardatostbUsuario.Id, iterardatostbUsuario.email, iterardatostbUsuario.contrasena);
                }
                //dtvUsuarios.DataSource = db.tb_usuarios.ToList();
            }
                
        }
        void limpiardatos()
        {
            txtUsuario.Text = "";
            txtContraseña.Text = "";
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            dtvUsuarios.Rows.Clear();
            cargardatos();
        }
       

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                user.email = txtUsuario.Text;
                user.contrasena = txtContraseña.Text;

                db.tb_usuarios.Add(user);
                db.SaveChanges();
            }
            dtvUsuarios.Rows.Clear();
            cargardatos();
            limpiardatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            
                {
                String id = dtvUsuarios.CurrentRow.Cells[0].Value.ToString();

                user = db.tb_usuarios.Find(int.Parse(id));
                db.tb_usuarios.Remove(user);
                db.SaveChanges();
            }
            dtvUsuarios.Rows.Clear();
            cargardatos();
                limpiardatos();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                String Id = dtvUsuarios.CurrentRow.Cells[0].Value.ToString();
                int idC = int.Parse(Id);
                user = db.tb_usuarios.Where(VerificarID => VerificarID.Id == idC).First();
                user.email = txtUsuario.Text;
                user.contrasena = txtContraseña.Text;
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            dtvUsuarios.Rows.Clear();
            cargardatos();
            limpiardatos();
        }
        private void Usuario_Load(object sender, EventArgs e)
        {
            cargardatos();
        }
        private void dtvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String email = dtvUsuarios.CurrentRow.Cells[1].Value.ToString();
            String pass = dtvUsuarios.CurrentRow.Cells[2].Value.ToString();
            txtUsuario.Text = email;
            txtContraseña.Text = pass;
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            dtvUsuarios.Rows.Clear();
            cargardatos();
        }
    }
}
