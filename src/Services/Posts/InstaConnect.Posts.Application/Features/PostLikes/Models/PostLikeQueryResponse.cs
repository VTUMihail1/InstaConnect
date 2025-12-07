namespace InstaConnect.Posts.Application.Features.PostLikes.Models;

public record PostLikeQueryResponse(string Id, UserQueryResponse User, DateTimeOffset CreatedAtUtc);
