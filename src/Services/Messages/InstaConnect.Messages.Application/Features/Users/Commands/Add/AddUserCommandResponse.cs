namespace InstaConnect.Posts.Application.Features.Posts.Commands.Update;

public record AddUserCommandResponse(string Id, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
