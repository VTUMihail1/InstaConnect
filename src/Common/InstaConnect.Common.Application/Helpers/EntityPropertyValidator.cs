using InstaConnect.Common.Domain.Abstractions;

namespace InstaConnect.Common.Application.Helpers;

public class EntityPropertyValidator : IEntityPropertyValidator
{
    public bool IsEntityPropertyValid<T>(string propertyName) where T : IBaseEntity
    {
        var isValidProperty = typeof(T).GetProperties().Any(e => e.Name == propertyName);

        return isValidProperty;
    }
}
