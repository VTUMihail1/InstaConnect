using InstaConnect.Common.Application.Models;

namespace InstaConnect.Posts.Application.Features.PostLikes.Models;

public record PostLikeQueryFilter(
    PostIdPayload Id,
    NamePayload UserName);
