csharp LibrarySystem.App\Data\DesignTimeDbContextFactory.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LibrarySystem.App.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Keep same connection string as used at runtime
            optionsBuilder.UseSqlite("Data Source=library.db");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}