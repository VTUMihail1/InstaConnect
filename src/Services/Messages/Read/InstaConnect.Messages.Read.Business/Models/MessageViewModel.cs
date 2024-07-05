namespace InstaConnect.Messages.Read.Business.Models;

public class MessageViewModel
{
    public string Id { get; set; } = string.Empty;

    public string SenderId { get; set; } = string.Empty;

    public string SenderName { get; set; } = string.Empty;

    public string? SenderProfileImage { get; set; } = string.Empty;

    public string ReceiverId { get; set; } = string.Empty;

    public string ReceiverName { get; set; } = string.Empty;

    public string? ReceiverProfileImage { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
