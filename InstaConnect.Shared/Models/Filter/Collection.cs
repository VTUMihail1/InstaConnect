using InstaConnect.Shared.Models.Enum;

namespace InstaConnect.Shared.Models.Filter
{
    public class Collection
    {
        public SortOrder SortOrder { get; set; }

        public string SortPropertyName { get; set; }

        public int Offset { get; set; }

        public int Limit { get; set; }
    }
}
