namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Responses;

public record PostUserApiResponse(UserIdApiPayload Id, NameApiPayload Name, ImageApiPayload? ProfileImage);
