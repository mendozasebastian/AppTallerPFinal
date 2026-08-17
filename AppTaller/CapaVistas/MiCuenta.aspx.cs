using LOGIN.CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppTaller.CapaVistas
{
    public partial class MiCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosDeSesion();
            }
        }

        private void CargarDatosDeSesion()
        {
            string correo = Session["UsuarioEmail"] as string;
            string nombre = Session["UsuarioNombre"] as string;

            if (string.IsNullOrEmpty(correo))
            {
                lblSinSesion.Visible = true;
                panelCuenta.Visible = false;
                return;
            }

            lblSinSesion.Visible = false;
            panelCuenta.Visible = true;
            lblNombre.Text = nombre;
            lblCorreo.Text = correo;
        }

        protected void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            string correo = Session["UsuarioEmail"] as string;

            if (string.IsNullOrEmpty(correo))
            {
                lblSinSesion.Visible = true;
                panelCuenta.Visible = false;
                return;
            }

            usuario.eliminarusuario(correo);

            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}
