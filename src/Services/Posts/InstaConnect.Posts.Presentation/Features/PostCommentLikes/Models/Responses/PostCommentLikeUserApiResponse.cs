namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Responses;

public record PostCommentLikeUserApiResponse(UserIdApiPayload Id, NameApiPayload Name, ImageApiPayload? ProfileImage);
