using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Events;

public record ChatDeletedEventRequest(string SenderId, string ReceiverId)
    : IEventRequest;
