using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Commands.PostLikes.AddPostLike;

public class AddPostLikeCommand : ICommand
{
    public string PostId { get; set; }
}
