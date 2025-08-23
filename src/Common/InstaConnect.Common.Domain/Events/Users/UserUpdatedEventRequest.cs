using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.Common.Application.Contracts.Users;

public record UserUpdatedEventRequest(string Id, string Name, string Email, string FirstName, string LastName, string? ProfileImage) : IEventRequest;
