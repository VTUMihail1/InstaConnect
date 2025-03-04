namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;

public record GetPostCommentLikeByIdRequest(
    [FromRoute] string PostId,
    [FromRoute] string PostCommentId,
    [FromRoute] string Id
);
