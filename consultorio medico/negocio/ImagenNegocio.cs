using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    internal class ImagenNegocio
    {
        public List<Imagen> ListaImagenesPorArticulo(int id)
        {
            List<Imagen> imagenes = new List<Imagen>();
            AccesoDatos data = new AccesoDatos();

            try
            {
                // Consulta directa a la tabla Imagen
                data.setearConsulta("SELECT Id, IdProducto, ImagenUrl, Activo FROM Imagen WHERE IdProducto = @IdAuto");
                data.setearParametro("@IdAuto", id);
                data.ejecutarAccion();

                while (data.Lector.Read())
                {
                    Imagen imagen = new Imagen();
                    imagen.Id = (int)data.Lector["Id"];

                    // Manejar la posibilidad de que IdProducto sea nulo
                    imagen.IdProducto = data.Lector["IdAuto"] != DBNull.Value ? (int)data.Lector["IdAuto"] : 0; // O cualquier otro valor por defecto que necesites

                    // Asegúrate de que ImagenUrl nunca sea nulo
                    imagen.ImagenUrl = (string)data.Lector["ImagenUrl"]; // Este campo no debería ser nulo, pero se puede manejar

                    // Manejar el campo Activo
                    imagen.Activo = (byte)data.Lector["Activo"] != 0; // Convertimos tinyint a bool

                    imagenes.Add(imagen);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar imágenes por artículo", ex);
            }
            finally
            {
                data.cerrarConexion();
            }
            return imagenes;
        }
    }
}
