namespace InstaConnect.Common.Application.Contracts.Users;

public record UserUpdatedEvent(string Id, string Name, string Email, string FirstName, string LastName, string? ProfileImage);
