using InstaConnect.Messages.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Messages.Business.Commands.Messages.UpdateMessage;

public record UpdateMessageCommand(string Id, string Content, string CurrentUserId) : ICommand<MessageCommandViewModel>
{
}
