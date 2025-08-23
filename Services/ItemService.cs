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

        public async Task<(List<Item> Items, int TotalCount)> SearchAndFilterItems(ItemSearchFilterModel searchFilter)
        {
            var query = _context.Items.AsQueryable();

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(searchFilter.SearchTerm))
            {
                var searchTerm = searchFilter.SearchTerm.ToLower();
                query = query.Where(x =>
                    x.Name.ToLower().Contains(searchTerm) ||
                    x.Description.ToLower().Contains(searchTerm) ||
                    x.Finder.ToLower().Contains(searchTerm));
            }

            // Apply status filter
            if (searchFilter.StatusFilter.HasValue)
            {
                query = query.Where(x => x.Status == searchFilter.StatusFilter.Value);
            }

            // Apply date range filter
            if (searchFilter.DateFrom.HasValue)
            {
                query = query.Where(x => x.DateFound >= searchFilter.DateFrom.Value);
            }

            if (searchFilter.DateTo.HasValue)
            {
                var dateTo = searchFilter.DateTo.Value.AddDays(1); // Include the entire day
                query = query.Where(x => x.DateFound < dateTo);
            }

            // Get total count before pagination
            var totalCount = await query.CountAsync();

            // Apply sorting
            query = searchFilter.SortBy.ToLower() switch
            {
                "name" => searchFilter.SortOrder == "asc"
                    ? query.OrderBy(x => x.Name)
                    : query.OrderByDescending(x => x.Name),
                "status" => searchFilter.SortOrder == "asc"
                    ? query.OrderBy(x => x.Status)
                    : query.OrderByDescending(x => x.Status),
                "finder" => searchFilter.SortOrder == "asc"
                    ? query.OrderBy(x => x.Finder)
                    : query.OrderByDescending(x => x.Finder),
                _ => searchFilter.SortOrder == "asc"
                    ? query.OrderBy(x => x.DateFound)
                    : query.OrderByDescending(x => x.DateFound)
            };

            // Apply pagination
            var items = await query
                .Skip((searchFilter.Page - 1) * searchFilter.PageSize)
                .Take(searchFilter.PageSize)
                .ToListAsync();

            return (items, totalCount);
        }
        public async Task AddItem(Item items)
        {
            items.DateFound = DateTime.SpecifyKind(items.DateFound, DateTimeKind.Utc);
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

