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
            ddlMarcape.DataTextField = "Nombre";
            ddlMarcape.DataValueField = "IdMarca";
            ddlMarcape.DataBind();
            ddlMarcape.Items.Insert(0, new ListItem("Seleccione la Marca", ""));
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

                MarcaNegocio negocio = new MarcaNegocio();
            try
            {
               
                
                string Nuevo = inpNombreMar.Text;
                negocio.Agregar(Nuevo);
                CarcarMarca();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        protected void Editar(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            try
            {
                int id = int.Parse(ddlMarcape.SelectedValue);
                string nombre = inpNombreMarcaNueva.Text;               
                negocio.Modificar(id,nombre);
                CarcarMarca();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void Eliminar(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            
            try
            {
                int id = int.Parse(ddlMarcape.SelectedValue);               
                negocio.Eliminar(id);
               CarcarMarca();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}