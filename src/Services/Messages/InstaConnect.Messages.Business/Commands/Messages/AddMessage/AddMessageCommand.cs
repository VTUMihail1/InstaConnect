using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Messages.Business.Commands.Messages.AddMessage;

public class AddMessageCommand : ICommand
{
    public string ReceiverId { get; set; }

    public string Content { get; set; }
}
