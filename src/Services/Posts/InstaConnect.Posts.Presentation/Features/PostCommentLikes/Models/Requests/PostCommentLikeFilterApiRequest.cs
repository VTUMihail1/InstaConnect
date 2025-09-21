namespace InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;

public record PostCommentLikeFilterApiRequest(
    [FromRoute] string Id,
    [FromRoute] string CommentId,
    [FromQuery(Name = "userName")] string UserName = "");
