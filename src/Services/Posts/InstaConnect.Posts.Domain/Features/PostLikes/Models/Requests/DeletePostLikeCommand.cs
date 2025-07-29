namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;

public record DeletePostLikeCommand(
    string Id,
    string LikeId,
    string UserId);
