using Microsoft.EntityFrameworkCore;
using MVC_DB.Models;

namespace MVC_DB.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Produkt { get; set; }
        //public DbSet<Rating> Ratings { get; set; } Framework erkennt die Abhängigkeit von Product zu Rating
    }
    
}
