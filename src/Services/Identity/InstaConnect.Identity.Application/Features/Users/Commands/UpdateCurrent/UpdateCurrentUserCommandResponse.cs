namespace InstaConnect.Identity.Application.Features.Users.Commands.UpdateCurrent;

public record UpdateCurrentUserCommandResponse(string Id, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
