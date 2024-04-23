using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests
{
    public class DeletePostRequestModel
    {
        [FromRoute]
        public string Id { get; set; }

        [FromRoute]
        public string UserId { get; set; }
    }
}
