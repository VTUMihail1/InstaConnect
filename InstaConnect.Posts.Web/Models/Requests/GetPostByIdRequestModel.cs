using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests
{
    public class GetPostByIdRequestModel
    {
        [FromRoute]
        public string Id { get; set; }
    }
}
