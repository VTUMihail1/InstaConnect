using InstaConnect.Common.Domain.Features.Entities.Abstractions;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;

public record PostId(string Id) : IEntityId;
