namespace InstaConnect.Messages.Application.Features.Messages.Commands.Delete;

public record DeleteMessageCommand(string Id, string CurrentUserId) : ICommand
{
}
