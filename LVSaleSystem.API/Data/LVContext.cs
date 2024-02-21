using LVSaleSystem.API.AccessTokens;
using LVSaleSystem.API.Model.Products;
using LVSaleSystem.API.Model.Stocks;
using LVSaleSystem.API.Model.Transactions;
using LVSaleSystem.API.Model.Users;
using LVSaleSystem.API.Model.Users.Customers;
using Microsoft.EntityFrameworkCore;

namespace LVSaleSystem.API.Data
{
    public class LVContext : DbContext
    {
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<SellingItem> SellingsItems { get; set; }
        public DbSet<Selling> Sellings { get; set; }
        public DbSet<Clothing> Clothings { get; set; }

        public DbSet<Return> Returns { get; set; }
        public DbSet<ClothingStock> ClothingStocks { get; set; }
        public DbSet<UserDetails> UserDetail { get; set; }

        public LVContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasIndex(u => u.CPF)
                .IsUnique();
            modelBuilder.Entity<Token>().HasIndex(u => u.Value)
                .IsUnique();
            modelBuilder.Entity<Clothing>();

            //modelBuilder.Entity<SellingItem>().OwnsOne(p => p.Product);
            //modelBuilder.Entity<ClothingStock>().OwnsOne(p => p.Item);


        }

    }
}
