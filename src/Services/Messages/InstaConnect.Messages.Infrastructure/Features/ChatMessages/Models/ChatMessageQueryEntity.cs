namespace InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Models;

public record ChatMessageQueryEntity(
        string ParticipantOneId,
        string ParticipantTwoId,
        string MessageId,
        string Content,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt,
        string SenderId,
        string SenderName,
        string SenderEmail,
        string SenderFirstName,
        string SenderLastName,
        string SenderProfileImage,
        DateTimeOffset SenderCreatedAt,
        DateTimeOffset SenderUpdatedAt);
