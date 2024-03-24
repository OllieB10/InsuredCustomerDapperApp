using Microsoft.Extensions.Configuration;

namespace DataAccessLayer
{
    public class DataConnection
    {
        public string GetConnectionString(string settings = "Settings")
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                                     .SetBasePath(Directory.GetCurrentDirectory())
                                                     .AddJsonFile("appsettings.json")
                                                     .Build();
            // Get a connection string
            string connectionString = configuration.GetConnectionString(settings);

            return connectionString;        
        }
    }
}
