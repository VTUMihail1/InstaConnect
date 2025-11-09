namespace InstaConnect.Chats.Presentation.Features.Chats.Models.Responses;

public record ChatApiResponse(ChatUserApiResponse ParticipantOne, ChatUserApiResponse ParticipantTwo);
