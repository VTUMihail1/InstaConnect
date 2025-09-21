namespace InstaConnect.Chats.Application.Features.Chats.Models;

public record ChatApiResponse(ChatUserApiResponse ParticipantOne, ChatUserApiResponse ParticipantTwo);
