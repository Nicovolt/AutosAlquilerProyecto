using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> ListaImagenesPorArticulo(int idAuto)
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, IdAuto, ImagenUrl, Activo FROM Imagen WHERE IdAuto = @idAuto AND Activo = 1");
                datos.setearParametro("@idAuto", idAuto);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen img = new Imagen();
                    img.Id = (int)datos.Lector["Id"];
                    img.IdAuto = (int)datos.Lector["IdAuto"];
                    img.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    img.Activo = Convert.ToBoolean(datos.Lector["Activo"]);
                    lista.Add(img);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void GuardarImagenes(List<Imagen> imagenes, int idAuto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                foreach (var imagen in imagenes)
                {
                    datos.setearConsulta("INSERT INTO Imagen (IdAuto, ImagenUrl, Activo) VALUES (@IdAuto, @ImagenUrl, 1)");
                    datos.setearParametro("@IdAuto", idAuto);
                    datos.setearParametro("@ImagenUrl", imagen.ImagenUrl);
                    datos.ejecutarAccion();
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
