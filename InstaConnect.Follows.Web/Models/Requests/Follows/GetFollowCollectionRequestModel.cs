using InstaConnect.Shared.Web.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Web.Models.Requests.Follows
{
    public class GetFollowCollectionRequestModel : CollectionRequestModel
    {
        [FromQuery(Name = "followerId")]
        public string FollowerId { get; set; } = string.Empty;

        [FromQuery(Name = "followingId")]
        public string FollowingId { get; set; } = string.Empty;
    }
}
