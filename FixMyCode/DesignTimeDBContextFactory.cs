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
                .AddJsonFile("config.json");

            var Configuration = builder.Build();

            //SQL Server location needs to change
            //var options = new DbContextOptionsBuilder<FixMyCodeDbContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LibraryDB;Trusted_Connection=True;MultipleActiveResultSets=true").Options;
            return new FixMyCodeDbContext(options);
        }
    }
}
