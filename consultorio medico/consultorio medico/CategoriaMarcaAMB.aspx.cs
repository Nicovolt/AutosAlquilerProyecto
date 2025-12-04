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
    public partial class CategoriaMarcaAMB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCombos();
                int idProducto = ObtenerIdProducto();
                if (idProducto != -1)
                {
                    Cargar(idProducto);
                 
                    btnAgregar.Text = "Actualizar";
                }
                else
                {
                    
                    btnAgregar.Text = "Agregar";
                }
            }
        }

        private int ObtenerIdProducto()
        {
            if (Request.QueryString["id"] != null)
            {
                return int.TryParse(Request.QueryString["id"], out int id) ? id : -1;
            }
            return -1;
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

        protected void Agregar(object sender, EventArgs e)
        {

        }

        protected void Editar(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            int id = int.Parse(ddlCategoria.SelectedValue);
            string nopmbre = txtCategoriaEditada.Text;

              negocio.Editar(id, nopmbre);

        }

        protected void Cargar(int id)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();  
            Categoria categoria = new Categoria();

            categoria= negocio.ObtenerCategoriaPorId(id);
            txtCategoria.Text = categoria.Nombre;

        }

        private void CargarCombos()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
           ddlCategoria.DataSource   = negocio.listarCategorias();
            ddlCategoria.DataTextField = "Nombre";
            ddlCategoria.DataValueField = "IdCategoria";
            ddlCategoria.DataBind();
          


        }
    }
}