using DevicesMonitoring.Contracts;
using Npgsql;

namespace DevicesMonitoring.Infra.database;

public class Database
{
    private readonly IUserRepository _userRepository;
    private readonly IDeviceRepository _deviceRepository;
    public Database(IUserRepository repository, IDeviceRepository deviceRepository)
    {
        _userRepository = repository;
        _deviceRepository = deviceRepository;
    }
    public void main()
    {
           
        try
        {
            var schema = new Schema();
            var connString = "Host=localhost;Port=5432;Database=devicesManager;Username=postgres;Password=password";
            using (var conn = new NpgsqlConnection(connString))

            {
                conn.Open();
                string createSchemaSql = "CREATE SCHEMA IF NOT EXISTS rocketseat;";
                using (var cmd = new NpgsqlCommand(createSchemaSql, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                string createTableSql = schema.CreateSchema();

                Console.WriteLine(createTableSql);

                using (var cmd = new NpgsqlCommand(createTableSql, conn))
                {
                    cmd.ExecuteNonQuery();
                }

            }

        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }
    }
}
