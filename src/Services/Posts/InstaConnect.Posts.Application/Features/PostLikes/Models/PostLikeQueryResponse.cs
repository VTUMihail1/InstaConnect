using InstaConnect.Posts.Application.Features.Users.Models;

namespace InstaConnect.Posts.Application.Features.PostLikes.Models;

public record PostLikeQueryResponse(PostLikeIdPayload Id, UserQueryResponse User, DateTimeOffset CreatedAtUtc);
