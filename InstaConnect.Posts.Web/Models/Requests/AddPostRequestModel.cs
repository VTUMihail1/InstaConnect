using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests
{
    public class AddPostRequestModel
    {
        [FromRoute]
        public string UserId { get; set; }

        [FromBody]
        public AddPostBodyRequestModel AddPostBodyRequestModel { get; set; }
    }
}
