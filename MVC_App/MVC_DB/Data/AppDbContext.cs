using Microsoft.EntityFrameworkCore;
using MVC_DB.Controllers;
using MVC_DB.Models;

namespace MVC_DB.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            

        }
        public DbSet<Product> Product { get; set; }
        //public DbSet<Rating> Ratings { get; set; } Framework erkennt die Abhängigkeit von Product zu Rating

        public void Seed()
        {
            // Korrigiert: Products statt Product verwenden und Any() auf DbSet anwenden
            if (!Product.Any())
            {
                Product.AddRange(ProductData.GetSampleProducts());
            }
         SaveChanges();
        }
    }
    
}
