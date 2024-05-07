using InstaConnect.Shared.Business.Messaging;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Posts.Business.Commands.PostComments.UpdatePostComment;

public class UpdatePostCommentCommand : ICommand
{
    public string Id { get; set; }

    public string Content { get; set; }
}
