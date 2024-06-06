using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests.PostLike;

public class DeletePostLikeRequestModel
{
    [FromRoute]
    public string Id { get; set; }
}
