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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Auto> listAuto = new List<Auto>();
            AutoNegocio autoNegocio = new AutoNegocio();
            if (!IsPostBack) {
                
                CargarFiltros();
                listAuto = autoNegocio.listar();
                repAutos.DataSource = listAuto;
                repAutos.DataBind();
            }

        }
       
        private void CargarFiltros()
        {
            try
            {
                MarcaNegocio MarcaNegocio = new MarcaNegocio();
                ddlMarca.DataSource = MarcaNegocio.ListarMarcas();
                ddlMarca.DataTextField = "Nombre";
                ddlMarca.DataValueField = "IdMarca";
                ddlMarca.DataBind();
                ddlMarca.Items.Insert(0, new ListItem("Seleccione una marca", ""));

                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                ddlCategoria.DataSource = categoriaNegocio.listarCategorias();
                ddlCategoria.DataTextField = "Nombre";
                ddlCategoria.DataValueField = "IdCategoria";
                ddlCategoria.DataBind();
                ddlCategoria.Items.Insert(0, new ListItem("Seleccione una categoria", ""));



            }
            catch (Exception ex)
            {

                MostrarError("Error al cargar los combos: " + ex.Message);
            }


        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            int categoriaID = int.Parse(ddlCategoria.SelectedValue);


            if (categoriaID == 0)
            {
                // CargarProductos();
            }
            else
            {
                ddlMarca.SelectedIndex = 0;
                //  CargarProductosCategoria(categoriaID);
            }
        }
        protected List<Imagen> GetImagenesOrDefault(object listaImagenes)
        {
            var imagenes = listaImagenes as List<Imagen>;

            if (imagenes == null || !imagenes.Any())
            {
                // Crear una lista con una imagen por defecto
                return new List<Imagen>
         { 
            new Imagen
            {
                ImagenUrl = ImagenDefault()
            }
        };
            }

            return imagenes;
        }

        public static string ImagenDefault()
        {
            string defaultImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT9cSGzVkaZvJD5722MU5A-JJt_T5JMZzotcw&s";
            return defaultImageUrl;
        }

        private void MostrarError(string mensaje)
        {
            mensaje = mensaje.Replace("'", "\\'");

            ScriptManager.RegisterStartupScript(this, GetType(), "error",
                $"Swal.fire({{" +
                $"  icon: 'error'," +
                $"  title: 'Error'," +
                $"  text: '{mensaje}'," +
                $"  confirmButtonColor: '#3085d6'" +
                $"}});", true);
        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlPrecio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void repAutos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName == "VerDetalle")
            {
                int idAuto = int.Parse(e.CommandArgument.ToString());
                Response.Redirect($"DetalleAuto.aspx?id={idAuto}");
            }
        }
    }
}