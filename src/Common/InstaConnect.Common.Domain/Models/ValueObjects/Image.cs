using InstaConnect.Common.Domain.Abstractions;

namespace InstaConnect.Common.Domain.Models.ValueObjects;

public record Image(string Url) : IValueObject;
