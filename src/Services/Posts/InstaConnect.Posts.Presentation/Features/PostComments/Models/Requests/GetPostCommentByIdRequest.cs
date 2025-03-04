namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;

public record GetPostCommentByIdRequest(
    [FromRoute] string PostId,
    [FromRoute] string Id
);
