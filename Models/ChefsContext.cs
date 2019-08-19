using Microsoft.EntityFrameworkCore;
 
namespace Chefs.Models
{
    public class ChefsContext : DbContext
    {
       public ChefsContext(DbContextOptions options) : base(options) { }
       public DbSet<Chef> MyChefs {get;set;}
       public DbSet<Dish> MyDishes {get; set;}
    }
}