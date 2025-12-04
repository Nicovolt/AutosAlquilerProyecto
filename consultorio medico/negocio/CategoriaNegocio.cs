using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listarCategorias()
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("SELECT * FROM Categoria");
            datos.ejecutarAccion();
            List<Categoria> lista = new List<Categoria>();
            try
            {
                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Categoria ObtenerCategoriaPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("SELECT * FROM Categoria  WHERE idCategoria = @id");
            datos.setearParametro("@id", id);
            datos.ejecutarAccion();
            try
            {
                 Categoria aux = new Categoria();
                while (datos.Lector.Read())
                {
                    aux.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                }
                return aux;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Editar(int id, string nombre)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Categoria SET Nombre = @nombre WHERE IdCategoria = @id");
                datos.setearParametro("@id", id);
                datos.setearParametro("@nombre", nombre);
                datos.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
