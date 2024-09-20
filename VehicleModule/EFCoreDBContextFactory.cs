using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace VehicleModule
{
    public class EFCoreDBContextFactory : IDesignTimeDbContextFactory<EFCoreDBContext>
    {
        public EFCoreDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFCoreDBContext>();

            // Load configuration from appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Get the connection string
            var connectionString = config.GetConnectionString("DefaultConnection");

            // Ensure the connection string is not null or empty
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString), "Connection string cannot be null or empty");
            }

            // Use the connection string in the DbContext
            optionsBuilder.UseSqlServer(connectionString);

            return new EFCoreDBContext(optionsBuilder.Options);
        }
    }
}
