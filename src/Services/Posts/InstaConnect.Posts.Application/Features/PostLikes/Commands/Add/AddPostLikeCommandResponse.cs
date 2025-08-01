namespace InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;

public record AddPostLikeCommandResponse(string Id, string LikeId, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
