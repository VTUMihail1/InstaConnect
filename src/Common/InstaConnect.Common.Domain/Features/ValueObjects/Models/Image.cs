using InstaConnect.Common.Domain.Features.ValueObjects.Abstractions;

namespace InstaConnect.Common.Domain.Features.ValueObjects.Models;

public record Image(string? Url) : IValueObject;
