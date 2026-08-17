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
    public partial class DetallesReparacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
            LlenarReparacionesRef();
        }

        protected void LlenarReparacionesRef()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("SELECT ReparacionID, EquipoID, Estado FROM Reparaciones", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    GridViewReparacionesRef.DataSource = rdr;
                    GridViewReparacionesRef.DataBind();
                }
            }
        }


        protected void LlenarGrid()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("SELECT * From DetallesReparacion", con))
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
            using (SqlCommand cmd = new SqlCommand("SELECT * from DetallesReparacion where DetalleID = @DetalleID", con))
            {
                cmd.Parameters.AddWithValue("@DetalleID", txtDetalleID.Text);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                }
            }
        }

        protected void IngresarDetalleReparacion()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("insert into DetallesReparacion (ReparacionID, Descripcion, FechaInicio, FechaFin) values (@reparacionID, @descripcion, @fechaInicio, @fechaFinal)", con))
            {
                cmd.Parameters.AddWithValue("@reparacionID", txtReparacionID.Text);
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@fechaInicio", txtFechaInicio.Text);
                cmd.Parameters.AddWithValue("@fechaFinal", txtFechaFinal.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            LlenarGrid();
        }

        protected void BorrarDetalleReparacion()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("delete from DetallesReparacion where DetalleID = @DetalleID", con))
            {
                cmd.Parameters.AddWithValue("@DetalleID", txtDetalleID.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            LlenarGrid();
        }

        protected void ActualizarDetalleReparacion()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("update DetallesReparacion set ReparacionID = @ReparacionID, Descripcion = @Descripcion, FechaInicio = @FechaInicio, FechaFinal = @FechaFinal where DetalleID = @DetalleID", con))
            {
                cmd.Parameters.AddWithValue("@DetalleID", txtDetalleID.Text);
                cmd.Parameters.AddWithValue("@ReparacionID", txtReparacionID.Text);
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@FechaInicio", txtFechaInicio.Text);
                cmd.Parameters.AddWithValue("@FechaFinal", txtFechaFinal.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            LlenarGrid();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            IngresarDetalleReparacion();
            LlenarGrid();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            BorrarDetalleReparacion();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDetalleReparacion();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            consultarconfiltro();
        }
    }
}