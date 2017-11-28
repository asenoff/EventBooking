using EventBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        var connectionString = "Server = localhost\\SQLEXPRESS; Database = EventBooking; Trusted_Connection = True;";
        builder.UseSqlServer(connectionString);
        return new AppDbContext(builder.Options);
    }
}