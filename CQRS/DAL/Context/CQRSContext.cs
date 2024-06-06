using CQRS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRS.DAL.Context
{
    public class CQRSContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=AYASINB\\AYASINB;initial Catalog=CQRSDb;integrated Security=true");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
