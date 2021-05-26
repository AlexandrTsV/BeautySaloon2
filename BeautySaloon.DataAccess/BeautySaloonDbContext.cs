using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BeautySaloon.DataAccess
{
    public class BeautySaloonDbContext : DbContext
    {
        public DbSet<Entities.Saloon> Saloons { get; set; }
        public DbSet<Entities.CosmeticProduct> CosmeticProducts { get; set; }
        public DbSet<Entities.Bank> Banks { get; set; }
        public DbSet<Entities.BankProduct> BankProducts { get; set; }
        public DbSet<Entities.SaloonProduct> SaloonProducts { get; set; }
        public DbSet<Entities.ProductType> ProductTypes { get; set; }
        public DbSet<Entities.Service> Services { get; set; }

        public BeautySaloonDbContext() : base("BeautySaloon")
        {

            Database.SetInitializer(new BeautySaloonInitializer());
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["Sql"].ConnectionString);
        } */
    }
}
