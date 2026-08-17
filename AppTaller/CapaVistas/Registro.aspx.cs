using LOGIN.CapaDatos;
using LOGIN.CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOGIN.Capavistas
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string clave = txtClave.Text;
            string confirmarClave = txtConfirmarClave.Text;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(clave))
            {
                MostrarError("Todos los campos son obligatorios");
                return;
            }

            if (clave != confirmarClave)
            {
                MostrarError("Las contraseñas no coinciden");
                return;
            }

            int resultado = usuario.registrarusuario(correo, clave, nombre);

            if (resultado == 0)
            {
                MostrarError("Ya existe una cuenta registrada con ese correo");
                return;
            }

            lblExito.Visible = true;
            lblError.Visible = false;
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtClave.Text = "";
            txtConfirmarClave.Text = "";
        }

        private void MostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
            lblExito.Visible = false;
        }
    }
}
