namespace InstaConnect.Messages.Presentation.Features.Messages.Models.Responses;

public record MessageQueryResponse(
    string Id,
    string SenderId,
    string SenderName,
    string? SenderProfileImage,
    string ReceiverId,
    string ReceiverName,
    string ReceiverProfileImage,
    string Content);
