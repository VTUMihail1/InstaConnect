using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Events;

public record PostDeletedEventRequest(string Id)
    : IEventRequest;
