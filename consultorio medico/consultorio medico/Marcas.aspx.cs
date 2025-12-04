using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace consultorio_medico
{
    public partial class Marcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarcarMarca();
            }
        }
        private void CarcarMarca()
        {
            MarcaNegocio MarcaNegocio = new MarcaNegocio();
            ddlMarcape.DataSource = MarcaNegocio.ListarMarcas();
            ddlMarcape.DataTextField = "nombre";
            ddlMarcape.DataValueField = "IdMarca";
            ddlMarcape.DataBind();
            ddlMarcape.Items.Insert(0, new ListItem("Seleccione la Marca", ""));
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                MarcaNegocio negocio = new MarcaNegocio();
                Marca marca = new Marca();
                marca.IdMarca = int.Parse(ddlMarcape.DataValueField);
                marca.Nombre = ddlMarcape.DataTextField;
                negocio.Agregar(marca);

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click1(object sender, EventArgs e)
        {

        }
    }
}