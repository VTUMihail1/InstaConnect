using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Messages.Business.Commands.PostComments.DeletePostComment;

public class DeleteMessageCommand : ICommand
{
    public string Id { get; set; }

    public string SenderId { get; set; }
}
