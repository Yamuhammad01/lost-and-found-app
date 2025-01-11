using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using LostAndFoundApp.Models;

namespace LostAndFoundApp
{
    public class DbContextFactory : IDesignTimeDbContextFactory<ItemDbContext>
    {
        public ItemDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ItemDbContext>();


            // Get the connection string from appsettings.json
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            return new ItemDbContext(optionsBuilder.Options);
        }
    }
}
