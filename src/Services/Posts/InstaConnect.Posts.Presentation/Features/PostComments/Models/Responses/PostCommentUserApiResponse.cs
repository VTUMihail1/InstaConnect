namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Responses;

public record PostCommentUserApiResponse(UserIdApiPayload Id, NameApiPayload Name, ImageApiPayload? ProfileImage);
