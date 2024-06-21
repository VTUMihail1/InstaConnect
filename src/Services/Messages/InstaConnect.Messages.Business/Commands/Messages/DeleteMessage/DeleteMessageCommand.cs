using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Messages.Business.Commands.Messages.DeleteMessage;

public class DeleteMessageCommand : ICommand
{
    public string Id { get; set; }
}
