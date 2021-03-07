using Microsoft.EntityFrameworkCore;
using PostAPI.Models;
namespace PostAPI.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Company>().HasKey(p => p.Id);
            builder.Entity<Company>().Property(p => p.companyName).IsRequired().HasMaxLength(35);
            builder.Entity<Company>().Property(p => p.numberOfEmployees).IsRequired();
            builder.Entity<Company>().Property(p => p.averageSalary).IsRequired();

            builder.Entity<Company>().HasData
            (
                new Company {Id=2000, companyName = "Company Name: Apple", numberOfEmployees = 2000, averageSalary=200}, 
                new Company {Id=2001, companyName = "Company Name: Microsoft", numberOfEmployees = 5000, averageSalary = 100 }
            );
        }
    }
}