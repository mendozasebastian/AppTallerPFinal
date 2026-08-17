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
    public partial class Equipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
            LlenarUsuariosRef();
        }

        protected void LlenarUsuariosRef()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("SELECT UsuarioID, Nombre FROM Usuarios", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    GridViewUsuariosRef.DataSource = rdr;
                    GridViewUsuariosRef.DataBind();
                }
            }
        }


        protected void LlenarGrid()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("SELECT * From Equipos", con))
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
            using (SqlCommand cmd = new SqlCommand("SELECT * from Equipos where EquipoID = @EquipoID", con))
            {
                cmd.Parameters.AddWithValue("@EquipoID", txtEquipoID.Text);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                }
            }
        }

        protected void IngresarEquipos()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("insert into Equipos (TipoEquipo, Modelo, UsuarioID) values (@tipoEquipo, @modelo, @usuarioID)", con))
            {
                cmd.Parameters.AddWithValue("@tipoEquipo", txtTipoEquipo.Text);
                cmd.Parameters.AddWithValue("@modelo", txtModelo.Text);
                cmd.Parameters.AddWithValue("@usuarioID", txtUsuarioID.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            LlenarGrid();
        }

        protected void BorrarEquipo()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("delete from Equipos where EquipoID = @EquipoID", con))
            {
                cmd.Parameters.AddWithValue("@EquipoID", txtEquipoID.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            LlenarGrid();
        }

        protected void ActualizarEquipo()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("update Equipos set TipoEquipo = @TipoEquipo, Modelo = @Modelo, UsuarioID = @UsuarioID where EquipoID = @EquipoID", con))
            {
                cmd.Parameters.AddWithValue("@EquipoID", txtEquipoID.Text);
                cmd.Parameters.AddWithValue("@TipoEquipo", txtTipoEquipo.Text);
                cmd.Parameters.AddWithValue("@Modelo", txtModelo.Text);
                cmd.Parameters.AddWithValue("@UsuarioID", txtUsuarioID.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            LlenarGrid();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            IngresarEquipos();
            LlenarGrid();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            BorrarEquipo();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarEquipo();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            consultarconfiltro();
        }
    }
}