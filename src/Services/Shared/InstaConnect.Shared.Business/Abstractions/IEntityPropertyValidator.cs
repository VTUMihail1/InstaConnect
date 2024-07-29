using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Shared.Business.Abstractions;

public interface IEntityPropertyValidator
{
    public bool IsEntityPropertyValid<T>(string propertyName) where T : IBaseEntity;
}
