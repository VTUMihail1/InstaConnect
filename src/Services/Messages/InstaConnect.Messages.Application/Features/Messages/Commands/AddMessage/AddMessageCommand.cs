using InstaConnect.Messages.Application.Features.Messages.Models;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Messages.Application.Features.Messages.Commands.AddMessage;

public record AddMessageCommand(
    string CurrentUserId,
    string ReceiverId,
    string Content) : ICommand<MessageCommandViewModel>
{
}
