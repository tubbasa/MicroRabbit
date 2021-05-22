using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using  MicroRabbit.Transfer.Domain.Models;

namespace MicroRabbit.Transfer.Data.Context
{
    public class TransferDbContext : DbContext
    {
        public TransferDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<TransferLog> TransferLogs { get; set; }
    }
    
    //Burayı görmez ise migraiton yapmıyor. 
    public class TransferDbContextDesignFactory : IDesignTimeDbContextFactory<TransferDbContext>
    {
        public TransferDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder()
                .UseSqlServer("Data Source=localhost,1433;Initial Catalog=TransferDB;User=sa;Password=reallyStrongPwd123;MultipleActiveResultSets=true");
            return new TransferDbContext(optionsBuilder.Options);
        }
    }
}