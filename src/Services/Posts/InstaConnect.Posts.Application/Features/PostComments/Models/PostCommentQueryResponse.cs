namespace InstaConnect.Posts.Application.Features.PostComments.Models;

public record PostCommentQueryResponse(PostCommentIdPayload Id, string Content, PostCommentUserQueryResponse User);
