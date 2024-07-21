using InstaConnect.Messages.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Messages.Business.Commands.Messages.AddMessage;

public record AddMessageCommand(
    string CurrentUserId, 
    string ReceiverId, 
    string Content) : ICommand<MessageWriteViewModel>
{
}
