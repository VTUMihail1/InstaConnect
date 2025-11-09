namespace InstaConnect.Identity.Presentation.Features.Users.Models.Responses;

public record UpdateCurrentUserApiResponse(string Id, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
