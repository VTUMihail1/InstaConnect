using InstaConnect.Shared.Business.Messaging;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Posts.Business.Commands.PostLikes.AddPostLike;

public class AddPostLikeCommand : ICommand
{
    public string PostId { get; set; }
}
