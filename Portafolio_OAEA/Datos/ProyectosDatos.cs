using Portafolio_OAEA.Models;
using System.Data.SqlClient;
using System.Data;
using System.Net.Security;
using System.Linq.Expressions;

namespace Portafolio_OAEA.Datos
{
    public class ProyectosDatos
    {
        public List<ProyectoModel> Listar()
        {
            var oLista = new List<ProyectoModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.GetCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Sp_Lista", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ProyectoModel()
                        {
                            idProyecto = Convert.ToInt32(dr["idProyecto"]),
                            NombreProyecto = dr["NombreProyecto"].ToString(),
                            FechaCreado = dr["FechaCreado"].ToString(),
                            Descripcion = dr["Descripcion"].ToString()
                        });

                    }

                }
            }
            return oLista;
        }
    }
}
