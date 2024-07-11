using InstaConnect.Messages.Write.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Messages.Write.Business.Commands.Messages.AddMessage;

public class AddMessageCommand : ICommand<MessageViewModel>
{
    public string CurrentUserId { get; set; } = string.Empty;

    public string ReceiverId { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
