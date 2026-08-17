using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace AppTaller.CapaVistas
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }


        protected void LlenarGrid()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("SELECT * From Usuarios", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                }
            }
        }


        protected void consultarconfiltro()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("SELECT * from Usuarios where UsuarioID = @UsuarioID", con))
            {
                cmd.Parameters.AddWithValue("@UsuarioID", txtUsuarioID.Text);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                }
            }
        }

        protected void IngresarClientes()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("insert into Usuarios (Nombre, CorreoElectronico, Telefono) values (@nombre, @correo, @telefono)", con))
            {
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
                cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            LlenarGrid();
        }

        protected void BorrarClientes()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("delete from Usuarios where UsuarioID = @UsuarioID", con))
            {
                cmd.Parameters.AddWithValue("@UsuarioID", txtUsuarioID.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            LlenarGrid();
        }

        protected void ActualizarClientes()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("update Usuarios set Nombre = @Nombre, CorreoElectronico = @Correo, Telefono = @Telefono where UsuarioID = @UsuarioID", con))
            {
                cmd.Parameters.AddWithValue("@UsuarioID", txtUsuarioID.Text);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            LlenarGrid();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            IngresarClientes();
            LlenarGrid();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            BorrarClientes();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarClientes();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            consultarconfiltro();
        }
    }
}