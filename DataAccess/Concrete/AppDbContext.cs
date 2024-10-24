
using Microsoft.EntityFrameworkCore;
using RannaPanelManagement.Entities;

namespace RannaPanelManagement.DataAccess.Concrete
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }
        public DbSet<Manager> Managers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<SupportForm> SupportForms { get; set; }
    }
}
