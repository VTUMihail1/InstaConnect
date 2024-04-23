using InstaConnect.Shared.Web.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests
{
    public class GetPostsCollectionRequestModel : CollectionRequestModel
    {
        [FromQuery(Name = "userId")]
        public string UserId { get; set; } = string.Empty;

        [FromQuery(Name = "title")]
        public string Title { get; set; } = string.Empty;
    }
}
