using Microsoft.EntityFrameworkCore;
using SuperShop.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SuperShop.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}