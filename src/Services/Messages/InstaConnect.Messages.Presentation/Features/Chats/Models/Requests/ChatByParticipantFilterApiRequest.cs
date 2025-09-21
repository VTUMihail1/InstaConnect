namespace InstaConnect.Chats.Presentation.Features.Chats.Models.Requests;

public record ChatByParticipantFilterApiRequest(
    [FromRoute] string ParticipantId,
    [FromQuery(Name = "participantName")] string ParticipantName = "");
