using InstaConnect.Messages.Application.Features.Messages.Models;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Messages.Application.Features.Messages.Commands.UpdateMessage;

public record UpdateMessageCommand(string Id, string Content, string CurrentUserId) : ICommand<MessageCommandViewModel>
{
}
