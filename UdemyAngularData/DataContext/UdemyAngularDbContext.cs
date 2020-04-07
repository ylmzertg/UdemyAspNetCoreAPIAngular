using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UdemyAngularData.DbModels;

namespace UdemyAngularData.DataContext
{
    public class UdemyAngularDbContext : IdentityDbContext
    {
        public UdemyAngularDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
