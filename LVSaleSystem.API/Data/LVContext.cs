using LVSaleSystem.API.Model.Users;
using Microsoft.EntityFrameworkCore;

namespace LVSaleSystem.API.Data
{
    public class LVContext : DbContext
    {
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<UserDetails> UserDetail { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=localdatabase.db");
        }

    }
}
