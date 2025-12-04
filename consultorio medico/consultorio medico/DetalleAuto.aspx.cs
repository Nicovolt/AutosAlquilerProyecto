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
    public partial class DetalleAuto : System.Web.UI.Page
    {

        private int idAutoURL()
        {
            int id = -1;
            if (Request.QueryString["id"] != null)
            {
                if (int.TryParse(Request.QueryString["id"], out id))
                {
                }

            }
            return id;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (idAutoURL() != -1)
            {
                if (!IsPostBack)
                {
                    string id = Request.QueryString["id"];
                    if (!string.IsNullOrEmpty(id))
                    {
                        CargarDetalleAuto(id);
                    }
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        private void CargarDetalleAuto(string id)
        {
            Marca marca = new Marca();
            MarcaNegocio negocioMarca = new MarcaNegocio();
            Categoria categoria = new Categoria();
            CategoriaNegocio negocioCategoria = new CategoriaNegocio();
            AutoNegocio negocio = new AutoNegocio();
            Auto auto = negocio.BuscarPorID(int.Parse(id));
            marca = negocioMarca.ObtenerMarcaPorId(auto.idMarca);
            categoria = negocioCategoria.ObtenerCategoriaPorId(auto.idCategoria);

            lblNombreAuto.Text = auto.modelo;
            lblMarca.Text = marca.Nombre;
            lblCategoria.Text = categoria.Nombre;
            lblAnio.Text = auto.anio.ToString();
            lblPrecio.Text = auto.precio.ToString();


        }
        protected void repAutos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
       
        protected void btnCarrito_Click(object sender, EventArgs e)
        {

        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            AutoNegocio negocio = new AutoNegocio();
            negocio.Eliminar(int.Parse(id));

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
           
            
             string idAuto = Request.QueryString["id"];
            Response.Redirect($"Autos.aspx?id={idAuto}");
            
        }
    }
}