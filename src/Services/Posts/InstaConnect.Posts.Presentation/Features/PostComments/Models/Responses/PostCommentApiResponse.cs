namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Responses;

public record PostCommentApiResponse(PostCommentIdApiPayload Id, string Content, PostCommentUserApiResponse User);
