namespace InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;

public record AddPostLikeCommandResponse(string Id, string UserId, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
