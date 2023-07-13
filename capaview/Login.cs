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
    public partial class Login : Form
    {

        UsuariosController usuario = new UsuariosController();
        Usuariomodel model = new Usuariomodel();
        string rolusuario = "";
        

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btniniciar_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btniniciar_Click(object sender, EventArgs e)
        {
            model.NombreUsuario = txtnombre.Text;
            model.clave = txtclave.Text; 


         bool ingreso =   usuario.loguear(model);

            if (ingreso == true)
            {
                rolusuario = usuario.getrol(model);

                Menu frmmenu = new Menu(rolusuario);
                Login frmlogin = new Login();
                frmlogin.Close();
                frmmenu.Show();
             
            }
            else
            {
                MessageBox.Show( "Ingrese el usuario o clave valido");

            }



        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
