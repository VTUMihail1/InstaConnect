namespace InstaConnect.PostComments.Application.Features.PostComments.Models;

public record PostCommentApiResponse(string Id, string CommentId, string Content, PostCommentUserApiResponse User);
