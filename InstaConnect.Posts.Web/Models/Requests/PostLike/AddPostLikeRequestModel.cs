using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests.PostLike;

public class AddPostLikeRequestModel
{
    public string UserId { get; set; }

    public string PostId { get; set; }
}
