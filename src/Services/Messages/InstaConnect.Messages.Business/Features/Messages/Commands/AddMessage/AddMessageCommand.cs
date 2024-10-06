using InstaConnect.Messages.Business.Features.Messages.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Messages.Business.Features.Messages.Commands.AddMessage;

public record AddMessageCommand(
    string CurrentUserId,
    string ReceiverId,
    string Content) : ICommand<MessageCommandViewModel>
{
}
