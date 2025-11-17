namespace InstaConnect.Posts.Presentation.Features.Users.Models;

public record UserApiResponse(UserIdApiPayload Id, NameApiPayload Name, ImageApiPayload? ProfileImage);
