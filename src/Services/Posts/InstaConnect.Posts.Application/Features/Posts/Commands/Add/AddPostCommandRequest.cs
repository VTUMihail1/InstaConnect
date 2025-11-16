using InstaConnect.Posts.Application.Features.Users.Models;

namespace InstaConnect.Posts.Application.Features.Posts.Commands.Add;

public record AddPostCommandRequest(UserIdPayload UserId, string Title, string Content) : ICommandRequest<AddPostCommandResponse>;
