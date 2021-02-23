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

            public DbSet<Product> Products { get; set; }
        }
    }
