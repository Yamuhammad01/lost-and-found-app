using LostAndFoundApp.Enum;
using System.ComponentModel.DataAnnotations;

namespace LostAndFoundApp.Models
{
    public class ItemSearchFilterModel
    {
        [Display(Name = "Search")]
        public string SearchTerm { get; set; } = string.Empty;

        [Display(Name = "Status")]
        public ItemStatus? StatusFilter { get; set; }

        [Display(Name = "Date From")]
        public DateTime? DateFrom { get; set; }

        [Display(Name = "Date To")]
        public DateTime? DateTo { get; set; }

        [Display(Name = "Sort By")]
        public string SortBy { get; set; } = "DateFound";

        [Display(Name = "Sort Order")]
        public string SortOrder { get; set; } = "desc";

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
