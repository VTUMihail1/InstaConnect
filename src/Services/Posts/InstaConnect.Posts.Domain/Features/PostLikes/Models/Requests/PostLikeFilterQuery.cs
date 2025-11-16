namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

public record PostLikeFilterQuery(
    PostId Id,
    Name UserName);
