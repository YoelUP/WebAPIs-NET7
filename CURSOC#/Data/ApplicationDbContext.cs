using CURSOC_.Models;
using Microsoft.EntityFrameworkCore;

namespace CURSOC_.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ProvinciaC> Provincias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProvinciaC>().HasData(
                new ProvinciaC()
                {
                    conprovincia = 1,
                    nomprovincia = "SAN JOSE"
                },
            new ProvinciaC()
            {
                conprovincia = 2,
                nomprovincia = "ALAJUELA"

            },
            new ProvinciaC()
            {
                conprovincia = 3,
                nomprovincia = "CARTAGO"

            },
            new ProvinciaC()
            {
                conprovincia = 4,
                nomprovincia = "HEREDIA"

            },
            new ProvinciaC()
            {
                conprovincia = 5,
                nomprovincia = "GUANACASTE"

            },
            new ProvinciaC()
            {
                conprovincia = 6,
                nomprovincia = "PUNTARENAS"

            },
            new ProvinciaC()
            {
                conprovincia = 7,
                nomprovincia = "LIMON"

            }
            );
        }
    }
}
