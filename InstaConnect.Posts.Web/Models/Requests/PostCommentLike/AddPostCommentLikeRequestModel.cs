using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests.Post
{
    public class AddPostCommentLikeRequestModel
    {
        public string UserId { get; set; }

        public string PostCommentId { get; set; }
    }
}
