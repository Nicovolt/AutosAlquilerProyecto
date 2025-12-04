using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class AutoNegocio
    {
        public List<Auto> listar()
        {
            List<Auto> lista = new List<Auto>();
            AccesoDatos datos = new AccesoDatos();
            ImagenNegocio imagenNegocio = new ImagenNegocio(); 
            try
            {
                // Cambiamos a la consulta correcta
                datos.setearConsulta("SELECT IdAuto, Modelo, Precio, IdMarca, IdCategoria, Anio, Color, NumPatente FROM Autos");
                datos.ejecutarAccion();

                while (datos.Lector.Read())
                {
                    Auto aux = new Auto();
                    aux.idAuto = (int)datos.Lector["IdAuto"];
                    aux.modelo = (string)datos.Lector["Modelo"];
                    aux.precio = (decimal)datos.Lector["Precio"];  
                    aux.idMarca = datos.Lector["IdMarca"] != DBNull.Value ? (int)datos.Lector["IdMarca"] : 0;
                    aux.idCategoria = datos.Lector["IdCategoria"] != DBNull.Value ? (int)datos.Lector["IdCategoria"] : 0;

               
                   // aux.ListaImagenes = imagenNegocio.ListaImagenesPorArticulo(aux.idAuto);

                    // Añadimos el producto con las imágenes a la lista
                    lista.Add(aux);
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

        public void Agregar(Auto auto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into Autos(Precio,Color,Anio,Modelo,NumPatente,IdCategoria,IdMarca,Activo) values(@precio,@color,@anio,@modelo,@numPatente,@idCategoria,@idMarca,@activo)");
                datos.setearParametro("@precio", auto.precio);
                datos.setearParametro("@color", auto.color);
                datos.setearParametro("@anio", auto.anio);
                datos.setearParametro("@modelo", auto.modelo);
                datos.setearParametro("@numPatente", auto.numPatente);
                datos.setearParametro("@idCategoria", auto.idCategoria);
                datos.setearParametro("@idMarca", auto.idMarca);
                datos.setearParametro("@activo", true);
                datos.ejecutarAccion();

                int idAutoGenerado = 0;
                if(datos.Lector.Read())
                {
                    idAutoGenerado = Convert.ToInt32(datos.Lector[0]);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al agregar el producto y sus imágenes: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Auto BuscarPorID(int id) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select * from Autos where IdAuto = @ID");
                datos.setearParametro("@ID", id);
                datos.ejecutarAccion();
                Auto aux = new Auto();
                while (datos.Lector.Read())
                {
                   aux.idAuto = (int)datos.Lector["IdAuto"];
                    aux.modelo = (string)datos.Lector["Modelo"];
                    aux.precio = (decimal)datos.Lector["Precio"];
                    aux.anio = (int)datos.Lector["Anio"];
                    aux.idMarca = datos.Lector["IdMarca"] != DBNull.Value ? (int)datos.Lector["IdMarca"] : 0;
                    aux.idCategoria = datos.Lector["IdCategoria"] != DBNull.Value ? (int)datos.Lector["IdCategoria"] : 0;
                    aux.color = (string)datos.Lector["Color"];
                    aux.numPatente = (string)datos.Lector["NumPatente"];


                   
                   
                }
                return aux;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from Autos where IdAuto = @ID");
                datos.setearParametro("@ID", id);
                datos.ejecutarAccion();
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

        public void Modificar(Auto auto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update Autos set Precio=@precio, Color=@color, Anio=@anio, Modelo=@modelo, NumPatente=@numPatente, IdCategoria=@idCategoria, IdMarca=@idMarca where IdAuto=@idAuto");
                datos.setearParametro("@precio", auto.precio);
                datos.setearParametro("@color", auto.color);
                datos.setearParametro("@anio", auto.anio);
                datos.setearParametro("@modelo", auto.modelo);
                datos.setearParametro("@numPatente", auto.numPatente);
                datos.setearParametro("@idCategoria", auto.idCategoria);
                datos.setearParametro("@idMarca", auto.idMarca);
                datos.setearParametro("@idAuto", auto.idAuto);
                datos.ejecutarAccion();
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
