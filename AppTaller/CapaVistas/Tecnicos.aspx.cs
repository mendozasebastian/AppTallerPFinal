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
    public partial class Tecnicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }


        protected void LlenarGrid()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("SELECT * From Tecnicos", con))
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
            using (SqlCommand cmd = new SqlCommand("SELECT * from Tecnicos where TecnicoID = @TecnicoID", con))
            {
                cmd.Parameters.AddWithValue("@TecnicoID", txtTecnicoID.Text);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                }
            }
        }

        protected void IngresarTecnico()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("insert into Tecnicos (Nombre, Especialidad) values (@nombre, @especialidad)", con))
            {
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Especialidad", txtEspecialidad.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            LlenarGrid();
        }

        protected void BorrarTecnico()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("delete from Tecnicos where TecnicoID = @TecnicoID", con))
            {
                cmd.Parameters.AddWithValue("@TecnicoID", txtTecnicoID.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            LlenarGrid();
        }

        protected void ActualizarTecnico()
        {
            string bd = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(bd))
            using (SqlCommand cmd = new SqlCommand("update Tecnicos set Nombre = @Nombre, Especialidad = @Especialidad where TecnicoID = @TecnicoID", con))
            {
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Especialidad", txtEspecialidad.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            LlenarGrid();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            IngresarTecnico();
            LlenarGrid();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            BorrarTecnico();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarTecnico();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            consultarconfiltro();
        }
    }
}