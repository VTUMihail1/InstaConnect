using InstaConnect.Posts.Application.Features.Users.Models;

namespace InstaConnect.Posts.Application.Features.Posts.Commands.Update;

public record UpdatePostCommandRequest(PostIdPayload Id, UserIdPayload UserId, string Title, string Content) : ICommandRequest<UpdatePostCommandResponse>;
