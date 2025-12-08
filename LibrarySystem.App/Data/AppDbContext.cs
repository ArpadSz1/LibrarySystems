using LibrarySystem.App.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.App.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //One reader can have multiple loans
            modelBuilder.Entity<Loan>()
                .HasOne(r => r.Reader)
                .WithMany(l => l.Loans)
                .HasForeignKey(r => r.ReaderId)
                .OnDelete(DeleteBehavior.Cascade);

            //One book can have maximum one loan
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Loan)
                .WithOne(l => l.Book)
                .HasForeignKey<Loan>(l => l.InventoryNumber)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
