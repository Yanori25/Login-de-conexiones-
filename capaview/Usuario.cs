using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LoginMVC_ActV.capacontroller;
using LoginMVC_ActV.capamodelo;

namespace LoginMVC_ActV.capaview
{
    public partial class Usuario : Form
    {


        UsuariosController usuario = new UsuariosController();
        Usuariomodel model = new Usuariomodel();
        int codigoempleado = 0;

        public Usuario()
        {
            InitializeComponent();
        }

        private void refrescar()
        {
            dgvusuarios.DataSource = usuario.ListarUusario();

        }


        private void btnagregar_Click(object sender, EventArgs e)
        {
            model.NombreUsuario = txtnombre.Text;
            model.ApelldoUsuario = txtapellido.Text;
            model.RolUsuario = txtrol.Text;
            model.clave = txtclave.Text;
            model.intentoLogueos = 3;

            usuario.CrearUsuario(model);
            this.refrescar();
        }

        private void Usuario_Click(object sender, EventArgs e)
        {
           
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (codigoempleado > 0)
            {
                model.NombreUsuario = txtnombre.Text;
                model.ApelldoUsuario = txtapellido.Text;
                model.RolUsuario = txtrol.Text;
                model.clave = txtclave.Text;
                model.codigoempleado = codigoempleado;

                usuario.editarUsuario(model);
                this.refrescar();

            }

          
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            this.refrescar();
        }

        private void dgvusuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.codigoempleado =  Convert.ToInt32( dgvusuarios.Rows[e.RowIndex].Cells[2].Value.ToString());
            txtnombre.Text = dgvusuarios.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtapellido.Text =dgvusuarios.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtrol.Text = dgvusuarios.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtclave.Text = dgvusuarios.Rows[e.RowIndex].Cells[6].Value.ToString();





        }

        private void txtbuscarnombre_TextChanged(object sender, EventArgs e)
        {
            string filtername = "NombreUsuario";
            ((DataTable)dgvusuarios.DataSource).DefaultView.RowFilter = string.Format("[{0}] like '%{1}%'", filtername,
                txtbuscarnombre.Text);

        }

        private void txtbuscarapellido_TextChanged(object sender, EventArgs e)
        {
            string filtername = "ApelldoUsuario";
            ((DataTable)dgvusuarios.DataSource).DefaultView.RowFilter = string.Format("[{0}] like '%{1}%'", filtername,
                txtbuscarapellido.Text);
        }

        private void txtbuscarrol_TextChanged(object sender, EventArgs e)
        {
            string filtername = "RolUsuario";
            ((DataTable)dgvusuarios.DataSource).DefaultView.RowFilter = string.Format("[{0}] like '%{1}%'", filtername,
                txtbuscarrol.Text);
        }

        private void txtbuscarcodigo_TextChanged(object sender, EventArgs e)
        {
            string filtername = "codigoempleado";
            ((DataTable)dgvusuarios.DataSource).DefaultView.RowFilter = string.Format("[{0}] like '%{1}%'", filtername,
                  txtbuscarcodigo.Text);
        }
    }
}
