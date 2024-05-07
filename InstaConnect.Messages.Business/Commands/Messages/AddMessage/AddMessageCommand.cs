using InstaConnect.Shared.Business.Messaging;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Messages.Business.Commands.PostComments.AddPostComment;

public class AddMessageCommand : ICommand
{
    public string ReceiverId { get; set; }

    public string Content { get; set; }
}
