using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests.Post
{
    public class GetPostCommentByIdRequestModel
    {
        [FromRoute]
        public string Id { get; set; }
    }
}
