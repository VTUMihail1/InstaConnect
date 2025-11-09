namespace InstaConnect.Posts.Application.Features.Users.Commands.Add;

public record AddUserCommandResponse(string Id, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
