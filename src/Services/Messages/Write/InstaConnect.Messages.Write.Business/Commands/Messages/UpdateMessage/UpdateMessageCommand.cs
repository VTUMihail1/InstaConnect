using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Messages.Write.Business.Commands.Messages.UpdateMessage;

public class UpdateMessageCommand : ICommand
{
    public string Id { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public string CurrentUserId { get; set; } = string.Empty;
}
