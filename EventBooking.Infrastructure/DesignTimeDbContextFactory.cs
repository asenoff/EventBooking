using EventBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

// required implementation of IDesignTimeDbContextFactory for migrations to work
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var jsonBuilder = new ConfigurationBuilder()
            .SetBasePath(System.Environment.CurrentDirectory)
            .AddJsonFile(Path.GetFullPath(Path.Combine("../EventBooking/appsettings.json")));

        IConfiguration configuration = jsonBuilder.Build();
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        builder.UseSqlServer(connectionString);
        return new AppDbContext(builder.Options);
    }
}