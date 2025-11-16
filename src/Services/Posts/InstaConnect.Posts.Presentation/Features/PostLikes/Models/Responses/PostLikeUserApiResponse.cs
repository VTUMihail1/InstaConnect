namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Responses;

public record PostLikeUserApiResponse(UserIdApiPayload Id, NameApiPayload Name, ImageApiPayload? ProfileImage);
