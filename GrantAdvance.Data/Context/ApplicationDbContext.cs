using GrantAdvance.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GrantAdvance.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            UserModelBuilder(modelBuilder);
            ProductModelBuilder(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void UserModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<User>()
               .HasIndex(d => d.Id)
               .IsUnique();

            modelBuilder.Entity<User>()
               .Property(p => p.Email).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<User>()
              .Property(p => p.Name).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<User>()
             .Property(p => p.Password).HasMaxLength(150).IsRequired();

            modelBuilder.Entity<User>()
             .Property(p => p.DateCreate).IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        private void ProductModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                           .HasKey(d => d.Id);

            modelBuilder.Entity<Product>()
              .HasIndex(d => d.Id)
               .IsUnique();

            modelBuilder.Entity<Product>()
                .Property(p => p.Price).HasPrecision(10,2).IsRequired();

            modelBuilder.Entity<Product>()
               .Property(p => p.Name).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<Product>()
               .Property(p => p.DateCreate).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
