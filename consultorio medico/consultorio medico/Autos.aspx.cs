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
    public partial class Autos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["id"] != null) 
            {
              if (!IsPostBack)
              {
               
                int idAuto = int.Parse(Request.QueryString["id"]);

                if (idAuto != -1)
                {
                        
                        
                        CargarAuto(idAuto);
                        /*ltlTitulo.Text = "Modificar Producto";*/
                        btnAgregar.Text = "Actualizar";
                        
                    }
                else
                {
                      CargarCombos();
                }
              }
            }
            
             

        }


        private void CargarCombos()
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

        

        private void CargarAuto(int id)
        {
            AutoNegocio autoNegocio = new AutoNegocio();
            Auto auto = autoNegocio.BuscarPorID(id);
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            Marca marca = marcaNegocio.ObtenerMarcaPorId(auto.idMarca);
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            Categoria categoria = categoriaNegocio.ObtenerCategoriaPorId(auto.idCategoria);
            try
            {
                CargarCombos();
                txtModelo.Text = auto.modelo;
                txtAño.Text = auto.anio.ToString();
                txtColor.Text = auto.color;
                txtPatente.Text = auto.numPatente;
                txtPrecio.Text = auto.precio.ToString();
                ddlCategoria.SelectedValue = categoria.IdCategoria.ToString();
                ddlMarca.SelectedValue = marca.IdMarca.ToString();

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            AutoNegocio autoNegocio = new AutoNegocio();
            Auto auto = new Auto();
            try
            {
                auto.precio = decimal.Parse(txtPrecio.Text);
                auto.color = txtColor.Text;
                auto.anio = int.Parse(txtAño.Text);
                auto.modelo = txtModelo.Text;
                auto.numPatente = txtPatente.Text;
                auto.idMarca = int.Parse(ddlMarca.SelectedValue);
                auto.idCategoria = int.Parse(ddlCategoria.SelectedValue);
                auto.disponible = true;

                autoNegocio.Agregar(auto);


            }
            catch (Exception)
            {

                throw;
            }
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

    }
}