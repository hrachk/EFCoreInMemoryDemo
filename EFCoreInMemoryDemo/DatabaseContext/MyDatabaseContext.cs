using EFCoreInMemoryDemo.DataModel;
using Microsoft.EntityFrameworkCore;

namespace EFCoreInMemoryDemo.DatabaseContext
{
    public class MyDatabaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ProductDb");
        }
        public DbSet<ProductDataModel> Products { get; set; }
    }
}
