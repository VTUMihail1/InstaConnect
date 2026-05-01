namespace InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;

public record DeletePostLikeCommandRequest(string Id, string UserId) : ICommandRequest;
