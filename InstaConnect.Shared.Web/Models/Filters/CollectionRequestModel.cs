using InstaConnect.Shared.Data.Enum;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Shared.Web.Models.Filters
{
    public class CollectionRequestModel
    {
        [FromQuery]
        public SortOrder SortOrder { get; set; }

        [FromQuery]
        public string SortPropertyName { get; set; }

        [FromQuery]
        public int Offset { get; set; }

        [FromQuery]
        public int Limit { get; set; }
    }
}
