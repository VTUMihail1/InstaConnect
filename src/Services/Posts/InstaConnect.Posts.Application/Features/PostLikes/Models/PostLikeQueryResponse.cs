namespace InstaConnect.PostLikes.Application.Features.PostLikes.Models;

public record PostLikeQueryResponse(string Id, string LikeId, PostLikeUserQueryResponse User);
