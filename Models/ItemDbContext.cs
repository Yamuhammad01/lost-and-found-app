using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LostAndFoundApp.Models
{
    public class ItemDbContext : DbContext
    {
        public ItemDbContext(DbContextOptions<ItemDbContext> options) : base(options)
        {
        }
        public DbSet<Item> Items { get; set; }
    }
}
