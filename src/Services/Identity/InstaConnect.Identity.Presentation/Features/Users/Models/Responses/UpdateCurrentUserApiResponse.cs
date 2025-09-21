namespace InstaConnect.Users.Application.Features.Users.Commands.Update;

public record UpdateCurrentUserApiResponse(string Id, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
