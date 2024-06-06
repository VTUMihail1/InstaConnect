using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Messages.Business.Commands.Messages.DeleteMessage;

public class DeleteMessageCommand : ICommand
{
    public string Id { get; set; }
}
