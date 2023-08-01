using BasicECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicECommerce.Data
{
    public class BasicECommerceContext : DbContext
    {
        public BasicECommerceContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customer { get; set; } = null!;
        public DbSet<Product> Product { get; set; } = null!;
        public DbSet<Address> Address { get; set; } = null!;
        public DbSet<CustomerAddress> CustomerAddress{ get; set; } = null!;
        public DbSet<Order> Order { get; set; } = null!;
    }
}