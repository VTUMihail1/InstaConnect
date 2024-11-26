using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Messages.Application.Features.Messages.Commands.DeleteMessage;

public record DeleteMessageCommand(string Id, string CurrentUserId) : ICommand
{
}
