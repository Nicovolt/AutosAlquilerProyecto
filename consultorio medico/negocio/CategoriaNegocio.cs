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
            datos.ejecutarLectura();
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
            datos.ejecutarLectura();
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

       

        public void Agregar(string aux)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("INSERT INTO Categoria (nombre) VALUES (@Nombre)");
            datos.setearParametro("@Nombre", aux);
            datos.ejecutarAccion();
            datos.cerrarConexion();
        }

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("DELETE FROM Categoria WHERE IdCategoria = @IdCategoria");
            datos.setearParametro("@IdCategoria", id);
            datos.ejecutarAccion();
            datos.cerrarConexion();
        }

        public void Modificar(int id, string nombre)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("UPDATE Categoria SET nombre = @Nombre WHERE IdCategoria = @IdCategoria");
            datos.setearParametro("@IdCategoria", id);
            datos.setearParametro("@Nombre", nombre);
            datos.ejecutarAccion();
            datos.cerrarConexion();
        }
    }
}
