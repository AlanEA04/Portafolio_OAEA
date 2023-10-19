using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
public class Conexion
{
    private string cadenaSql = string.Empty;

    public Conexion()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        cadenaSql = builder.GetSection("ConnectionStrings:cadenaSql").Value;
    }

    public string GetCadenaSql()
    {
        return cadenaSql;
    }
}
