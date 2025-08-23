using LostAndFoundApp.Enum;

namespace LostAndFoundApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Finder { get; set; }
        public ItemStatus Status { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateFound
        {
            get => _dateFound;
            set => _dateFound = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
        private DateTime _dateFound;

    }
}
