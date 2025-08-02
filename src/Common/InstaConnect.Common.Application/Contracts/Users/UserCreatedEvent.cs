namespace InstaConnect.Common.Application.Contracts.Users;
public record UserCreatedEvent(string Id, string Name, string Email, string FirstName, string LastName, string? ProfileImage);
