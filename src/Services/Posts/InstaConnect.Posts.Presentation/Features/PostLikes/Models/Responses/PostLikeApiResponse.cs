namespace InstaConnect.PostLikes.Application.Features.PostLikes.Models;

public record PostLikeApiResponse(string Id, string LikeId, PostLikeUserApiResponse User);
