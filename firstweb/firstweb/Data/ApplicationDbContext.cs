using firstweb.Models;
using Microsoft.EntityFrameworkCore;


namespace MyFirstWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

       
        public DbSet<Product> Products { get; set; }
    }
}