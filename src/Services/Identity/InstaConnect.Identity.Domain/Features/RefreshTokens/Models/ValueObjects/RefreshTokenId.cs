using InstaConnect.Common.Domain.Features.Entities.Abstractions;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;

public record RefreshTokenId(UserId Id, string Value) : IEntityId;
