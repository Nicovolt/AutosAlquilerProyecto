using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class MarcaNegocio
    {

        public List<Marca> ListarMarcas()
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("SELECT * FROM Marca");
            datos.ejecutarAccion();
            List<Marca> lista = new List<Marca>();
            try
            {
                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.IdMarca = (int)datos.Lector["idMarca"];
                    aux.Nombre = (string)datos.Lector["nombre"];
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

       public Marca ObtenerMarcaPorId(int id)
       {
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("SELECT * FROM MARCA WHERE idMarca = @IdMarca");
            datos.setearParametro("@IdMarca", id);
            datos.ejecutarAccion();
            try
            {
                    Marca marca = new Marca();
                while (datos.Lector.Read())
                {
                    marca.IdMarca = (int)datos.Lector["idMarca"];
                    marca.Nombre = (string)datos.Lector["nombre"];
                   
                }
               return marca;
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

        public void Agregar(Marca aux)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("INSERT INTO MARCA (nombre) VALUES (@Nombre)");
            datos.setearParametro("@Nombre", aux.Nombre);
            datos.ejecutarAccion();
            datos.cerrarConexion();
        }

    }
}
