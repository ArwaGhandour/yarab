using Bank.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank.Models
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> option) : base(option) { }
        public  DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> transactions {  get; set; }
        public DbSet<Accounts>accounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>()
                .HasOne(x=>x.customer)
                .WithMany(x=>x.Accountss)
                .HasForeignKey(x=>x.CustomerIDD)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Transaction>()
                .HasOne(x=>x.Accounts)
                .WithMany(x=>x.transactions)
                .HasForeignKey(x=>x.AccountIDD)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
