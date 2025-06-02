using Microsoft.EntityFrameworkCore;
using lab6_op.Models;

namespace lab6_op.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserReg> UserRegs { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public LibraryContext() : base(GetOptions()) { }

        private static DbContextOptions GetOptions()
        {
            var connectionString = "Server=localhost\\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;";
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(u => u.ID);
            modelBuilder.Entity<UserReg>().HasKey(u => u.ID);
            modelBuilder.Entity<Book>().HasKey(b => b.ID);
            modelBuilder.Entity<Reservation>().HasKey(r => r.ID);
        }
    }
}
