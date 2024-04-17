using InstaConnect.Shared.Data.Enum;

namespace InstaConnect.Shared.Business.Models.Filters
{
    public class CollectionDTO
    {
        public SortOrder SortOrder { get; set; }

        public string SortPropertyName { get; set; }

        public int Offset { get; set; }

        public int Limit { get; set; }
    }
}
