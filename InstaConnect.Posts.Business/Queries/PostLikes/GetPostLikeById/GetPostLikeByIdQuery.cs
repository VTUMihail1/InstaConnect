using InstaConnect.Posts.Business.Models;
using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Posts.Business.Queries.PostLikes.GetPostLikeById;

public class GetPostLikeByIdQuery : IQuery<PostLikeViewDTO>
{
    public string Id { get; set; }
}
