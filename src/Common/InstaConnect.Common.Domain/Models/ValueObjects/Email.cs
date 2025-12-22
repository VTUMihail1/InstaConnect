using InstaConnect.Common.Domain.Abstractions;
using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Common.Domain.Models.ValueObjects;

public record Email(string Value) : IValueObject
{
    public bool Is(Email email)
    {
        return Value.EqualsOrdinalIgnoreCase(email.Value);
    }

    public bool IsNot(Email email)
    {
        return !Is(email);
    }

    public bool IsEmpty()
    {
        return Value.IsNullOrEmptyOrWhiteSpace();
    }
}
