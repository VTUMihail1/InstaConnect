namespace InstaConnect.Posts.Application.Features.PostComments.Models;

public record PostCommentQueryResponse(string Id, string CommentId, string Content, PostCommentUserQueryResponse User);
