using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FixMyCode
{
    public class DesignTimeDBContextFactory : IDesignTimeDbContextFactory<FixMyCodeDbContext>
    {
        public FixMyCodeDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var Configuration = builder.Build();

            string connectionString = Configuration.GetConnectionString("localDb");

            //SQL Server location needs to change
            var options = new DbContextOptionsBuilder<FixMyCodeDbContext>().UseSqlServer(connectionString).Options;
            return new FixMyCodeDbContext(options);
        }
    }
}
