using Portafolio_OAEA.Models;
using System.Data.SqlClient;
using System.Data;
using System.Net.Security;
using System.Linq.Expressions;

namespace Portafolio_OAEA.Datos
{
    public class PortafolioDatos
    {
        public List<PortafolioModels>Listar()
        {
            var oLista = new List<PortafolioModels>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.GetCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using(var dr = cmd.ExecuteReader()) 
                {
                    while (dr.Read())
                    {
                        oLista.Add(new PortafolioModels()
                        {
                            IdPerfil = Convert.ToInt32(dr["IdPerfil"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Descripcion = dr["Descripcion"].ToString()

                        });
                    
                    }
                
                }
            }
            return oLista;
        }    
    }

  }
