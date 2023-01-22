using Microsoft.EntityFrameworkCore;
using Orange.Data.Entities;

namespace Orange.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movies").HasKey(a => a.Id);
            modelBuilder.Entity<Genre>().ToTable("Genres").HasKey(a => a.Id);
            modelBuilder.Entity<Favorite>().ToTable("Favorites").HasKey(a => a.Id);
        }
    }
}
