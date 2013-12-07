using System.Data.Entity;
using Domain;

namespace DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
