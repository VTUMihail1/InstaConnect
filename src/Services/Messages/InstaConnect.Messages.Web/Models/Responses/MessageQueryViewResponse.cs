namespace InstaConnect.Messages.Web.Models.Responses;

public record MessageQueryViewResponse(
    string Id, 
    string SenderId, 
    string SenderName,
    string? SenderProfileImage,
    string ReceiverId,
    string ReceiverName,
    string ReceiverProfileImage,
    string Content);
