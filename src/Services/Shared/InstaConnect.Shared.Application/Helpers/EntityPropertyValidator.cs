using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Shared.Business.Helpers;

public class EntityPropertyValidator : IEntityPropertyValidator
{
    public bool IsEntityPropertyValid<T>(string propertyName) where T : IBaseEntity
    {
        var isValidProperty = typeof(T).GetProperties().Any(e => e.Name == propertyName);

        return isValidProperty;
    }
}
