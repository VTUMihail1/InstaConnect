using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;

public record GetPostCommentLikeByIdRequest(
    [FromRoute] string Id
);
