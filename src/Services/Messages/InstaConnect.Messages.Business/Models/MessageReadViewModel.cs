namespace InstaConnect.Messages.Business.Models;

public record MessageReadViewModel(
    string Id,
    string SenderId,
    string SenderName,
    string? SenderProfileImage,
    string ReceiverId,
    string ReceiverName,
    string? ReceiverProfileImage,
    string Content
);
