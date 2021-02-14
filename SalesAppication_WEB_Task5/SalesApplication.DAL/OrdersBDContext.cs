namespace SalesApplication.DAL
{
    using System.Data.Entity;
    using Entities;

    public class OrdersBDContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public OrdersBDContext(string connectionString) : base (connectionString)
        {
        }
    }
}