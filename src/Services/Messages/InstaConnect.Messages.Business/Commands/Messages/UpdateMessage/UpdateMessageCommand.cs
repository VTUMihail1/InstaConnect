using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Messages.Business.Commands.Messages.UpdateMessage;

public class UpdateMessageCommand : ICommand
{
    public string Id { get; set; }

    public string Content { get; set; }
}
