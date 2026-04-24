using InstaConnect.Common.Domain.Features.Entities.Abstractions;

namespace InstaConnect.Identity.Domain.Features.Users.Models.ValueObjects;

public record UserId(string Id) : IEntityId;
