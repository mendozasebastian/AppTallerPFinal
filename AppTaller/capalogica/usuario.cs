using LOGIN.CapaDatos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;

namespace LOGIN.CapaLogica
{
    public class usuario
    {
        public void Agregarusuario() { }
        public void Consultarusuario() { }
        public void Modificarusuario() { }
        public void Borrarusuario() { }


        public static int  validausuario(string correo, string clave)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("SELECT email, clave, nombre  FROM usuario WHERE email = @correo AND clave = @clave", conexion))
            {
                comando.Parameters.AddWithValue("@correo", correo);
                comando.Parameters.AddWithValue("@clave", clave);
                conexion.Open();
                using (SqlDataReader registro = comando.ExecuteReader())
                {
                    if (registro.Read())
                    {
                        cls_Usuario.nombre = registro["nombre"].ToString();
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public static bool existeusuario(string correo)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("SELECT 1 FROM usuario WHERE email = @correo", conexion))
            {
                comando.Parameters.AddWithValue("@correo", correo);
                conexion.Open();
                object resultado = comando.ExecuteScalar();
                return resultado != null;
            }
        }

        public static int registrarusuario(string correo, string clave, string nombre)
        {
            if (existeusuario(correo))
            {
                return 0;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("INSERT INTO usuario (email, clave, nombre) VALUES (@correo, @clave, @nombre)", conexion))
            {
                comando.Parameters.AddWithValue("@correo", correo);
                comando.Parameters.AddWithValue("@clave", clave);
                comando.Parameters.AddWithValue("@nombre", nombre);
                conexion.Open();
                comando.ExecuteNonQuery();
                return 1;
            }
        }

        public static int restablecerclave(string correo, string nuevaClave)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("UPDATE usuario SET clave = @nuevaClave WHERE email = @correo", conexion))
            {
                comando.Parameters.AddWithValue("@correo", correo);
                comando.Parameters.AddWithValue("@nuevaClave", nuevaClave);
                conexion.Open();
                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas > 0 ? 1 : 0;
            }
        }

        public static int eliminarusuario(string correo)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("DELETE FROM usuario WHERE email = @correo", conexion))
            {
                comando.Parameters.AddWithValue("@correo", correo);
                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }

    }
}