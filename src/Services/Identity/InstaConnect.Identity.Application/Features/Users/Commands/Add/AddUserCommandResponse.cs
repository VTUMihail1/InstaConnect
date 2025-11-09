namespace InstaConnect.Identity.Application.Features.Users.Commands.Add;

public record AddUserCommandResponse(string Id, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
