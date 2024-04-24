using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests.PostComment
{
    public class UpdatePostCommentRequestModel
    {
        [FromRoute]
        public string PostId { get; set; }

        [FromRoute]
        public string UserId { get; set; }

        [FromBody]
        public string Content { get; set; }
    }
}
