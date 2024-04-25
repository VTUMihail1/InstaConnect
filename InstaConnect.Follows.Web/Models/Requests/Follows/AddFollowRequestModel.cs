using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Web.Models.Requests.PostCommentLike
{
    public class AddFollowRequestModel
    {
        public string FollowerId { get; set; }

        public string FollowingId { get; set; }
    }
}
