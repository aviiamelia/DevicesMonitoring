using DevicesMonitoring.Contracts;
using Npgsql;
using Microsoft.Extensions.Configuration;
using DevicesMonitoring.Infra.database;


public class Database(IUserRepository userRepository, IDeviceRepository deviceRepository, IConfiguration configuration)
{
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IDeviceRepository _deviceRepository = deviceRepository;
        private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection");

    public void main()
        {
            try
            {
                var schema = new Schema();

                using (var conn = new NpgsqlConnection(_connectionString))
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

