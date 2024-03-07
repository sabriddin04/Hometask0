namespace Infrastructure.DataContext;
using Npgsql;
public class DapperContext
{

   private readonly string _connection ="Host=localhost;Port=5432;Database=CompanyWebDb;User id=postgres;Password=sabriddin2004;";
   

   public NpgsqlConnection Connection()
   {
     return new NpgsqlConnection(_connection);
   }






}
