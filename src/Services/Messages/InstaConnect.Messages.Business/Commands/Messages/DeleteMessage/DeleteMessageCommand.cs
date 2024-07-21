using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Messages.Business.Commands.Messages.DeleteMessage;

public record DeleteMessageCommand(string Id, string CurrentUserId) : ICommand
{
}
