using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Messages.Business.Features.Messages.Commands.DeleteMessage;

public record DeleteMessageCommand(string Id, string CurrentUserId) : ICommand
{
}
