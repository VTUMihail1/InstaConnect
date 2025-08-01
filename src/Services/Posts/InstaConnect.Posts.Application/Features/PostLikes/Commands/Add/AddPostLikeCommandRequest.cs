namespace InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;

public record AddPostLikeCommandRequest(string Id, string UserId) : ICommandRequest<AddPostLikeCommandResponse>;
