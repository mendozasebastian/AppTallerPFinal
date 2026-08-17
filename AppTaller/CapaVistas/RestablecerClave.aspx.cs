using LOGIN.CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOGIN.Capavistas
{
    public partial class RestablecerClave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRestablecer_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            string nuevaClave = txtNuevaClave.Text;
            string confirmarClave = txtConfirmarClave.Text;

            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(nuevaClave))
            {
                MostrarError("Todos los campos son obligatorios.");
                return;
            }

            if (nuevaClave != confirmarClave)
            {
                MostrarError("Las contraseñas no coinciden.");
                return;
            }

            int resultado = usuario.restablecerclave(correo, nuevaClave); // 1 = actualizada, 0 = correo no existe

            if (resultado == 0)
            {
                MostrarError("No existe ninguna cuenta registrada con ese correo.");
                return;
            }

            lblExito.Visible = true;
            lblError.Visible = false;
            txtCorreo.Text = "";
            txtNuevaClave.Text = "";
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
