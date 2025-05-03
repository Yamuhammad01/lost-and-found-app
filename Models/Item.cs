namespace LostAndFoundApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Finder { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly DateFound { get; set; }

    }
}
