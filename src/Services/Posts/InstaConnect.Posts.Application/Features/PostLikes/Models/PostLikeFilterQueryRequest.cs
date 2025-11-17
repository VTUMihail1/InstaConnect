using InstaConnect.Common.Application.Models;

namespace InstaConnect.Posts.Application.Features.PostLikes.Models;

public record PostLikeFilterQueryRequest(
    PostIdPayload Id,
    NamePayload UserName);
