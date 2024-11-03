using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Shared.Business.Helpers;

public class EnumValidator : IEnumValidator
{
    public bool IsEnumValid<T>(string enumValueName) where T : Enum
    {
        var IsEnumValueValid = Enum.TryParse(typeof(T), enumValueName, out _);

        return IsEnumValueValid;
    }
}
