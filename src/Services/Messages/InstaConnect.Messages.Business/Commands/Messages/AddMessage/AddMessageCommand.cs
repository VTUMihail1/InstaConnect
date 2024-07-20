using InstaConnect.Messages.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Messages.Business.Commands.Messages.AddMessage;

public class AddMessageCommand : ICommand<MessageWriteViewModel>
{
    public string CurrentUserId { get; set; } = string.Empty;

    public string ReceiverId { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
