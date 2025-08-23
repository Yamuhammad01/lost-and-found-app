using LostAndFoundApp.Models;

namespace LostAndFoundApp.Services
{
    public interface IItemService
    {
        Task<List<Item>> GetItem();
        Task<Item> GetItem(int id);
        Task<(List<Item> Items, int TotalCount)> SearchAndFilterItems(ItemSearchFilterModel searchFilter);
        Task AddItem(Item items);
        Task UpdateItem(Item items);
        Task DeleteItem(int id);
      
    }
}
