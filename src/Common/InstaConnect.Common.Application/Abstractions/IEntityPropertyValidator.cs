using InstaConnect.Shared.Domain.Abstractions;

namespace InstaConnect.Shared.Application.Abstractions;

public interface IEntityPropertyValidator
{
    public bool IsEntityPropertyValid<T>(string propertyName) where T : IBaseEntity;
}
