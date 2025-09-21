namespace InstaConnect.Chats.Infrastructure.Features.Chats.Models;

public record ChatQueryEntity(
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt,
        string ParticipantOneId,
        string ParticipantOneName,
        string ParticipantOneEmail,
        string ParticipantOneFirstName,
        string ParticipantOneLastName,
        string ParticipantOneProfileImage,
        DateTimeOffset ParticipantOneCreatedAt,
        DateTimeOffset ParticipantOneUpdatedAt,
        string ParticipantTwoId,
        string ParticipantTwoName,
        string ParticipantTwoEmail,
        string ParticipantTwoFirstName,
        string ParticipantTwoLastName,
        string ParticipantTwoProfileImage,
        DateTimeOffset ParticipantTwoCreatedAt,
        DateTimeOffset ParticipantTwoUpdatedAt);
