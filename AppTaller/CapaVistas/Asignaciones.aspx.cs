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
    public partial class Asignaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
            LlenarReparacionesRef();
            LlenarTecnicosRef();
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

        protected void LlenarTecnicosRef()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("SELECT TecnicoID, Nombre, Especialidad FROM Tecnicos", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    GridViewTecnicosRef.DataSource = rdr;
                    GridViewTecnicosRef.DataBind();
                }
            }
        }


        protected void LlenarGrid()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("SELECT * From Asignaciones", con))
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
            using (SqlCommand cmd = new SqlCommand("SELECT * from Asignaciones where AsignacionID = @AsignacionID", con))
            {
                cmd.Parameters.AddWithValue("@AsignacionID", txtAsignacionID.Text);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                }
            }
        }

        protected void IngresarAsignacion()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("insert into Asignaciones (ReparacionID, TecnicoID, FechaAsignacion) values (@reparacionID, @tecnicoID, @fechaAsignacion)", con))
            {
                cmd.Parameters.AddWithValue("@reparacionID", txtReparacionID.Text);
                cmd.Parameters.AddWithValue("@tecnicoID", txtTecnicoID.Text);
                cmd.Parameters.AddWithValue("@fechaAsignacion", txtFechaAsignacion.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            LlenarGrid();
        }

        protected void BorrarAsignacion()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("delete from Asignaciones where AsignacionID = @AsignacionID", con))
            {
                cmd.Parameters.AddWithValue("@AsignacionID", txtAsignacionID.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            LlenarGrid();
        }

        protected void ActualizarAsignacion()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("update Asignaciones set ReparacionID = @ReparacionID, TecnicoID = @TecnicoID, FechaAsignacion = @FechaAsignacion where AsignacionID = @AsignacionID", con))
            {
                cmd.Parameters.AddWithValue("@AsignacionID", txtAsignacionID.Text);
                cmd.Parameters.AddWithValue("@ReparacionID", txtReparacionID.Text);
                cmd.Parameters.AddWithValue("@TecnicoID", txtTecnicoID.Text);
                cmd.Parameters.AddWithValue("@FechaAsignacion", txtFechaAsignacion.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            LlenarGrid();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            IngresarAsignacion();
            LlenarGrid();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            BorrarAsignacion();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarAsignacion();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            consultarconfiltro();
        }
    }
}