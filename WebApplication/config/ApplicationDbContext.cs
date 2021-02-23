using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.config
{
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {            
                // COMPRUEBA QUE LA BD ESTÁ CREADA Y SI NO LA CREA.
                Database.EnsureCreated();
            }

            public virtual DbSet<Provider> Providers { get; set; }
            public virtual DbSet<Product> Products { get; set; }
           /* protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Provider>()
                    .HasMany(b => b.products)
                    .WithOne();
            }*/
        }
    }
