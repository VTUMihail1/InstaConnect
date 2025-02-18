namespace InstaConnect.Messages.Application.Features.Messages.Commands.Update;

public record UpdateMessageCommand(string Id, string Content, string CurrentUserId) : ICommand<MessageCommandViewModel>
{
}
