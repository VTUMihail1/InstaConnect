using InstaConnect.Common.Application.Models;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Models;

public record PostCommentLikeFilterQueryRequest(
    PostCommentIdPayload Id,
    NamePayload UserName);
