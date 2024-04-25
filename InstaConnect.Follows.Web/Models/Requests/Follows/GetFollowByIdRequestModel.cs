using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Web.Models.Requests.PostCommentLike
{
    public class GetFollowByIdRequestModel
    {
        [FromRoute]
        public string Id { get; set; }
    }
}
