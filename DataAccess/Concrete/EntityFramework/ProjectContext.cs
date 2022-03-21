using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Mappers;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProjectContext : DbContext
    {

        #region DbSets
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Server=DESKTOP-9N0OBRE;Database=ProjectDb;Trusted_connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Mappers
            modelBuilder.ApplyConfiguration(new BookMapper());
            modelBuilder.ApplyConfiguration(new AuthorMapper());
            modelBuilder.ApplyConfiguration(new GenreMapper());
            modelBuilder.ApplyConfiguration(new UserMapper());
            modelBuilder.ApplyConfiguration(new OperationClaimMapper());
            #endregion

            #region ValueGenerateNever
            modelBuilder.Entity<Author>().Property(a => a.Id).ValueGeneratedNever().HasColumnName("Id");
            modelBuilder.Entity<Book>().Property(b => b.Id).ValueGeneratedNever().HasColumnName("Id");
            modelBuilder.Entity<Genre>().Property(b => b.Id).ValueGeneratedNever().HasColumnName("Id");
            modelBuilder.Entity<User>().Property(b => b.Id).ValueGeneratedNever().HasColumnName("Id");
            #endregion

        }
    }
}
