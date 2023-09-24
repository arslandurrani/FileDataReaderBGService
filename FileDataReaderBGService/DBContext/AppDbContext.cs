using FileDataReaderBGService.Common;
using FileDataReaderBGService.Entities;

using Microsoft.EntityFrameworkCore;

namespace FileDataReaderBGService.DBContext;

public class AppDbContext : DbContext
{
    public DbSet<ELDEvents> ELDEvents { get; set; }

    public DbSet<ELDEventsServer> ELDEventsServer { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // NOTE: DB will be created in the bin directory of where the app is running from

        // Configure the database connection (e.g., SQLite, SQL Server, etc.)
        optionsBuilder.UseSqlite(Constants.SQL_LITE_DATA_SOURCE);
    }
}
