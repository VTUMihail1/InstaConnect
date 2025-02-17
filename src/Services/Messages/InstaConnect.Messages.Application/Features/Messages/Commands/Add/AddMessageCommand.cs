namespace InstaConnect.Messages.Application.Features.Messages.Commands.Add;

public record AddMessageCommand(
    string CurrentUserId,
    string ReceiverId,
    string Content) : ICommand<MessageCommandViewModel>
{
}
