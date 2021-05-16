using MicroRabbit.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MicroRabbit.Banking.Data.Context
{
  
    public class BankingDbContext : DbContext
    {
        public BankingDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
    }
    
    //Burayı görmez ise migraiton yapmıyor. 
    public class BankingDbContextDesignFactory : IDesignTimeDbContextFactory<BankingDbContext>
    {
        public BankingDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder()
                .UseSqlServer("Data Source=localhost,1433;Initial Catalog=BankingDB;User=sa;Password=reallyStrongPwd123;MultipleActiveResultSets=true");
            return new BankingDbContext(optionsBuilder.Options);
        }
    }
}