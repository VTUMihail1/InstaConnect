using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Messages.Write.Business.Commands.Messages.DeleteMessage;

public class DeleteMessageCommand : ICommand
{
    public string Id { get; set; } = string.Empty;

    public string CurrentUserId { get; set; } = string.Empty;
}
