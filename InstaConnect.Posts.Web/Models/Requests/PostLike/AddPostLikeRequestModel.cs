using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests.Post
{
    public class AddPostLikeRequestModel
    {
        public string UserId { get; set; }

        public string PostId { get; set; }
    }
}
