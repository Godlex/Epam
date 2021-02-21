namespace SalesApplication.DAL
{
    using System.Data.Entity;
    using Entities;

    public class OrdersDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        public DbSet<User> Users { get; set; }

        public OrdersDbContext(string connectionString) : base (connectionString)
        {
        }
    }
}