using InstaConnect.Shared.Data.Enum;

namespace InstaConnect.Shared.Data.Models.Filters
{
    public class CollectionQuery
    {
        public SortOrder SortOrder { get; set; }

        public string SortPropertyName { get; set; }

        public int Offset { get; set; }

        public int Limit { get; set; }
    }
}
