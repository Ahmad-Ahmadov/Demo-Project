using DataAccess.Concrete.EntityFramework.Mappers;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProjectContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-9N0OBRE;Database=ProjectDb;Trusted_connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookMapper());
            modelBuilder.ApplyConfiguration(new AuthorMapper());
            modelBuilder.Entity<Author>().Property(a=>a.Id).ValueGeneratedNever().HasColumnName("Id");
            modelBuilder.Entity<Book>().Property(b=>b.Id).ValueGeneratedNever().HasColumnName("Id");
            modelBuilder.Entity<Genre>().Property(b => b.Id).ValueGeneratedNever().HasColumnName("Id");
        }
    }
}
