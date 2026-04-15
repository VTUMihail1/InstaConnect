using InstaConnect.Common.Domain.Abstractions;
using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Common.Domain.Models.ValueObjects;

public record Name(string Value) : IValueObject
{
    public bool Is(Name name)
    {
        return Value.EqualsOrdinalIgnoreCase(name.Value);
    }

    public bool IsNot(Name name)
    {
        return !Is(name);
    }

    public bool IsEmpty()
    {
        return Value.IsNullOrEmptyOrWhiteSpace();
    }

    public bool StartsWith(Name name)
    {
        return Value.StartsWithOrdinalIgnoreCase(name.Value);
    }
}
