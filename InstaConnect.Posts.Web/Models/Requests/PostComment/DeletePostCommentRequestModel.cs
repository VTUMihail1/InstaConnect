using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests.PostComment
{
    public class DeletePostCommentRequestModel
    {
        [FromRoute]
        public string Id { get; set; }

        [FromRoute]
        public string UserId { get; set; }
    }
}
