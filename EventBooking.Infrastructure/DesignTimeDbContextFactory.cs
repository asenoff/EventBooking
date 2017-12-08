using EventBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

// required implementation of IDesignTimeDbContextFactory for migrations to work
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        // todo - find a way to extract this in global.json
        var connectionString = "Server = localhost\\SQLEXPRESS; Database = EventBooking; Trusted_Connection = True;";
        builder.UseSqlServer(connectionString);
        return new AppDbContext(builder.Options);
    }
}