using InstaConnect.Common.Application.Models;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Models;

public record PostCommentLikeQueryFilter(
    PostCommentIdPayload Id,
    NamePayload UserName);
