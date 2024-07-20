using InstaConnect.Messages.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Messages.Business.Commands.Messages.UpdateMessage;

public class UpdateMessageCommand : ICommand<MessageWriteViewModel>
{
    public string Id { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public string CurrentUserId { get; set; } = string.Empty;
}
