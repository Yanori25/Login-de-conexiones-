using LoginMVC_ActV.capamodelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LoginMVC_ActV.capacontroller
{
    class UsuariosController
    {
        public UsuariosController() { }

        public bool CrearUsuario(Usuariomodel Modelo)
        {
            try
            {
                using (SqlConnection Con = new Conexion().GetConexion("BDConexion"))
                {
                    Con.Open();

                    string sql = "execute agregarusuario '" + Modelo.NombreUsuario + "' , '" + Modelo.ApelldoUsuario +
                        "' ,  '" + Modelo.RolUsuario + "' , '" + Modelo.clave + "' , " + Modelo.intentoLogueos + " ";

                 
                    using (SqlCommand cmd = new SqlCommand(sql, Con))
                    {
                        cmd.CommandTimeout = 600;
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Se agrego exitosamente");

                    Con.Close();
                }

                return true;
            }
            catch (Exception errores)
            {
                MessageBox.Show(errores.Message, "Informacion del sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
        }


        public bool editarUsuario(Usuariomodel Modelo)
        {
            try
            {
                using (SqlConnection Con = new Conexion().GetConexion("BDConexion"))
                {
                    Con.Open();

                    string sql = "execute editusuario '" + Modelo.NombreUsuario + "' , '" + Modelo.ApelldoUsuario +
                        "' ,  '" + Modelo.RolUsuario + "' , '" + Modelo.clave + "' , " + Modelo.codigoempleado + " ";


                    using (SqlCommand cmd = new SqlCommand(sql, Con))
                    {
                        cmd.CommandTimeout = 600;
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Se edito exitosamente");

                    Con.Close();
                }

                return true;
            }
            catch (Exception errores)
            {
                MessageBox.Show(errores.Message, "Informacion del sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
        }

        public DataTable ListarUusario()
        {
            SqlConnection Con = new Conexion().GetConexion("BDConexion");
            Con.Open();



            /*
            DataTable dataTable = new DataTable();
            string query = " select CodigoEmpleado,  NombreEmpleado , ApellidoEmpleado ,FechaIngreso  ,Antiguedad  , Salario   from empleado ";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.CommandTimeout = 99999;
            new SqlDataAdapter(cmd).Fill(dataTable);
            */


            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("showusuario", Con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(dataTable);


            Con.Close();
            return dataTable;


        }

        public bool loguear(Usuariomodel Modelo)
        {
            bool valor ;

            try
            {
                using (SqlConnection Con = new Conexion().GetConexion("BDConexion"))
                {
                    Con.Open();

                    string sql = "execute loginusuario '" + Modelo.NombreUsuario + "' , '" +  Modelo.clave + "'  " ;


                    using (SqlCommand cmd = new SqlCommand(sql, Con))
                    {
                        cmd.CommandTimeout = 600;
                        SqlParameter returno = new SqlParameter();
                        //returno.Direction = ParameterDirection.ReturnValue;

                      //  cmd.Parameters.Add(returno);
                         // cmd.ExecuteNonQuery();
                        // valor = Convert.ToBoolean( returno.Value);
                         valor = (Boolean)cmd.ExecuteScalar();
                    }
                   

                    Con.Close();
                }

                return valor;
            }
            catch (Exception errores)
            {
                MessageBox.Show(errores.Message, "Informacion del sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
        }


        public string getrol(Usuariomodel Modelo)
        {
            string valor;

            try
            {
                using (SqlConnection Con = new Conexion().GetConexion("BDConexion"))
                {
                    Con.Open();

                    string sql = "execute rolusuario '" + Modelo.NombreUsuario + "' , '" + Modelo.clave + "'  ";


                    using (SqlCommand cmd = new SqlCommand(sql, Con))
                    {
                        cmd.CommandTimeout = 600;
                        SqlParameter returno = new SqlParameter();
                        //returno.Direction = ParameterDirection.ReturnValue;

                        //  cmd.Parameters.Add(returno);
                        // cmd.ExecuteNonQuery();
                        // valor = Convert.ToBoolean( returno.Value);
                        valor = (string)cmd.ExecuteScalar();
                    }


                    Con.Close();
                }

                return valor;
            }
            catch (Exception errores)
            {
                MessageBox.Show(errores.Message, "Informacion del sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return "";
            }
        }

    }
}
