namespace InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Models;

public record GetPostLikeByIdAndUserIdQueryParameters(
    string Id,
    string UserId);
