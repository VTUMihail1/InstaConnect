using InstaConnect.Messages.Business.Features.Messages.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Messages.Business.Features.Messages.Commands.UpdateMessage;

public record UpdateMessageCommand(string Id, string Content, string CurrentUserId) : ICommand<MessageCommandViewModel>
{
}
