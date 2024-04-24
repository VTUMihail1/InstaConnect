using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests.Post
{
    public class DeletePostCommentLikeRequestModel
    {
        [FromRoute]
        public string Id { get; set; }

        [FromRoute]
        public string UserId { get; set; }
    }
}
