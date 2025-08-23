using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.Common.Application.Contracts.Users;
public record UserDeletedEventRequest(string Id) : IEventRequest;
