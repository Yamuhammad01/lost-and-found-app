using LostAndFoundApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LostAndFoundApp.Services
{
    public class ItemService : IItemService
    {
        private readonly ItemDbContext _context;
        public ItemService(ItemDbContext context)
        {
            _context = context;
        }

        public async Task<List<Item>> GetItem()
        {
            return await _context.Items.ToListAsync();
        }
        public async Task<Item> GetItem(int id)
        {
            var items = await _context.Items.FindAsync(id);
            if (items == null)
            {
                throw new Exception("item not found");
            }
            return items;
        }
        public async Task AddItem(Item items)
        {
            _context.Items.Add(items);
            await _context.SaveChangesAsync();
        }
            
        public async Task UpdateItem(Item items)
        {
           
            _context.Entry(items).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteItem(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("Id is required.");
            }
            var club = await _context.Items.FindAsync(id);
            if (club != null)
            {
                _context.Items.Remove(club);
                await _context.SaveChangesAsync();
            }
        }
    }
}

