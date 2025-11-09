namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Responses;

public record PostCommentApiResponse(string Id, string CommentId, string Content, PostCommentUserApiResponse User);
