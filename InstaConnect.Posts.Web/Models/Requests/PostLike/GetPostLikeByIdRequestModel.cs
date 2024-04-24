using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests.Post
{
    public class GetPostLikeByIdRequestModel
    {
        [FromRoute]
        public string Id { get; set; }
    }
}
