namespace InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Delete;

public record DeletePostLikeCommandRequest(
    string Id,
    string UserId) : ICommandRequest;
