using InstaConnect.Common.Domain.Abstractions;

namespace InstaConnect.Common.Application.Abstractions;

public interface IEntityPropertyValidator
{
    public bool IsEntityPropertyValid<T>(string propertyName) where T : IBaseEntity;
}
