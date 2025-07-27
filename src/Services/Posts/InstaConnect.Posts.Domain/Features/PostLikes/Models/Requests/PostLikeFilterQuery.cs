namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;

public record PostLikeFilterQuery(
    string Id,
    string UserId,
    string UserName);
