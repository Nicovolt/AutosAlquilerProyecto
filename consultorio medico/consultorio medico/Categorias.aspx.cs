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
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarcarCategoria();
            }
        }

        private void CarcarCategoria()
        {
            CategoriaNegocio CategoriaNegocio = new CategoriaNegocio();
            ddlCategoriape.DataSource = CategoriaNegocio.listarCategorias();
            ddlCategoriape.DataTextField = "Nombre";
            ddlCategoriape.DataValueField = "IdCategoria";
            ddlCategoriape.DataBind();
            ddlCategoriape.Items.Insert(0, new ListItem("Seleccione la Categoria", ""));
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {


                string Nuevo = txtAgregarCat.Text;
                negocio.Agregar(Nuevo);
                CarcarCategoria();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {
                int id = int.Parse(ddlCategoriape.SelectedValue);
                string nombre = inpNombreCategoriaNueva.Text;
                negocio.Modificar(id, nombre);
                CarcarCategoria();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();

            try
            {
                int id = int.Parse(ddlCategoriape.SelectedValue);
                negocio.Eliminar(id);
                CarcarCategoria();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}