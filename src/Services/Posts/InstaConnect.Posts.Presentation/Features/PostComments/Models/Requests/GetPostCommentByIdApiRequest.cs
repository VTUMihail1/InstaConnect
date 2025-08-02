namespace InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;

public record GetPostCommentByIdApiRequest(
    [FromRoute] string Id,
    [FromRoute] string CommentId
);
