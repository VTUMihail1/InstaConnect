namespace InstaConnect.Chats.Presentation.Features.Users.Models.Responses;

public record UserApiResponse(UserIdApiPayload Id, NameApiPayload Name, ImageApiPayload? ProfileImage);
