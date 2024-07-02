using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Write.Commands.PostLikes.DeletePostLike;

public class DeletePostLikeCommand : ICommand
{
    public string Id { get; set; } = string.Empty;

    public string CurrentUserId { get; set; } = string.Empty;
}
