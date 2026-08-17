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
    public partial class Reparaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
            LlenarEquiposRef();
        }

        protected void LlenarEquiposRef()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("SELECT EquipoID, TipoEquipo, Modelo FROM Equipos", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    GridViewEquiposRef.DataSource = rdr;
                    GridViewEquiposRef.DataBind();
                }
            }
        }


        protected void LlenarGrid()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("SELECT * From Reparaciones", con))
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
            using (SqlCommand cmd = new SqlCommand("SELECT * from Reparaciones where ReparacionID = @ReparacionID", con))
            {
                cmd.Parameters.AddWithValue("@ReparacionID", txtReparacionID.Text);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                }
            }
        }

        protected void IngresarReparacion()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("insert into Reparaciones (EquipoID, FechaSolicitud, Estado) values (@equipoID, @fechaSolicitud, @estado)", con))
            {
                cmd.Parameters.AddWithValue("@equipoID", txtEquipoID.Text);
                cmd.Parameters.AddWithValue("@fechaSolicitud", txtFechaSolicitud.Text);
                cmd.Parameters.AddWithValue("@estado", txtEstado.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            LlenarGrid();
        }

        protected void BorrarReparacion()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("delete from Reparaciones where ReparacionID = @ReparacionID", con))
            {
                cmd.Parameters.AddWithValue("@ReparacionID", txtReparacionID.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            LlenarGrid();
        }

        protected void ActualizarReparacion()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("update Reparaciones set EquipoID = @EquipoID, FechaSolicitud = @FechaSolicitud, Estado = @Estado where ReparacionID = @ReparacionID", con))
            {
                cmd.Parameters.AddWithValue("@ReparacionID", txtReparacionID.Text);
                cmd.Parameters.AddWithValue("@EquipoID", txtEquipoID.Text);
                cmd.Parameters.AddWithValue("@FechaSolicitud", txtFechaSolicitud.Text);
                cmd.Parameters.AddWithValue("@Estado", txtEstado.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            LlenarGrid();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            IngresarReparacion();
            LlenarGrid();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            BorrarReparacion();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarReparacion();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            consultarconfiltro();
        }
    }
}