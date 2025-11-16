namespace InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;

public record DeletePostLikeCommandRequest(PostLikeIdPayload Id) : ICommandRequest;
