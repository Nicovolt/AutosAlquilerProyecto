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
        private List<string> ImagenesTemporales
        {
            get
            {
                if (ViewState["ImagenesTemporales"] == null)
                    ViewState["ImagenesTemporales"] = new List<string>();
                return (List<string>)ViewState["ImagenesTemporales"];
            }
            set
            {
                ViewState["ImagenesTemporales"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            
            
              if (!IsPostBack)
              {
                    CargarCombos();
                    int idAuto = ObtenerIdAuto();
                    

                if (idAuto != -1)
                {
                        
                        
                        CargarAuto(idAuto);
                        ltlTitulo.Text = "Modificar Auto";
                        btnAgregar.Text = "Actualizar";
                        
                    }
                else
                {
                        ltlTitulo.Text = "Nuevo Auto";
                        btnAgregar.Text = "Agregar";
                        
                }
              }
            
            
             

        }

        private int ObtenerIdAuto()
        {
            if (Request.QueryString["id"] != null)
            {
                return int.TryParse(Request.QueryString["id"], out int id) ? id : -1;
            }
            return -1;
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
                
                txtModelo.Text = auto.modelo;
                txtAño.Text = auto.anio.ToString();
                txtColor.Text = auto.color;
                txtPatente.Text = auto.numPatente;
                txtPrecio.Text = auto.precio.ToString();
                ddlCategoria.SelectedValue = categoria.IdCategoria.ToString();
                ddlMarca.SelectedValue = marca.IdMarca.ToString();

                ImagenesTemporales = auto.ListaImagenes.Select(img => img.ImagenUrl).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            string nuevaUrl = txtNuevaImagen.Text.Trim();
            if (!string.IsNullOrEmpty(nuevaUrl))
            {
                ImagenesTemporales.Add(nuevaUrl);
                txtNuevaImagen.Text = string.Empty;
                MostrarImagenes();
            }
        }

        private void MostrarImagenes()
        {
            pnlImagenes.Controls.Clear();

            foreach (string url in ImagenesTemporales)
            {
                Panel imageItem = new Panel();
                imageItem.CssClass = "image-item";

                TextBox txtUrl = new TextBox();
                txtUrl.CssClass = "form-control";
                txtUrl.Text = url;
                txtUrl.ReadOnly = true;

                Button btnEliminar = new Button();
                btnEliminar.CssClass = "btn btn-danger btn-remove";
                btnEliminar.Text = "X";
                btnEliminar.CommandArgument = url;
                btnEliminar.Click += BtnEliminarImagen_Click;
                btnEliminar.CausesValidation = false;

                imageItem.Controls.Add(txtUrl);
                imageItem.Controls.Add(btnEliminar);
                pnlImagenes.Controls.Add(imageItem);
            }
        }

        protected void BtnEliminarImagen_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string urlAEliminar = btn.CommandArgument;
            ImagenesTemporales.Remove(urlAEliminar);
            MostrarImagenes();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            AutoNegocio autoNegocio = new AutoNegocio();
            Auto auto = new Auto();
            ImagenNegocio imagenNegocio = new ImagenNegocio();  
            int idAuto = ObtenerIdAuto();
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

                auto.ListaImagenes = ImagenesTemporales
                    .Select(url => new Imagen { ImagenUrl = url })
                    .ToList();

                if (idAuto != -1)
                {
                    auto.idAuto = idAuto;
                    autoNegocio.Modificar(auto);
                    MostrarExito("Producto modificado exitosamente");
                }
                else
                {

                    autoNegocio.Agregar(auto);
                    imagenNegocio.GuardarImagenes(auto.ListaImagenes, auto.idAuto);
                    MostrarExito("Producto agregado exitosamente");
                }
                Response.Redirect("Default.aspx");

            }
            catch (Exception ex)
            {

                MostrarError("Error al guardar el producto: " + ex.Message);
            }
        }
        private void MostrarExito(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "success",
               $"Swal.fire({{" +
               $"  icon: 'success'," +
               $"  title: '¡Éxito!'," +
               $"  text: '{mensaje}'," +
               $"  confirmButtonColor: '#3085d6'" +
               $"}}).then((result) => {{" +
               $"  if (result.isConfirmed) {{" +
               $"    window.location = 'Default.aspx';" +
               $"  }}" +
               $"}});", true);
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