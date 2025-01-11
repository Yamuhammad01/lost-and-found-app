using LostAndFoundApp.Models;

namespace LostAndFoundApp.Services
{
    public interface IItemService
    {
        Task<List<Item>> GetItem();
        Task<Item> GetItem(int id);
        Task AddItem(Item items);
        Task UpdateItem(Item items);
        Task DeleteItem(int id);
      
    }
}
