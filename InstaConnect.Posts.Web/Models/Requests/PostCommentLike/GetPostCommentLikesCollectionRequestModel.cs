using InstaConnect.Shared.Web.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests.Post
{
    public class GetPostCommentLikesCollectionRequestModel : CollectionRequestModel
    {
        [FromQuery(Name = "userId")]
        public string UserId { get; set; } = string.Empty;

        [FromQuery(Name = "postCommentId")]
        public string PostCommentId { get; set; } = string.Empty;
    }
}
