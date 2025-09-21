namespace InstaConnect.Users.Application.Features.Users.Commands.Update;

public record UpdateCurrentUserCommandResponse(string Id, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
